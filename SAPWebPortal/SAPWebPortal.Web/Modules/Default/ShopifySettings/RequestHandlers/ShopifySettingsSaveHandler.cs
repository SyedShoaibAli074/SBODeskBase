using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ShopifySettingsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ShopifySettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySettingsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySettingsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySettingsSaveHandler
    {
        public ShopifySettingsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}