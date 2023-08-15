using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ApprovalRequestDecisionRow>;
using MyRow = SAPWebPortal.Default.ApprovalRequestDecisionRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestDecisionListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestDecisionListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestDecisionListHandler
    {
        public ApprovalRequestDecisionListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}