using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ShopifySettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySettingsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySettingsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySettingsDeleteHandler
    {
        public ShopifySettingsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}