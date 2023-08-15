using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Orders.DocumentRow>;
using MyRow = SAPWebPortal.Orders.DocumentRow;

namespace SAPWebPortal.Orders
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