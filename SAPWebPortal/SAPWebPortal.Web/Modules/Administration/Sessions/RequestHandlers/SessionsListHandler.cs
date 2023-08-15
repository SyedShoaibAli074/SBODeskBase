using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Administration.SessionsRow>;
using MyRow = SAPWebPortal.Administration.SessionsRow;

namespace SAPWebPortal.Administration
{
    public interface ISessionsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SessionsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISessionsListHandler
    {
        public SessionsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}