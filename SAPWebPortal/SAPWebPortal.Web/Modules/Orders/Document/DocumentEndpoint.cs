﻿using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Web.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.Orders.DocumentRow;
using SAPWebPortal.Web.Modules.Common.Helpers;
using System.Collections.Generic;
using NToastNotify;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Administration.Endpoints;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;
using SAPWebPortal.Web.Models.SLModels;

namespace SAPWebPortal.Orders.Endpoints
{
    [Route("Services/Orders/Document/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class DocumentController : ServiceEndpoint,IDataDictionary
    {
        //implement IDataDictionary

        public void FillDataDictionary(string username, string password, string companyDB)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            
            helper.FillDataDictionary(username, password, companyDB);
        }
        public JsonResult getItemNameFromItemCode(ApiData ItemCode)
        {
            
            var itemcode = ItemCode.Code;
            var DBName = ItemCode.DBName;
            var Result = "";

            //get itemname on iem code from ocrd via query 
            var query = @"select ""ItemName"" from OITM where ""ItemCode""  = '" + itemcode + "'";
            //execute query with db helper
            using (var reader = DBHelper.DoQuery(query,DBName))
            {

                while (reader.Read())
                {
                    Result=reader["ItemName"].ToString();
                }
            }

                return Json(Result);

        }
        public System.Collections.Generic.List<(string username, string dbname, string modlulename, int totalcount)> GetAllDataDictionary()
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.GetAllDataDictionary();
        }
        // private readonly INotyfService _Notify;
        private readonly IToastNotification _ToastNotification;
        public DocumentController(IToastNotification ToastNotification, INotyfService Notify)
        {
            
            _ToastNotification = ToastNotification;
            //_Notify = Notify;
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
            
            request.DBName = request.Entity.DBName;

            if (!String.IsNullOrEmpty(request.Entity.AttachmentEntry))
            {
                CommonFunctions<MyRow> Common = new CommonFunctions<MyRow>(Context);
                request.Entity.AttachmentEntry = Common.PostAttachment(request,request.Entity.AttachmentEntry, 1);
            }
            //request.Entity.U_ApprovalGUID = Guid.NewGuid().ToString();
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
            foreach (var line in request.Entity.DocumentLines)
            {
                if (line.LineTotal > 0)
                {
                    line.LineTotal = null;
                }
            }
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DBName = request.Entity.DBName;

            return helper.UpdateInSAP(request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IDocumentDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.DeleteInSAP(request);
        }
        public bool CheckStatus (MyRow myrow) {

            bool flag = false;
            var docdate =DateTime.Now - (DateTime)myrow.DocDate;
            var hrs=docdate.TotalHours;
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
            var a =  helper.List(request);
            
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
        public JsonResult GetNextNumber(ApiData seriesid)
        {
            return Json(SAPHelper<MyRow>.GetMarketingNextNumber(seriesid));
        }
        public JsonResult getAddress(ApiData CardCode)
        {
            var CardCode1 = CardCode.Code;
            var DBName = CardCode.DBName;
            System.Collections.Generic.List<SelectListItem> result = new System.Collections.Generic.List<SelectListItem>();
            result.Clear();
            string Address = "";
            try
            {
                var query = String.Format(DBHelper.GetQuery("Address", DBName), CardCode1);
                using (var reader = DBHelper.DoQuery(query, DBName))
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
         public JsonResult getPaymentGroup(ApiData CardCode)
        {
            var CardCode1 = CardCode.Code;
            var DBName = CardCode.DBName;
            string PymentGroup = "";
            try
            {
                var query = String.Format(DBHelper.GetQuery("Query_59", DBName), CardCode1);
                using (var reader = DBHelper.DoQuery(query, DBName))
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
        public JsonResult getDiscount(ApiData CardCode)
        {
            var CardCode1 = CardCode.Code;
            var DBName = CardCode.DBName;
            string Discount = "";
            try
            {
                var query = String.Format(DBHelper.GetQuery("Discount", DBName), CardCode1);
                using (var reader = DBHelper.DoQuery(query, DBName))
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
            return Json(SAPHelper<MyRow>.GetListFromQuery(row.row, row.propertyNameSAP, row.row.DBName));
        }
        public JsonResult getTaxDetail(ApiData TaxCode)
        {
            double Rate = 0;
            try
            {
                var query = String.Format(DBHelper.GetQuery("Query_52",TaxCode.DBName), TaxCode.Code);
                using (var reader = DBHelper.DoQuery(query, TaxCode.DBName))
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

        public RetrieveResponse<MyRow> GetDownloadFile(IDbConnection connection, SaveRequest<MyRow> request)
        {
            RetrieveResponse<MyRow> res = new RetrieveResponse<MyRow>();
            try
            {
                res.Entity = new MyRow();
                var username = Context.User.Identity.Name;
                var comp = SapDatabasesController.SAPRow(request.Entity.DBName); 
                var dt = DateTime.Now.ToFileTime();
                var ReportFilePath = HttpUtility.UrlEncode(FileRoutingController.GetReportFilePath(17, ServiceLayerRestHandler.SessionDictionary[Context.User.Identity.Name].company));
                var fname = FileRoutingController.GetExportPath(17, ServiceLayerRestHandler.SessionDictionary[Context.User.Identity.Name].company);
                var pdfPath = HttpUtility.UrlEncode(fname);
                JsonData jdata = new JsonData() { rptPath = ReportFilePath, DocEntry = Convert.ToInt32(request.Entity.DocEntry), ObjectCode = 17, ServerName = comp.ODBCServer, CompanyDB = comp.CompanyDb, DBUserName = comp.DbUserName, DBPassword = AES.DecryptString(comp.DbPassword), pdfPath = pdfPath };
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