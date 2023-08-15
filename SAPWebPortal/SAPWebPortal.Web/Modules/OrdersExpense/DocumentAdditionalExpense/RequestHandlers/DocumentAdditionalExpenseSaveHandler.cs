using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.OrdersExpense.DocumentAdditionalExpenseRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.OrdersExpense.DocumentAdditionalExpenseRow;

namespace SAPWebPortal.OrdersExpense
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