using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ChartOfAccountRow;

namespace SAPWebPortal.Default
{
    public interface IChartOfAccountDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ChartOfAccountDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IChartOfAccountDeleteHandler
    {
        public ChartOfAccountDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}