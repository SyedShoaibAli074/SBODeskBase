using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Administration.UserFormAuthorizationsDetailsRow>;
using MyRow = SAPWebPortal.Administration.UserFormAuthorizationsDetailsRow;

namespace SAPWebPortal.Administration
{
    public interface IUserFormAuthorizationsDetailsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class UserFormAuthorizationsDetailsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IUserFormAuthorizationsDetailsRetrieveHandler
    {
        public UserFormAuthorizationsDetailsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}