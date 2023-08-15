using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.UserDetail1Row>;
using MyRow = SAPWebPortal.Default.UserDetail1Row;

namespace SAPWebPortal.Default
{
    public interface IUserDetail1ListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class UserDetail1ListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserDetail1ListHandler
    {
        public UserDetail1ListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}