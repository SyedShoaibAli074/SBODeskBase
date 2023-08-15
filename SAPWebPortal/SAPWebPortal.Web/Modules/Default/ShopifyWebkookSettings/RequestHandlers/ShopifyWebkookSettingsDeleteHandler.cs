using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ShopifyWebkookSettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifyWebkookSettingsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifyWebkookSettingsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IShopifyWebkookSettingsDeleteHandler
    {
        public ShopifyWebkookSettingsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}