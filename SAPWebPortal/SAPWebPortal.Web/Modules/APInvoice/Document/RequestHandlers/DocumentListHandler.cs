using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.APInvoice.DocumentRow>;
using MyRow = SAPWebPortal.APInvoice.DocumentRow;

namespace SAPWebPortal.APInvoice
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