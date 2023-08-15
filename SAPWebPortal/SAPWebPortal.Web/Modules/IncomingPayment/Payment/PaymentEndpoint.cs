using SAPWebPortal.Web.Modules.Common.Helpers; 
using HelperWebSL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.ARInvoice.Endpoints;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Web.Helpers; 
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.IncomingPayment.PaymentRow;
using System.Reflection.Metadata.Ecma335;
using AspNetCoreHero.ToastNotification.Abstractions;
using NToastNotify;
using SAPWebPortal.Web.Models.SLModels;

namespace SAPWebPortal.IncomingPayment.Endpoints
{
    [Route("Services/IncomingPayment/Payment/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class PaymentController : ServiceEndpoint,IDataDictionary
    {// private readonly INotyfService _Notify;
        private readonly IToastNotification _ToastNotification;
        public PaymentController(IToastNotification ToastNotification, INotyfService Notify)
        {
            _ToastNotification = ToastNotification;
            //_Notify = Notify;
        }

        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IPaymentSaveHandler handler)
        {
           SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
           return helper.CreateInSAP(request); 
        }
        //PostPayment
        [HttpPost,IgnoreAntiforgeryToken]
        public SaveResponse PostPayment(IncomingPaymentPosting request)
        { 
            var acctcode = "";
            int usersign = -1;
            var usercode = Context.User.Identity.Name;
            var usercontroller = new UsersController();
            var company_Name = usercontroller.getCompanyName(usercode);
            SaveRequest<MyRow> request1 = new SaveRequest<MyRow>();
           
            request1.Entity = new MyRow();
            var entity = request1.Entity;
            if (request.PaymentType == PaymentType.Cash)
            {
                using (var dbconnection = DBHelper.GetDBConnection(company_Name))
                {
                    if(dbconnection.State != ConnectionState.Open)
                    dbconnection.Open();
                    var sql = $@"select ""U_ACCTCODE"",""USERID"" from OUSR where ""USER_CODE"" = '{usercode}'";
                    using (var tble = DBHelper.GetTableFromQuery(sql,dbconnection))
                    {
                        if (tble.Rows.Count > 0)
                        {
                            acctcode = tble.Rows[0][0].ToString();
                            usersign = Convert.ToInt32(tble.Rows[0][1]);
                        }
                    }
                    dbconnection.Close();
                }
                entity.CashAccount = acctcode;
                entity.CashSum = request.ReceivedTotal;
                entity.U_UserSign = usersign;
                entity.U_UserCode = usercode;

            }
            else if (request.PaymentType == PaymentType.Cheque)
            {

                request1.Entity.PaymentChecks = new System.Collections.Generic.List<PaymentCheckRow>();
                //foreach value in  request.ListOfChecks;
                foreach (var item in request.ListOfChecks)
                {
                    var check = new PaymentCheckRow();
                    check.CheckNumber = item.CheckNumber;
                    check.BankCode = item.BankCode; 
                    check.CheckSum = item.CheckSum;
                    check.DueDate = item.CheckDate;
                    check.U_UserCode = usercode;
                    request1.Entity.PaymentChecks.Add(check);
                }

            }
            else if (request.PaymentType == PaymentType.BankTransfer)
            {
                //Transfer Account
                entity.TransferAccount = request.TransferAccount;
                entity.TransferSum = request.ReceivedTotal;
            }
            request1.Entity.CardCode = request.CardCode;
            request1.Entity.DocType = "C";
            entity.PaymentInvoices = new System.Collections.Generic.List<PaymentInvoiceRow>();
            var recievedamount = request.ReceivedTotal;
            foreach (var item in request.ListOfInvoicesDocEntries)
            {
                var invoicecontroller = new DocumentController();
                invoicecontroller.SetPrivatePropertyValue<IRequestContext>("Context", Context) ;
                var row = invoicecontroller.Retrieve(null, new RetrieveRequest() { EntityId = item }, null);
                var duebalance = row.Entity.DocTotal - row.Entity.PaidToDate;
                if (duebalance > 0)
                {
                    if (recievedamount > 0)
                    {
                        if (recievedamount > duebalance)
                        {
                            recievedamount = recievedamount - duebalance ?? 0.0;
                            entity.PaymentInvoices.Add(new PaymentInvoiceRow()
                            {
                                DocEntry = item,
                                InvoiceType = "it_Invoice",
                                SumApplied = duebalance,
                                DiscountPercent = 0,
                            });
                        }
                        else
                        {
                            entity.PaymentInvoices.Add(new PaymentInvoiceRow()
                            {
                                DocEntry = item,
                                InvoiceType = "it_Invoice",
                                SumApplied = recievedamount,
                                DiscountPercent = 0,
                            });
                            recievedamount = 0.0;
                        }
                    }
                }
            }

            //SAPB1.Payment payments = new SAPB1.Payment();
            //    payments.DocType = SAPB1.BoRcptTypes.
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            SaveResponse response = null;
            if (request.PaymentType != PaymentType.BankTransfer)

                response  = helper.CreateInSAP(request1);
            else
                response = helper.CreateInSAP(request1, true);
            //helper.RefreshFromSAPPAS();
            return response;
        }   

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IPaymentSaveHandler handler)
        { 
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            var result  =  helper.UpdateInSAP(request);
            //helper.RefreshFromSAPPAS();
            return result;
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IPaymentDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.DeleteInSAP(request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IPaymentRetrieveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.RetrieveFromSAP(request); 
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IPaymentListHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DataSourceType = DataSourceType.SAP_DataBase;
                
            return helper.List(request);
        }
        [HttpGet]
        public ListResponse<MyRow> GetAll()
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            var request = new ListRequest();

            //filter by user
            // request.Criteria = new Criteria("CreatedBy") == Context.User.Identity.Name;
            //getactivdbname from userscontroller
            var usercontroller = new UsersController(Context);
            var dbname = usercontroller.getCompanyName(Context.User.Identity.Name);
            var criteriastring = "";
            using(var connection = DBHelper.GetDBConnection(dbname))
            {
                if(connection.State != ConnectionState.Open)
                connection.Open();
                //get userid from user_code from ousr sap query 
                var query = $@"select ""USERID"" from ousr where ""USER_CODE"" = '{Context.User.Identity.Name}'";
                using (var table = DBHelper.GetTableFromQuery(query, connection))
                {
                    if (table.Rows.Count > 0)
                    {
                        var userid = table.Rows[0]["USERID"].ToString();
                        criteriastring = $@" U_UserSign eq {userid}";
                        
                    }
                }
                connection.Close();
            }

            request.Take = 10000;
            request.Skip = 0;
            return helper.List(request,criteriastring);

        }
        [HttpGet]
        //GetBanks
        public ListResponse<(string Code,string Name)> GetBanks()
        {
            var response = new ListResponse<(string Code, string Name)>();
            var list = new System.Collections.Generic. List<(string Code, string Name)>();
            var usercontroller = new UsersController(Context);
            var dbname = usercontroller.getCompanyName(Context.User.Identity.Name);
            using (var connection = DBHelper.GetDBConnection(dbname))
            {
                if(connection.State != ConnectionState.Open)
                connection.Open();
                var query = $@"select ""BankCode"",""BankName"" from ODSC";
                using (var table = DBHelper.GetTableFromQuery(query, connection))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        list.Add((row["BankCode"].ToString(), row["BankName"].ToString()));
                    }
                }
                connection.Close();
            }
            response.Entities = list;
            return response;
        }
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IPaymentListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.PaymentColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "PaymentList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        public JsonResult GetNextNumber(ApiData seriesid)
        {
            return Json(SAPHelper<MyRow>.GetMarketingNextNumber(seriesid));
        }
        public JsonResult GetCodeNameValues(CodeNameValuesInputParams row)
        {
            return Json(SAPHelper<MyRow>.GetListFromQuery(row.row, row.propertyNameSAP,row.row.DBName));
        }

        public void FillDataDictionary(string username, string password, string companyDB)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);

            helper.FillDataDictionary(username, password, companyDB);
        }

        public System.Collections.Generic.List<(string username, string dbname, string modlulename, int totalcount)> GetAllDataDictionary()
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.GetAllDataDictionary();
        }
    }
    public class CodeNameValuesInputParams
    {
        public MyRow row { get; set; }
        public string propertyNameSAP { get; set; }
    }
}