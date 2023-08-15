using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ApprovalRequestRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestDeleteHandler
    {
        public ApprovalRequestDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}