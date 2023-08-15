using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Administration.SessionsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Administration.SessionsRow;

namespace SAPWebPortal.Administration
{
    public interface ISessionsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SessionsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISessionsSaveHandler
    {
        public SessionsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}