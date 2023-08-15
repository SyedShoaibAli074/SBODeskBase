using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.BPPaymentMethodsRow>;
using MyRow = SAPWebPortal.Default.BPPaymentMethodsRow;

namespace SAPWebPortal.Default
{
    public interface IBPPaymentMethodsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class BPPaymentMethodsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IBPPaymentMethodsRetrieveHandler
    {
        public BPPaymentMethodsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}