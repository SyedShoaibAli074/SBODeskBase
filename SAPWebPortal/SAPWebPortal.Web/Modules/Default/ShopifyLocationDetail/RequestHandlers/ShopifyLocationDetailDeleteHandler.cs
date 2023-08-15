using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ShopifyLocationDetailRow;

namespace SAPWebPortal.Default
{
    public interface IShopifyLocationDetailDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ShopifyLocationDetailDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IShopifyLocationDetailDeleteHandler
    {
        public ShopifyLocationDetailDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}