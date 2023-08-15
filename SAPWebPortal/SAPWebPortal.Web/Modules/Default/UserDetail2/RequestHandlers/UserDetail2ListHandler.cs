using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.UserDetail2Row>;
using MyRow = SAPWebPortal.Default.UserDetail2Row;

namespace SAPWebPortal.Default
{
    public interface IUserDetail2ListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class UserDetail2ListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IUserDetail2ListHandler
    {
        public UserDetail2ListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}