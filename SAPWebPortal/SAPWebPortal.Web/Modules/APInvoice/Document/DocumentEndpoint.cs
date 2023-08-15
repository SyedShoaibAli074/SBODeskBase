
using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Web.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.APInvoice.DocumentRow;
using SAPWebPortal.Web.Modules.Common.Helpers;
using System.Collections.Generic;
using NToastNotify;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Web;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Web.Models.SLModels;

namespace SAPWebPortal.APInvoice.Endpoints
{
    [Route("Services/APInvoice/Document/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class DocumentController : ServiceEndpoint
    {
        //implement IDataDictionary

        // private readonly INotyfService _Notify;
        private readonly IToastNotification _ToastNotification;
       public DocumentController(IToastNotification ToastNotification, INotyfService Notify)
        {
            _ToastNotification = ToastNotification;
        }

        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IDocumentSaveHandler handler)
        {
            if (request.Entity.DocTotal > 0)
            {
                request.Entity.DocTotal = null;
            }
            foreach (var line in request.Entity.DocumentLines)
            {
                if (line.LineTotal > 0)
                {
                    line.LineTotal = null;
                }
            }
            /*if (!String.IsNullOrEmpty(request.Entity.AttachmentEntry))
            {
                CommonFunctions Common = new CommonFunctions(Context);
                request.Entity.AttachmentEntry = Common.PostAttachment(request.Entity.AttachmentEntry, 1);
            }*/
            request.Entity.U_ApprovalGUID = Guid.NewGuid().ToString();
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            var Res = helper.CreateInSAP(request);

            //helper.RefreshFromSAPPAS();
            var Dic = new Dictionary<string, object>();
            Dic = Res.CustomData;
            if (Dic != null)
            {
                var Result = Dic["Approval"];
                if ((bool)Result)
                {
                    _ToastNotification.AddSuccessToastMessage("The Document is Successfully Posted for Approval...!");
                }
            }

            return Res;
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IDocumentSaveHandler handler)
        {
            if (request.Entity.DocTotal > 0)
            {
                request.Entity.DocTotal = null;
            }
      
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            //
            return helper.UpdateInSAP(request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IDocumentDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.DeleteInSAP(request);
        }
        public bool CheckStatus(MyRow myrow)
        {

            bool flag = false;
            var docdate = DateTime.Now - (DateTime)myrow.DocDate;
            var hrs = docdate.TotalHours;
            if (hrs <= 24)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            return flag;

        }
        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IDocumentRetrieveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.RetrieveFromSAP(request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IDocumentListHandler handler)
        {
            //_Notify.Success("The Document is Successfully Posted for Approval...!", 20);
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DataSourceType = DataSourceType.SAP_DataBase;
            var a = helper.List(request);

            return a;
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IDocumentListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.DocumentColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "DocumentList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }

        public JsonResult getItemNameFromItemCode(ApiData ItemCode)
        {

            var itemcode = ItemCode.Code;
            var DBName = ItemCode.DBName;
            var Result = "";

            //get itemname on iem code from ocrd via query 
            var query = @"select ""ItemName"" from OITM where ""ItemCode""  = '" + itemcode + "'";
            //execute query with db helper
            using (var reader = DBHelper.DoQuery(query))
            {

                while (reader.Read())
                {
                    Result = reader["ItemName"].ToString();
                }
            }

            return Json(Result);

        }
        public JsonResult GetNextNumber(ApiData data)
        {
            return Json(SAPHelper<MyRow>.GetMarketingNextNumber(data));
        }
        public JsonResult getAddress(string CardCode)
        {
            System.Collections.Generic.List<SelectListItem> result = new System.Collections.Generic.List<SelectListItem>();
            result.Clear();
            string Address = "";
            try
            {
                var query = String.Format(DBHelper.GetQuery("Address"), CardCode);
                using (var reader = DBHelper.DoQuery(query))
                {

                    while (reader.Read())
                    {
                        result.Add(new SelectListItem { Text = reader["U_Address"].ToString(), Value = reader["U_Address"].ToString() });
                    }

                    //if (reader.Read())
                    //{

                    //    Address = reader["U_Address"].ToString();
                    //}
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { Address };
            return Json(result);
        }
        public JsonResult getPaymentGroup(string CardCode)
        {
            string PymentGroup = "";
            try
            {
                var query = String.Format(DBHelper.GetQuery("Query_59"), CardCode);
                using (var reader = DBHelper.DoQuery(query))
                {
                    if (reader.Read())
                    {
                        PymentGroup = reader["PymntGroup"].ToString();
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { PymentGroup };
            return Json(res);
        }
        public JsonResult getDiscount(string CardCode)
        {
            string Discount = "";
            try
            {
                var query = String.Format(DBHelper.GetQuery("Discount"), CardCode);
                using (var reader = DBHelper.DoQuery(query))
                {
                    if (reader.Read())
                    {
                        Discount = reader["Discount"].ToString();
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { Discount };
            return Json(res);
        }
        public JsonResult GetCodeNameValues(CodeNameValuesInputParams row)
        {
            return Json(SAPHelper<MyRow>.GetListFromQuery(row.row, row.propertyNameSAP,""));
        }
        public JsonResult getTaxDetail(string TaxCode)
        {
            double Rate = 0;
            try
            {
                var query = String.Format(DBHelper.GetQuery("Query_52"), TaxCode);
                using (var reader = DBHelper.DoQuery(query))
                {
                    if (reader.Read())
                    {
                        Rate = Convert.ToDouble(reader["Rate"].ToString());
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { Rate };
            return Json(res);
        }
        public JsonResult GetUdfs(string CardCode)
        {
            double CreditLine = 0.0;
            double OrderBal = 0.0;
            double Balance = 0.0;
            double TempBal = 0.0;
            double CreditLimit = 0.0;
            double BAL = 0.0;
            double RemainingLimit = 0.0;

            try
            {

                var query = String.Format(DBHelper.GetQuery("Query_62"), CardCode);
                using (var reader = DBHelper.DoQuery(query))
                {//get companydb 


                    if (reader.Read())
                    {
                        CreditLine = Convert.ToDouble(reader["CreditLine"].ToString());
                        OrderBal = Convert.ToDouble(reader["OrdersBal"].ToString());
                        Balance = Convert.ToDouble(reader["Balance"].ToString());
                        TempBal = Convert.ToDouble(reader["U_TEMP"].ToString());

                    }
                    CreditLimit = CreditLine;
                    BAL = OrderBal + Balance;
                    RemainingLimit = CreditLimit + TempBal - BAL;

                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { CreditLimit, BAL, RemainingLimit };
            return Json(res);
        }
        public RetrieveResponse<MyRow> GetDownloadFile( IDbConnection connection, SaveRequest<MyRow> request)
        {
            RetrieveResponse<MyRow> res = new RetrieveResponse<MyRow>();
            try
            {
                res.Entity = new MyRow();
                var username = Context.User.Identity.Name;
                var title = request.Entity.FederalTaxId;
                var comp = SapDatabasesController.Row;
                var dt = DateTime.Now.ToFileTime();
                var ReportFilePath = HttpUtility.UrlEncode(FileRoutingController.GetReportFilePath(13, comp.CompanyDb));
                var fname = FileRoutingController.GetExportPath(13, comp.CompanyDb);
                var pdfPath = HttpUtility.UrlEncode(fname);
                JsonData jdata = new JsonData() { rptPath = ReportFilePath, DocEntry = Convert.ToInt32(request.Entity.DocEntry), ObjectCode = 13, ServerName = comp.ODBCServer, CompanyDB = comp.CompanyDb, DBUserName = comp.DbUserName, DBPassword = AES.DecryptString(comp.DbPassword), pdfPath = pdfPath };
                FileRoutingController.callexe(JsonConvert.SerializeObject(jdata));
                res.Entity.Comments = GetBase64Strings(fname);
                res.Entity.AttachmentEntry = dt + ".pdf";
            }
            catch (Exception Ex)
            { 
                ExceptionsController.Log(Ex);
            }
            return res;
        }
        static String GetBase64Strings(String path)
        {   
            String base64Strings = "";
            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                String base64String = Convert.ToBase64String(bytes);
                base64Strings = (base64String);
                System.IO.File.Delete(path);
            }
            catch
            {
            }
            return base64Strings;
        }
    }
    public class CodeNameValuesInputParams
    {
        public MyRow row { get; set; }
        public string propertyNameSAP { get; set; }
    }
}