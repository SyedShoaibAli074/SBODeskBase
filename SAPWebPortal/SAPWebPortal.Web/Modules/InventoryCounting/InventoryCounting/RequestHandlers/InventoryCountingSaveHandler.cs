using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.InventoryCounting.InventoryCountingRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.InventoryCounting.InventoryCountingRow;

namespace SAPWebPortal.InventoryCounting
{
    public interface IInventoryCountingSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class InventoryCountingSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IInventoryCountingSaveHandler
    {
        public InventoryCountingSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}