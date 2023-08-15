using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ShopifySettingsDetailRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySettingsDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySettingsDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySettingsDetailDeleteHandler
    {
        public ShopifySettingsDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}