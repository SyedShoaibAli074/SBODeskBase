using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ShopifyLocationDetailRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ShopifyLocationDetailRow;

namespace SAPWebPortal.Default
{
    public interface IShopifyLocationDetailSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifyLocationDetailSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IShopifyLocationDetailSaveHandler
    {
        public ShopifyLocationDetailSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}