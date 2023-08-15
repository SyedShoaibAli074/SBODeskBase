using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Administration.UserFormAuthorizationsRow;

namespace SAPWebPortal.Administration
{
    public interface IUserFormAuthorizationsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class UserFormAuthorizationsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IUserFormAuthorizationsDeleteHandler
    {
        public UserFormAuthorizationsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}