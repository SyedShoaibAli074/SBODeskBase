using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.InventoryTransferRequest.StockTransferLineRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.InventoryTransferRequest.StockTransferLineRow;

namespace SAPWebPortal.InventoryTransferRequest
{
    public interface IStockTransferLineSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class StockTransferLineSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IStockTransferLineSaveHandler
    {
        public StockTransferLineSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}