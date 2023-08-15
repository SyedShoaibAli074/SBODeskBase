using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.UserDetail2Row>;
using MyRow = SAPWebPortal.Default.UserDetail2Row;

namespace SAPWebPortal.Default
{
    public interface IUserDetail2RetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class UserDetail2RetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IUserDetail2RetrieveHandler
    {
        public UserDetail2RetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}