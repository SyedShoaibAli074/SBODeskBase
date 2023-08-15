using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.IncomingPayment.PaymentCreditCardRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentCreditCardRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentCreditCardSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentCreditCardSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentCreditCardSaveHandler
    {
        public PaymentCreditCardSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}