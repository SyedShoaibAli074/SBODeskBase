using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Quotations.DocumentRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Quotations.DocumentRow;

namespace SAPWebPortal.Quotations
{
    public interface IDocumentSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentSaveHandler
    {
        public DocumentSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}