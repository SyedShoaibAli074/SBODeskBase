using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ApprovalRequestLineRow>;
using MyRow = SAPWebPortal.Default.ApprovalRequestLineRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestLineListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestLineListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestLineListHandler
    {
        public ApprovalRequestLineListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}