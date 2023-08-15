using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ApprovalRequestDecisionRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ApprovalRequestDecisionRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestDecisionSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestDecisionSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestDecisionSaveHandler
    {
        public ApprovalRequestDecisionSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}