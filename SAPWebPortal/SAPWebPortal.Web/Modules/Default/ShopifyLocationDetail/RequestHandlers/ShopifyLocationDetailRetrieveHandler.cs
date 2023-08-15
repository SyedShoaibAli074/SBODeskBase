using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ShopifyLocationDetailRow>;
using MyRow = SAPWebPortal.Default.ShopifyLocationDetailRow;

namespace SAPWebPortal.Default
{
    public interface IShopifyLocationDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifyLocationDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IShopifyLocationDetailRetrieveHandler
    {
        public ShopifyLocationDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}