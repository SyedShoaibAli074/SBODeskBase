using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ShopifySubSettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySubSettingsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySubSettingsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySubSettingsDeleteHandler
    {
        public ShopifySubSettingsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}