using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.UsersRow;

namespace SAPWebPortal.Default
{
    public interface IUsersDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class UsersDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IUsersDeleteHandler
    {
        public UsersDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}