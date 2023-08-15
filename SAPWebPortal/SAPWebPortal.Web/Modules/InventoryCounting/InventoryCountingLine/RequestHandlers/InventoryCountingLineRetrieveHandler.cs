using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.InventoryCounting.InventoryCountingLineRow>;
using MyRow = SAPWebPortal.InventoryCounting.InventoryCountingLineRow;

namespace SAPWebPortal.InventoryCounting
{
    public interface IInventoryCountingLineRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class InventoryCountingLineRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IInventoryCountingLineRetrieveHandler
    {
        public InventoryCountingLineRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}