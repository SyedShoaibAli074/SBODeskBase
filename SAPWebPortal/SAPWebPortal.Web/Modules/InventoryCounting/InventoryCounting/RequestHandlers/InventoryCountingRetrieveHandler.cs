using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.InventoryCounting.InventoryCountingRow>;
using MyRow = SAPWebPortal.InventoryCounting.InventoryCountingRow;

namespace SAPWebPortal.InventoryCounting
{
    public interface IInventoryCountingRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class InventoryCountingRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IInventoryCountingRetrieveHandler
    {
        public InventoryCountingRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}