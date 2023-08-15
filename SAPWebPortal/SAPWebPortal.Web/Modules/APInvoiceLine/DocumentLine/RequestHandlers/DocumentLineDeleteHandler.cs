using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.APInvoiceLine.DocumentLineRow;

namespace SAPWebPortal.APInvoiceLine
{
    public interface IDocumentLineDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentLineDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentLineDeleteHandler
    {
        public DocumentLineDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}