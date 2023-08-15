using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.IncomingPayment.PaymentCheckRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentCheckRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentCheckRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentCheckRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentCheckRetrieveHandler
    {
        public PaymentCheckRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}