using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.UserDetail2Row;

namespace SAPWebPortal.Default
{
    public interface IUserDetail2DeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class UserDetail2DeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IUserDetail2DeleteHandler
    {
        public UserDetail2DeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}