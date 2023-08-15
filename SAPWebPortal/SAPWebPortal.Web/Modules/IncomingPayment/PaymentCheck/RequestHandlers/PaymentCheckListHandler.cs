using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.IncomingPayment.PaymentCheckRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentCheckRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentCheckListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentCheckListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentCheckListHandler
    {
        public PaymentCheckListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}