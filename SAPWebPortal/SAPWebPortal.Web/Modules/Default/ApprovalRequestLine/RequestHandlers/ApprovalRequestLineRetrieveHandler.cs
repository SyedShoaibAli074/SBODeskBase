using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ApprovalRequestLineRow>;
using MyRow = SAPWebPortal.Default.ApprovalRequestLineRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestLineRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestLineRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestLineRetrieveHandler
    {
        public ApprovalRequestLineRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}