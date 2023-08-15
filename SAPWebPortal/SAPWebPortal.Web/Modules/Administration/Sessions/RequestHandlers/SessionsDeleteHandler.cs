using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Administration.SessionsRow;

namespace SAPWebPortal.Administration
{
    public interface ISessionsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SessionsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISessionsDeleteHandler
    {
        public SessionsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}