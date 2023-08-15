using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ChartOfAccountRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ChartOfAccountRow;

namespace SAPWebPortal.Default
{
    public interface IChartOfAccountSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ChartOfAccountSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IChartOfAccountSaveHandler
    {
        public ChartOfAccountSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}