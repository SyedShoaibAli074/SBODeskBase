using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.IncomingPayment.PaymentInvoiceRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentInvoiceRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentInvoiceSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentInvoiceSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentInvoiceSaveHandler
    {
        public PaymentInvoiceSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}