using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.OrdersLine.DocumentLineRow>;
using MyRow = SAPWebPortal.OrdersLine.DocumentLineRow;

namespace SAPWebPortal.OrdersLine
{
    public interface IDocumentLineListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentLineListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentLineListHandler
    {
        public DocumentLineListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}