using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.UserDetail1Row>;
using MyRow = SAPWebPortal.Default.UserDetail1Row;

namespace SAPWebPortal.Default
{
    public interface IUserDetail1RetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class UserDetail1RetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IUserDetail1RetrieveHandler
    {
        public UserDetail1RetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}