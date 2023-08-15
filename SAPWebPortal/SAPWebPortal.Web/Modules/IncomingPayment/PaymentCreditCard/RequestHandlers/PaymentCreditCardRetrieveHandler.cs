using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.IncomingPayment.PaymentCreditCardRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentCreditCardRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentCreditCardRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentCreditCardRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentCreditCardRetrieveHandler
    {
        public PaymentCreditCardRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}