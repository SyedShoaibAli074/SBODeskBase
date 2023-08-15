using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentInvoiceRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentInvoiceDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentInvoiceDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentInvoiceDeleteHandler
    {
        public PaymentInvoiceDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}