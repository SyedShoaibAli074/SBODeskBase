using Microsoft.AspNetCore.Mvc;
using Serenity;

using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.Default.BusinessPartnerRow;
using SAPWebPortal.Web.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Serenity.Data;
using SAPWebPortal.Web.Modules.Common.Helpers;
using SAPWebPortal.Administration.Endpoints;

using SAPWebPortal.Administration;
using HelperWebSL.Models;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using NToastNotify;
using SAPWebPortal.Membership.Pages;
using _Ext;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using SAPWebPortal.Web.Models.SLModels;

namespace SAPWebPortal.Default.Endpoints
{
    [Route("Services/Default/BusinessPartner/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class BusinessPartnerController : ServiceEndpoint, IDataDictionary
    {
        private readonly IToastNotification _ToastNotification;
        private IHttpContextAccessor _httpContextAccessor;
        public BusinessPartnerController()
        {
           // _ToastNotification = ToastNotification;
        }
       
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBusinessPartnerSaveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);


            request.DBName=request.Entity.DBName;
            return helper.CreateInSAP(request);
        }
        // get GetCardCodeCardNameForAuth
        public System.Collections.Generic.List<(string CardCode, string CardName)> GetCardCodeCardNameForAuth(IDbConnection connection,object DBName)
        {
            var result = new System.Collections.Generic.List<(string CardCode, string CardName)>();
            result.Clear();
            var usercontroller = new UsersController(this.Context);
            var username = this.Context.User.Identity.Name;

            var companyname = DBName.ToString();
            var userdatil1 = new UserDetail1Controller(this.Context, companyname);
            string cardcodesCSV = userdatil1.GetCardCodesCSV(username);
            using(var connectionsap = DBHelper.GetDBConnection(companyname))
            {
            if(connectionsap.State != ConnectionState.Open)
                connectionsap.Open();
                var condition = string.Empty;

                if (!string.IsNullOrEmpty(cardcodesCSV))
                {
                    condition = $" and CardCode not in ({cardcodesCSV})";
                }
                var sql = $@"select ""CardCode"",""CardName"" from OCRD where ""CardType""='C' {condition} order by ""CardName""";
                var table = DBHelper.GetTableFromQuery(sql,connectionsap);
                foreach (System.Data.DataRow row in table.Rows)
                {
                    result.Add((row["CardCode"].ToString(), row["CardName"].ToString()));
                }
                connectionsap.Close();
            }
            return result;
        }
        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBusinessPartnerSaveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            //helper.RefreshFromSAPPAS();
            request.DBName = request.Entity.DBName;

            request.ReplaceCollectionsOnPatch = true;
            return helper.UpdateInSAP(request);
        }

        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IBusinessPartnerDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            
            return helper.DeleteInSAP(request);
        }
        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IBusinessPartnerRetrieveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.RetrieveFromSAP(request);
        }
        [HttpPost]
        public RetrieveResponse<MyRow> RetrieveSeries(IDbConnection connection, RetrieveRequest request,
            [FromServices] IBusinessPartnerRetrieveHandler handler)
        {

            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.RetrieveFromSAP(request);
        }
//ignore antiforgery token
[IgnoreAntiforgeryToken]
        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IBusinessPartnerListHandler handler)
        {
                SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
                request.DataSourceType = DataSourceType.SAP_DataBase;
            SqlConnection conn = new SqlConnection(Startup.connectionString); 

            return helper.List(request);
            //SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            //return helper.List(request); 
        }
        [HttpPost]
        public void RefreshFromSAPPAS(Object obj )
        {

            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            //helper.RefreshFromSAPPAS();
        }
        [HttpGet]
        public ListResponse<MyRow> GetAll()
        {
            ListResponse<MyRow> response = new ListResponse<MyRow>();
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            ListRequest request = new ListRequest();
            request.Criteria = new Criteria("CardType") == "C";
            response.Entities = new System.Collections.Generic.List<MyRow>();
            //take 1000000
            request.Skip = 0;
            request.Take = 1000000;
            var TotalCount = 0;

            request.DataSourceType = DataSourceType.SAP_DataBase;
            var list = helper.List(request);
            response.Entities.AddRange(list.Entities); 
            
            response.TotalCount = response.Entities.Count();
            return response;
        }
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IBusinessPartnerListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.BusinessPartnerColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "BusinessPartnerList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        public JsonResult GetSeries(string DocType)
        {
            var result = new System.Collections.Generic.List<SelectListItem>();
            result.Clear();

            result = SAPHelper<MyRow>.Getseries(DocType);
            return Json(result);
        }
        
        public JsonResult GetNextNumber(ApiData seriesid)
        {
            
            return Json(SAPHelper<MyRow>.GetNextNumber(seriesid));
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