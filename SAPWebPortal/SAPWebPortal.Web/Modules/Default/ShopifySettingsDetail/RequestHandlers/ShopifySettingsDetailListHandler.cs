using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ShopifySettingsDetailRow>;
using MyRow = SAPWebPortal.Default.ShopifySettingsDetailRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySettingsDetailListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySettingsDetailListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySettingsDetailListHandler
    {
        public ShopifySettingsDetailListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}