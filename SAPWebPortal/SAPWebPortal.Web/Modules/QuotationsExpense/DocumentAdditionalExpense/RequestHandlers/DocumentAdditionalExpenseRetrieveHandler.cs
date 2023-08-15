using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.QuotationsExpense.DocumentAdditionalExpenseRow>;
using MyRow = SAPWebPortal.QuotationsExpense.DocumentAdditionalExpenseRow;

namespace SAPWebPortal.QuotationsExpense
{
    public interface IDocumentAdditionalExpenseRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentAdditionalExpenseRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentAdditionalExpenseRetrieveHandler
    {
        public DocumentAdditionalExpenseRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}