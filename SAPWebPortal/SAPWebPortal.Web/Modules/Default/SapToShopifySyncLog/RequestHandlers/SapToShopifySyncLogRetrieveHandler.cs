using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.SapToShopifySyncLogRow>;
using MyRow = SAPWebPortal.Default.SapToShopifySyncLogRow;

namespace SAPWebPortal.Default
{
    public interface ISapToShopifySyncLogRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SapToShopifySyncLogRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISapToShopifySyncLogRetrieveHandler
    {
        public SapToShopifySyncLogRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}