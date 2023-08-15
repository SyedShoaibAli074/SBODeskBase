using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Administration.UserFormAuthorizationsRow>;
using MyRow = SAPWebPortal.Administration.UserFormAuthorizationsRow;

namespace SAPWebPortal.Administration
{
    public interface IUserFormAuthorizationsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class UserFormAuthorizationsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IUserFormAuthorizationsRetrieveHandler
    {
        public UserFormAuthorizationsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}