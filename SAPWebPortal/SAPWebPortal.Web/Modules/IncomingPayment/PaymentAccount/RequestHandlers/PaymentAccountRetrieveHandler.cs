using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.IncomingPayment.PaymentAccountRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentAccountRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentAccountRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentAccountRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentAccountRetrieveHandler
    {
        public PaymentAccountRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}