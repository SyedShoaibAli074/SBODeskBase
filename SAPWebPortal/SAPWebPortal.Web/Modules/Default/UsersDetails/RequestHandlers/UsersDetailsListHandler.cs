using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.UsersDetailsRow>;
using MyRow = SAPWebPortal.Default.UsersDetailsRow;

namespace SAPWebPortal.Default
{
    public interface IUsersDetailsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class UsersDetailsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUsersDetailsListHandler
    {
        public UsersDetailsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}