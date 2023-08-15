using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.UsersDetailsRow>;
using MyRow = SAPWebPortal.Default.UsersDetailsRow;

namespace SAPWebPortal.Default
{
    public interface IUsersDetailsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class UsersDetailsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IUsersDetailsRetrieveHandler
    {
        public UsersDetailsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}