using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.DraftsExpense.DocumentAdditionalExpenseRow;

namespace SAPWebPortal.DraftsExpense
{
    public interface IDocumentAdditionalExpenseDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentAdditionalExpenseDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentAdditionalExpenseDeleteHandler
    {
        public DocumentAdditionalExpenseDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}