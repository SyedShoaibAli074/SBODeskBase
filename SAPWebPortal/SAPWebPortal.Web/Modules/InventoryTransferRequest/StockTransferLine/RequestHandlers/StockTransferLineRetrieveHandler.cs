using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.InventoryTransferRequest.StockTransferLineRow>;
using MyRow = SAPWebPortal.InventoryTransferRequest.StockTransferLineRow;

namespace SAPWebPortal.InventoryTransferRequest
{
    public interface IStockTransferLineRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class StockTransferLineRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IStockTransferLineRetrieveHandler
    {
        public StockTransferLineRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}