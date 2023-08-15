using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.APInvoiceLine.DocumentLineRow>;
using MyRow = SAPWebPortal.APInvoiceLine.DocumentLineRow;

namespace SAPWebPortal.APInvoiceLine
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