using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ChartOfAccountRow>;
using MyRow = SAPWebPortal.Default.ChartOfAccountRow;

namespace SAPWebPortal.Default
{
    public interface IChartOfAccountRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ChartOfAccountRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IChartOfAccountRetrieveHandler
    {
        public ChartOfAccountRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}