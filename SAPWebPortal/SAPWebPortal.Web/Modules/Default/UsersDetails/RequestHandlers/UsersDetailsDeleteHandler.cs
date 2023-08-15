using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.UsersDetailsRow;

namespace SAPWebPortal.Default
{
    public interface IUsersDetailsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class UsersDetailsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IUsersDetailsDeleteHandler
    {
        public UsersDetailsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}