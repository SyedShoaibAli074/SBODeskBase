using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ApprovalRequestDecisionRow>;
using MyRow = SAPWebPortal.Default.ApprovalRequestDecisionRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestDecisionRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestDecisionRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestDecisionRetrieveHandler
    {
        public ApprovalRequestDecisionRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}