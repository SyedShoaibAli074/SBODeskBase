using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.InventoryCounting.InventoryCountingLineRow>;
using MyRow = SAPWebPortal.InventoryCounting.InventoryCountingLineRow;

namespace SAPWebPortal.InventoryCounting
{
    public interface IInventoryCountingLineListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class InventoryCountingLineListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IInventoryCountingLineListHandler
    {
        public InventoryCountingLineListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}