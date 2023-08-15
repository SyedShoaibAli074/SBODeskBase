using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.Report_UsersRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.Report_UsersRow;

namespace SAPWebPortal.Default
{
    public interface IReport_UsersSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class Report_UsersSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IReport_UsersSaveHandler
    {
        public Report_UsersSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}