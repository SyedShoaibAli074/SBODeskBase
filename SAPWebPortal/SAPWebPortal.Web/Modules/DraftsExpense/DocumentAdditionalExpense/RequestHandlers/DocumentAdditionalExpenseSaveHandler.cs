using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.DraftsExpense.DocumentAdditionalExpenseRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.DraftsExpense.DocumentAdditionalExpenseRow;

namespace SAPWebPortal.DraftsExpense
{
    public interface IDocumentAdditionalExpenseSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentAdditionalExpenseSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentAdditionalExpenseSaveHandler
    {
        public DocumentAdditionalExpenseSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}