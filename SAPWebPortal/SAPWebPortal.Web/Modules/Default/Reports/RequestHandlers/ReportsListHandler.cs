using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ReportsRow>;
using MyRow = SAPWebPortal.Default.ReportsRow;

namespace SAPWebPortal.Default
{
    public interface IReportsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ReportsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IReportsListHandler
    {
        public ReportsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}