using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.DeliveryLine.DocumentLineRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.DeliveryLine.DocumentLineRow;

namespace SAPWebPortal.DeliveryLine
{
    public interface IDocumentLineSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class DocumentLineSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IDocumentLineSaveHandler
    {
        public DocumentLineSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}