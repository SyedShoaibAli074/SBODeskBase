using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.InventoryTransferRequest.StockTransferRow>;
using MyRow = SAPWebPortal.InventoryTransferRequest.StockTransferRow;

namespace SAPWebPortal.InventoryTransferRequest
{
    public interface IStockTransferListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class StockTransferListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IStockTransferListHandler
    {
        public StockTransferListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}