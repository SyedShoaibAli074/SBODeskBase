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
using MyRow = SAPWebPortal.IncomingPayment.PaymentInvoiceRow;

namespace SAPWebPortal.IncomingPayment.Endpoints
{
    [Route("Services/IncomingPayment/PaymentInvoice/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class PaymentInvoiceController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IPaymentInvoiceSaveHandler handler)
        {
           SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
           return helper.CreateInSAP(request); 
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IPaymentInvoiceSaveHandler handler)
        { 
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.UpdateInSAP(request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IPaymentInvoiceDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.DeleteInSAP(request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IPaymentInvoiceRetrieveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.RetrieveFromSAP(request); 
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IPaymentInvoiceListHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.List(request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IPaymentInvoiceListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.PaymentInvoiceColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "PaymentInvoiceList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
    }
}