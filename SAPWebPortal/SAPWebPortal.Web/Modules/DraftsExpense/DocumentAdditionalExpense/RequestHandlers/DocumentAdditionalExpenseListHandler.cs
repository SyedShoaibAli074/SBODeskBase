using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.DraftsExpense.DocumentAdditionalExpenseRow>;
using MyRow = SAPWebPortal.DraftsExpense.DocumentAdditionalExpenseRow;

namespace SAPWebPortal.DraftsExpense
{
    public interface IDocumentAdditionalExpenseListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentAdditionalExpenseListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentAdditionalExpenseListHandler
    {
        public DocumentAdditionalExpenseListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}