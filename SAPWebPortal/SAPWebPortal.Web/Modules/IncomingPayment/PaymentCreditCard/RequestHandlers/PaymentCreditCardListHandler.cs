using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.IncomingPayment.PaymentCreditCardRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentCreditCardRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentCreditCardListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentCreditCardListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentCreditCardListHandler
    {
        public PaymentCreditCardListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}