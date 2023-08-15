using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.QuotationsExpense.DocumentAdditionalExpenseRow>;
using MyRow = SAPWebPortal.QuotationsExpense.DocumentAdditionalExpenseRow;

namespace SAPWebPortal.QuotationsExpense
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