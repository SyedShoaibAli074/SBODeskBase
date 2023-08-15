using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.ARInvoiceLine.DocumentLineRow>;
using MyRow = SAPWebPortal.ARInvoiceLine.DocumentLineRow;

namespace SAPWebPortal.ARInvoiceLine
{
    public interface IDocumentLineRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentLineRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentLineRetrieveHandler
    {
        public DocumentLineRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}