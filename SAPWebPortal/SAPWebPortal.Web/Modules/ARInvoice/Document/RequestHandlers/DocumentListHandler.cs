using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.ARInvoice.DocumentRow>;
using MyRow = SAPWebPortal.ARInvoice.DocumentRow;

namespace SAPWebPortal.ARInvoice
{
    public interface IDocumentListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentListHandler
    {
        public DocumentListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}