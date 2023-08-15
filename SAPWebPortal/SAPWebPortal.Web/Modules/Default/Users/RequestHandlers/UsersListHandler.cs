using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.UsersRow>;
using MyRow = SAPWebPortal.Default.UsersRow;

namespace SAPWebPortal.Default
{
    public interface IUsersListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class UsersListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUsersListHandler
    {
        public UsersListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}