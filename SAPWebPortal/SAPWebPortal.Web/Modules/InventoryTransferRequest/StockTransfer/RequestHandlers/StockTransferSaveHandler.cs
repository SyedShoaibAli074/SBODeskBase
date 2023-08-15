using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.InventoryTransferRequest.StockTransferRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.InventoryTransferRequest.StockTransferRow;

namespace SAPWebPortal.InventoryTransferRequest
{
    public interface IStockTransferSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class StockTransferSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IStockTransferSaveHandler
    {
        public StockTransferSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}