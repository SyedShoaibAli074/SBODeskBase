using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentCheckRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentCheckDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentCheckDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentCheckDeleteHandler
    {
        public PaymentCheckDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}