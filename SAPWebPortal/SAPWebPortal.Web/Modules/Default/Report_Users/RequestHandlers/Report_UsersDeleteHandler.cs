using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.Report_UsersRow;

namespace SAPWebPortal.Default
{
    public interface IReport_UsersDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class Report_UsersDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IReport_UsersDeleteHandler
    {
        public Report_UsersDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}