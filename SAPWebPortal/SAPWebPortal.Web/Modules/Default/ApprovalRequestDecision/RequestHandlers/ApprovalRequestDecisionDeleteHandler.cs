using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ApprovalRequestDecisionRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestDecisionDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestDecisionDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestDecisionDeleteHandler
    {
        public ApprovalRequestDecisionDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}