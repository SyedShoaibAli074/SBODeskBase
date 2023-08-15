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
using MyRow = SAPWebPortal.Default.BPPaymentMethodsRow;

namespace SAPWebPortal.Default.Endpoints
{
    [Route("Services/Default/BPPaymentMethods/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class BPPaymentMethodsController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBPPaymentMethodsSaveHandler handler)
        {
            return handler.Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IBPPaymentMethodsSaveHandler handler)
        {

            return handler.Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IBPPaymentMethodsDeleteHandler handler)
        {
            return handler.Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IBPPaymentMethodsRetrieveHandler handler)
        {
            return handler.Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IBPPaymentMethodsListHandler handler)
        {
            
            return handler.List(connection, request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IBPPaymentMethodsListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.BPPaymentMethodsColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "BPPaymentMethodsList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        public JsonResult GetCodeNameValues(CodeNameValuesInputParam row)
        {
            return Json(SAPHelper<MyRow>.GetListFromQuery(row.row, row.propertyNameSAP, row.row.DBName));
        }
    }
    public class CodeNameValuesInputParam
    {
        public MyRow row { get; set; }
        public string propertyNameSAP { get; set; }
    }
}