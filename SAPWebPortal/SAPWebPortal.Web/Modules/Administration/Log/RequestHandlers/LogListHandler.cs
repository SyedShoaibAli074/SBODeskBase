using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Administration.LogRow>;
using MyRow = SAPWebPortal.Administration.LogRow;

namespace SAPWebPortal.Administration
{
    public interface ILogListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class LogListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ILogListHandler
    {
        public LogListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}