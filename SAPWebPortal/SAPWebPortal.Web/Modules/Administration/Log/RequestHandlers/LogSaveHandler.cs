using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Administration.LogRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Administration.LogRow;

namespace SAPWebPortal.Administration
{
    public interface ILogSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class LogSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILogSaveHandler
    {
        public LogSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}