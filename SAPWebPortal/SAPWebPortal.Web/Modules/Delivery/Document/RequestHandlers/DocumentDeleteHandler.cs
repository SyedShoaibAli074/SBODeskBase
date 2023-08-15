using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Delivery.DocumentRow;

namespace SAPWebPortal.Delivery
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