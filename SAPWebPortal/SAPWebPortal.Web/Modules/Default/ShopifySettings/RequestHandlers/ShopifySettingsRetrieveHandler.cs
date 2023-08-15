using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ShopifySettingsRow>;
using MyRow = SAPWebPortal.Default.ShopifySettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySettingsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySettingsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySettingsRetrieveHandler
    {
        public ShopifySettingsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}