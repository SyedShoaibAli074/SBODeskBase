using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ItemWarehouseInfoCollectionRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ItemWarehouseInfoCollectionRow;

namespace SAPWebPortal.Default
{
    public interface IItemWarehouseInfoCollectionSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ItemWarehouseInfoCollectionSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IItemWarehouseInfoCollectionSaveHandler
    {
        public ItemWarehouseInfoCollectionSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}