using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.APInvoice.DocumentRow;

namespace SAPWebPortal.APInvoice
{
    public interface IDocumentDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentDeleteHandler
    {
        public DocumentDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}