using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.UserDetail2Row>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.UserDetail2Row;

namespace SAPWebPortal.Default
{
    public interface IUserDetail2SaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class UserDetail2SaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IUserDetail2SaveHandler
    {
        public UserDetail2SaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}