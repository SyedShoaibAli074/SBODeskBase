using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentDeleteHandler
    {
        public PaymentDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}