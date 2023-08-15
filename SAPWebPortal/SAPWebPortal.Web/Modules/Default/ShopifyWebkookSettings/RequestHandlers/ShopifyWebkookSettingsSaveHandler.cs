using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ShopifyWebkookSettingsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ShopifyWebkookSettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifyWebkookSettingsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifyWebkookSettingsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IShopifyWebkookSettingsSaveHandler
    {
        public ShopifyWebkookSettingsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}