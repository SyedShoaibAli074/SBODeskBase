using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ShopifySubSettingsRow>;
using MyRow = SAPWebPortal.Default.ShopifySubSettingsRow;

namespace SAPWebPortal.Default
{
    public interface IShopifySubSettingsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifySubSettingsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IShopifySubSettingsRetrieveHandler
    {
        public ShopifySubSettingsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}