using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.IncomingPayment.PaymentRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.IncomingPayment.PaymentRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentSaveHandler
    {
        public PaymentSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}