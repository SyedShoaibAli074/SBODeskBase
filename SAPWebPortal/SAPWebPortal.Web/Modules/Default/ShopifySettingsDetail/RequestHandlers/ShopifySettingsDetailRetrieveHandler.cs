using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ShopifySettingsDetailRow>;
using MyRow = SAPWebPortal.Default.ShopifySettingsDetailRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySettingsDetailRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySettingsDetailRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySettingsDetailRetrieveHandler
    {
        public ShopifySettingsDetailRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}