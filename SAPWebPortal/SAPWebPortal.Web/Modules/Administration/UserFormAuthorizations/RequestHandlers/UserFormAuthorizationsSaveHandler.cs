using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Administration.UserFormAuthorizationsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Administration.UserFormAuthorizationsRow;

namespace SAPWebPortal.Administration
{
    public interface IUserFormAuthorizationsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class UserFormAuthorizationsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IUserFormAuthorizationsSaveHandler
    {
        public UserFormAuthorizationsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}