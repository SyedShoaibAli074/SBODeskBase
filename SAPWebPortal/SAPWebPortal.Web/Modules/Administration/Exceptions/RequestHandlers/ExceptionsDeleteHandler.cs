using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Administration.ExceptionsRow;

namespace SAPWebPortal.Administration
{
    public interface IExceptionsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ExceptionsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IExceptionsDeleteHandler
    {
        public ExceptionsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}