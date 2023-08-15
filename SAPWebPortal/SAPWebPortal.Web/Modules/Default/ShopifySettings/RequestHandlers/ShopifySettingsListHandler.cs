using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ShopifySettingsRow>;
using MyRow = SAPWebPortal.Default.ShopifySettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySettingsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySettingsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySettingsListHandler
    {
        public ShopifySettingsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}