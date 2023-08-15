using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.ARInvoice.DocumentRow>;
using MyRow = SAPWebPortal.ARInvoice.DocumentRow;

namespace SAPWebPortal.ARInvoice
{
    public interface IDocumentRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentRetrieveHandler
    {
        public DocumentRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}