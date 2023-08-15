using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.UsersRow>;
using MyRow = SAPWebPortal.Default.UsersRow;

namespace SAPWebPortal.Default
{
    public interface IUsersRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class UsersRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IUsersRetrieveHandler
    {
        public UsersRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}