using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ShopifyWebkookSettingsRow>;
using MyRow = SAPWebPortal.Default.ShopifyWebkookSettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifyWebkookSettingsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifyWebkookSettingsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IShopifyWebkookSettingsListHandler
    {
        public ShopifyWebkookSettingsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}