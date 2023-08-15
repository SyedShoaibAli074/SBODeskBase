using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ApprovalRequestRow>;
using MyRow = SAPWebPortal.Default.ApprovalRequestRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestListHandler
    {
        public ApprovalRequestListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}