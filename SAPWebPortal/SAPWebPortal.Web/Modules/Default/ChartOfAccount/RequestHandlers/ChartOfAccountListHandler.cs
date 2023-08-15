using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ChartOfAccountRow>;
using MyRow = SAPWebPortal.Default.ChartOfAccountRow;

namespace SAPWebPortal.Default
{
    public interface IChartOfAccountListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ChartOfAccountListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IChartOfAccountListHandler
    {
        public ChartOfAccountListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}