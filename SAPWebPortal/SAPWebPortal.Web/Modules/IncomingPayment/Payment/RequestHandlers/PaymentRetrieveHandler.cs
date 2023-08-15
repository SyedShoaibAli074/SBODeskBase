using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.IncomingPayment.PaymentRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentRetrieveHandler
    {
        public PaymentRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}