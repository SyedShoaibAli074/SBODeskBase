using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Administration.LogRow>;
using MyRow = SAPWebPortal.Administration.LogRow;

namespace SAPWebPortal.Administration
{
    public interface ILogRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class LogRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ILogRetrieveHandler
    {
        public LogRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}