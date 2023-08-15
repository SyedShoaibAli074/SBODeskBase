using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Administration.UserFormAuthorizationsRow>;
using MyRow = SAPWebPortal.Administration.UserFormAuthorizationsRow;

namespace SAPWebPortal.Administration
{
    public interface IUserFormAuthorizationsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class UserFormAuthorizationsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserFormAuthorizationsListHandler
    {
        public UserFormAuthorizationsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}