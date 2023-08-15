using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.LogRow>;
using MyRow = SAPWebPortal.Default.LogRow;

namespace SAPWebPortal.Default
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