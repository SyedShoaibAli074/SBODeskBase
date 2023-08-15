using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ShopifyLocationDetailRow>;
using MyRow = SAPWebPortal.Default.ShopifyLocationDetailRow;

namespace SAPWebPortal.Default
{
    public interface IShopifyLocationDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifyLocationDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IShopifyLocationDetailListHandler
    {
        public ShopifyLocationDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}