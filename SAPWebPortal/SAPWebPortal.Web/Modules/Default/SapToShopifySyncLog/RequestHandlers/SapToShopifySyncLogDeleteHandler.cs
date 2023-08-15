using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.SapToShopifySyncLogRow;

namespace SAPWebPortal.Default
{
    public interface ISapToShopifySyncLogDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SapToShopifySyncLogDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISapToShopifySyncLogDeleteHandler
    {
        public SapToShopifySyncLogDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}