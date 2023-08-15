using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ItemWarehouseInfoCollectionRow>;
using MyRow = SAPWebPortal.Default.ItemWarehouseInfoCollectionRow;

namespace SAPWebPortal.Default
{
    public interface IItemWarehouseInfoCollectionListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ItemWarehouseInfoCollectionListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IItemWarehouseInfoCollectionListHandler
    {
        public ItemWarehouseInfoCollectionListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}