using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Administration.UserFormAuthorizationsDetailsRow;

namespace SAPWebPortal.Administration
{
    public interface IUserFormAuthorizationsDetailsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class UserFormAuthorizationsDetailsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IUserFormAuthorizationsDetailsDeleteHandler
    {
        public UserFormAuthorizationsDetailsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}