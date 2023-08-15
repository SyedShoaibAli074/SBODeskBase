using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.SapToShopifySyncLogRow>;
using MyRow = SAPWebPortal.Default.SapToShopifySyncLogRow;

namespace SAPWebPortal.Default
{
    public interface ISapToShopifySyncLogListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SapToShopifySyncLogListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISapToShopifySyncLogListHandler
    {
        public SapToShopifySyncLogListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}