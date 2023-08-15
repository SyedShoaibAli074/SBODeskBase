using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Administration.LogRow;

namespace SAPWebPortal.Administration
{
    public interface ILogDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class LogDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ILogDeleteHandler
    {
        public LogDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}