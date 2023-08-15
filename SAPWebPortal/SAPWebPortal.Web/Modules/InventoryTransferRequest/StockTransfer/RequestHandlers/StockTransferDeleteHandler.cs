using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.InventoryTransferRequest.StockTransferRow;

namespace SAPWebPortal.InventoryTransferRequest
{
    public interface IStockTransferDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class StockTransferDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IStockTransferDeleteHandler
    {
        public StockTransferDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}