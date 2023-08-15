using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.BPPaymentMethodsRow;

namespace SAPWebPortal.Default
{
    public interface IBPPaymentMethodsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class BPPaymentMethodsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IBPPaymentMethodsDeleteHandler
    {
        public BPPaymentMethodsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}