using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ApprovalRequestLineRow;

namespace SAPWebPortal.Default
{
    public interface IApprovalRequestLineDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ApprovalRequestLineDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IApprovalRequestLineDeleteHandler
    {
        public ApprovalRequestLineDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}