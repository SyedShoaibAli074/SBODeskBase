using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ReportsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ReportsRow;

namespace SAPWebPortal.Default
{
    public interface IReportsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ReportsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IReportsSaveHandler
    {
        public ReportsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}