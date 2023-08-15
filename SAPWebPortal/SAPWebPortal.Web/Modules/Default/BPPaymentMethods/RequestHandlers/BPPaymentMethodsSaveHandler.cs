using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.BPPaymentMethodsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.BPPaymentMethodsRow;

namespace SAPWebPortal.Default
{
    public interface IBPPaymentMethodsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class BPPaymentMethodsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IBPPaymentMethodsSaveHandler
    {
        public BPPaymentMethodsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}