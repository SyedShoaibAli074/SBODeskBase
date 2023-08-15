using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.IncomingPayment.PaymentAccountRow>;
using MyRow = SAPWebPortal.IncomingPayment.PaymentAccountRow;

namespace SAPWebPortal.IncomingPayment
{
    public interface IPaymentAccountListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class PaymentAccountListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IPaymentAccountListHandler
    {
        public PaymentAccountListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}