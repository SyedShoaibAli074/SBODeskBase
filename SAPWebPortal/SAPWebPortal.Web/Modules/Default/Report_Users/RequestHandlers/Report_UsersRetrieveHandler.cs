using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.Report_UsersRow>;
using MyRow = SAPWebPortal.Default.Report_UsersRow;

namespace SAPWebPortal.Default
{
    public interface IReport_UsersRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class Report_UsersRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IReport_UsersRetrieveHandler
    {
        public Report_UsersRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}