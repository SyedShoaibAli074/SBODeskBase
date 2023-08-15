using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.InventoryCounting.InventoryCountingLineRow;

namespace SAPWebPortal.InventoryCounting
{
    public interface IInventoryCountingLineDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class InventoryCountingLineDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IInventoryCountingLineDeleteHandler
    {
        public InventoryCountingLineDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}