using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.InventoryTransferRequest.StockTransferLineRow;

namespace SAPWebPortal.InventoryTransferRequest
{
    public interface IStockTransferLineDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class StockTransferLineDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IStockTransferLineDeleteHandler
    {
        public StockTransferLineDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}