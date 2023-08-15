using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.IncomingPayment.PaymentCheckRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentCheckRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentCheckSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentCheckSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentCheckSaveHandler
    {
        public PaymentCheckSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}