using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ItemWarehouseInfoCollectionRow;

namespace SAPWebPortal.Default
{
    public interface IItemWarehouseInfoCollectionDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ItemWarehouseInfoCollectionDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IItemWarehouseInfoCollectionDeleteHandler
    {
        public ItemWarehouseInfoCollectionDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}