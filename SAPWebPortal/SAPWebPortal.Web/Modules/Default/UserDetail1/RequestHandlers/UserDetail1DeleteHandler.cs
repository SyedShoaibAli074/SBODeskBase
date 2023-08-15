using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.UserDetail1Row;

namespace SAPWebPortal.Default
{
    public interface IUserDetail1DeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class UserDetail1DeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IUserDetail1DeleteHandler
    {
        public UserDetail1DeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}