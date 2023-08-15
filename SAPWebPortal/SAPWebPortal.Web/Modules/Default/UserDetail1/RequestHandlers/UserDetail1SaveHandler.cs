using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.UserDetail1Row>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.UserDetail1Row;

namespace SAPWebPortal.Default
{
    public interface IUserDetail1SaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class UserDetail1SaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IUserDetail1SaveHandler
    {
        public UserDetail1SaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}