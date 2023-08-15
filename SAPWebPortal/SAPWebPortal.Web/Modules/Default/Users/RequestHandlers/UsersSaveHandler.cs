using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.UsersRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.UsersRow;

namespace SAPWebPortal.Default
{
    public interface IUsersSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class UsersSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IUsersSaveHandler
    {
        public UsersSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}