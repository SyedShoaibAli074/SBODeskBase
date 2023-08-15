using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentAccountRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentAccountDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentAccountDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentAccountDeleteHandler
    {
        public PaymentAccountDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}