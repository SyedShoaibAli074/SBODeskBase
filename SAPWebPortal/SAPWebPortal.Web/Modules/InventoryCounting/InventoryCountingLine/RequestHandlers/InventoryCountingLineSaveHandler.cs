using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.InventoryCounting.InventoryCountingLineRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.InventoryCounting.InventoryCountingLineRow;

namespace SAPWebPortal.InventoryCounting
{
    public interface IInventoryCountingLineSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class InventoryCountingLineSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IInventoryCountingLineSaveHandler
    {
        public InventoryCountingLineSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}