using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ApprovalRequestRow>;
using MyRow = SAPWebPortal.Default.ApprovalRequestRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestRetrieveHandler
    {
        public ApprovalRequestRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}