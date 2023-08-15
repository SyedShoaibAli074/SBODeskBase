using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.UsersDetailsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.UsersDetailsRow;

namespace SAPWebPortal.Default
{
    public interface IUsersDetailsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class UsersDetailsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IUsersDetailsSaveHandler
    {
        public UsersDetailsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}