using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ShopifySettingsDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ShopifySettingsDetailRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySettingsDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySettingsDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySettingsDetailSaveHandler
    {
        public ShopifySettingsDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}