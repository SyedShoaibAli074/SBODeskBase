using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ItemWarehouseInfoCollectionRow>;
using MyRow = SAPWebPortal.Default.ItemWarehouseInfoCollectionRow;

namespace SAPWebPortal.Default
{
    public interface IItemWarehouseInfoCollectionRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ItemWarehouseInfoCollectionRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IItemWarehouseInfoCollectionRetrieveHandler
    {
        public ItemWarehouseInfoCollectionRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}