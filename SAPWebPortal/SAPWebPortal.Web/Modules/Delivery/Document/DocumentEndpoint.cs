using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Web.Helpers;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.Delivery.DocumentRow;
using SAPWebPortal.Web.Models.SLModels;

namespace SAPWebPortal.Delivery.Endpoints
{
    [Route("Services/Delivery/Document/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class DocumentController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IDocumentSaveHandler handler)
        {
            request.DBName = request.Entity.DBName;

            if (!String.IsNullOrEmpty(request.Entity.AttachmentEntry))
            {
                CommonFunctions<MyRow> Common = new CommonFunctions<MyRow>(Context);
                request.Entity.AttachmentEntry = Common.PostAttachment(request,request.Entity.AttachmentEntry, 1);
            }
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            var result =  helper.CreateInSAP(request);
            //helper.RefreshFromSAPPAS();
            return result;
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IDocumentSaveHandler handler)
        { 
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
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            request.DataSourceType = DataSourceType.SAP_DataBase;
            return helper.List(request);
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
        public JsonResult GetCodeNameValues(CodeNameValuesInputParams row)
        {
            return Json(SAPHelper<MyRow>.GetListFromQuery(row.row, row.propertyNameSAP, row.row.DBName));
        }
        public JsonResult getTaxDetail(ApiData TaxCode)
        {
            var _TaxCode = TaxCode.Code;
            var DBName = TaxCode.DBName;

            double Rate = 0;
            try
            {
                var query = String.Format(DBHelper.GetQuery("Query_52",DBName), _TaxCode);
                using (var reader = DBHelper.DoQuery(query,DBName))
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
     
    }
    public class CodeNameValuesInputParams
    {
        public MyRow row { get; set; }
        public string propertyNameSAP { get; set; }
    }
}