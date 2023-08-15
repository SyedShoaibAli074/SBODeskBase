using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.InventoryTransferRequest.StockTransferRow>;
using MyRow = SAPWebPortal.InventoryTransferRequest.StockTransferRow;

namespace SAPWebPortal.InventoryTransferRequest
{
    public interface IStockTransferRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class StockTransferRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IStockTransferRetrieveHandler
    {
        public StockTransferRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}