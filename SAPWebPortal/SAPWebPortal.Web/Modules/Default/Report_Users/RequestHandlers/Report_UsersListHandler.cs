using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.Report_UsersRow>;
using MyRow = SAPWebPortal.Default.Report_UsersRow;

namespace SAPWebPortal.Default
{
    public interface IReport_UsersListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class Report_UsersListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IReport_UsersListHandler
    {
        public Report_UsersListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}