using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentCreditCardRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentCreditCardDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentCreditCardDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentCreditCardDeleteHandler
    {
        public PaymentCreditCardDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}