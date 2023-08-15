using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ReportsRow>;
using MyRow = SAPWebPortal.Default.ReportsRow;

namespace SAPWebPortal.Default
{
    public interface IReportsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ReportsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IReportsRetrieveHandler
    {
        public ReportsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}