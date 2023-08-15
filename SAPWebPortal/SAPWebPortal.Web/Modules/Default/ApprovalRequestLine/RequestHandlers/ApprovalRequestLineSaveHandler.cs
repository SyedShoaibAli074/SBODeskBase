using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ApprovalRequestLineRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ApprovalRequestLineRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestLineSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestLineSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestLineSaveHandler
    {
        public ApprovalRequestLineSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}