using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ShopifySubSettingsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ShopifySubSettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySubSettingsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySubSettingsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySubSettingsSaveHandler
    {
        public ShopifySubSettingsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}