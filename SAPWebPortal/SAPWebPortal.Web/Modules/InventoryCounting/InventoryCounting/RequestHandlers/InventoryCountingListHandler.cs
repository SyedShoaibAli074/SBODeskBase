using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.InventoryCounting.InventoryCountingRow>;
using MyRow = SAPWebPortal.InventoryCounting.InventoryCountingRow;

namespace SAPWebPortal.InventoryCounting
{
    public interface IInventoryCountingListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class InventoryCountingListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IInventoryCountingListHandler
    {
        public InventoryCountingListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}