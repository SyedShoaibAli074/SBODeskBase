using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Administration.UserFormAuthorizationsDetailsRow>;
using MyRow = SAPWebPortal.Administration.UserFormAuthorizationsDetailsRow;

namespace SAPWebPortal.Administration
{
    public interface IUserFormAuthorizationsDetailsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class UserFormAuthorizationsDetailsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserFormAuthorizationsDetailsListHandler
    {
        public UserFormAuthorizationsDetailsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}