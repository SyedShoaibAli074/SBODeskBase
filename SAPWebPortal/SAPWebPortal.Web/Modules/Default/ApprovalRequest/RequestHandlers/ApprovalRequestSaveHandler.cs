using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ApprovalRequestRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ApprovalRequestRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestSaveHandler
    {
        public ApprovalRequestSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}