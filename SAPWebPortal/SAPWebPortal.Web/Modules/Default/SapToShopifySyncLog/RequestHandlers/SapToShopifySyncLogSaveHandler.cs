using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.SapToShopifySyncLogRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.SapToShopifySyncLogRow;

namespace SAPWebPortal.Default
{
    public interface ISapToShopifySyncLogSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SapToShopifySyncLogSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISapToShopifySyncLogSaveHandler
    {
        public SapToShopifySyncLogSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}