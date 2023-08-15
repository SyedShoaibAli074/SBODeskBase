using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Administration.SessionsRow>;
using MyRow = SAPWebPortal.Administration.SessionsRow;

namespace SAPWebPortal.Administration
{
    public interface ISessionsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SessionsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISessionsRetrieveHandler
    {
        public SessionsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}