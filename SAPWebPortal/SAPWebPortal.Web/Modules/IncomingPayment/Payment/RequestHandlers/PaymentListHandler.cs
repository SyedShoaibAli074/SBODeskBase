using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.IncomingPayment.PaymentRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentListHandler
    {
        public PaymentListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}