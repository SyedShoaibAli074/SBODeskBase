using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.IncomingPayment.PaymentInvoiceRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentInvoiceRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentInvoiceListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentInvoiceListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentInvoiceListHandler
    {
        public PaymentInvoiceListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}