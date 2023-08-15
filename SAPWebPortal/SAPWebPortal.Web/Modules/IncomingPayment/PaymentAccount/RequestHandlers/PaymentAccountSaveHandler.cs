using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.IncomingPayment.PaymentAccountRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentAccountRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentAccountSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentAccountSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentAccountSaveHandler
    {
        public PaymentAccountSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}