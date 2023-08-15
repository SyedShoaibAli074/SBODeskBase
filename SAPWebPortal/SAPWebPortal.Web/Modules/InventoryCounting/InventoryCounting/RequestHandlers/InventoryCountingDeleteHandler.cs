using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.InventoryCounting.InventoryCountingRow;

namespace SAPWebPortal.InventoryCounting
{
    public interface IInventoryCountingDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class InventoryCountingDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IInventoryCountingDeleteHandler
    {
        public InventoryCountingDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}