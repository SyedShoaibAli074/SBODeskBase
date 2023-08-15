using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.OrdersExpense.DocumentAdditionalExpenseRow>;
using MyRow = SAPWebPortal.OrdersExpense.DocumentAdditionalExpenseRow;

namespace SAPWebPortal.OrdersExpense
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