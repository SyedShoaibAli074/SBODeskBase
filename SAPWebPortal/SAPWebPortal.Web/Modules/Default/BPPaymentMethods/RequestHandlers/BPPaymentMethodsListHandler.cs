using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.BPPaymentMethodsRow>;
using MyRow = SAPWebPortal.Default.BPPaymentMethodsRow;

namespace SAPWebPortal.Default
{
    public interface IBPPaymentMethodsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class BPPaymentMethodsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IBPPaymentMethodsListHandler
    {
        public BPPaymentMethodsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}