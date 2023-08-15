using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ShopifySubSettingsRow>;
using MyRow = SAPWebPortal.Default.ShopifySubSettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySubSettingsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySubSettingsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySubSettingsListHandler
    {
        public ShopifySubSettingsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}