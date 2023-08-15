using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.IncomingPayment.PaymentInvoiceRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentInvoiceRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentInvoiceRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentInvoiceRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentInvoiceRetrieveHandler
    {
        public PaymentInvoiceRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}