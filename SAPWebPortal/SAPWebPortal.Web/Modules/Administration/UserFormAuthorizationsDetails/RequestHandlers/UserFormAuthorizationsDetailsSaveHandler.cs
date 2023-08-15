using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Administration.UserFormAuthorizationsDetailsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Administration.UserFormAuthorizationsDetailsRow;

namespace SAPWebPortal.Administration
{
    public interface IUserFormAuthorizationsDetailsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class UserFormAuthorizationsDetailsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IUserFormAuthorizationsDetailsSaveHandler
    {
        public UserFormAuthorizationsDetailsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}