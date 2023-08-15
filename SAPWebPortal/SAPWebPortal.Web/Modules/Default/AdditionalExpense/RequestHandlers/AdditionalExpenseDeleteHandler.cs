using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.AdditionalExpenseRow;

namespace SAPWebPortal.Default
{
    public interface IAdditionalExpenseDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class AdditionalExpenseDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IAdditionalExpenseDeleteHandler
    {
        public AdditionalExpenseDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}