using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.InventoryTransferRequest.StockTransferLineRow>;
using MyRow = SAPWebPortal.InventoryTransferRequest.StockTransferLineRow;

namespace SAPWebPortal.InventoryTransferRequest
{
    public interface IStockTransferLineListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class StockTransferLineListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IStockTransferLineListHandler
    {
        public StockTransferLineListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}