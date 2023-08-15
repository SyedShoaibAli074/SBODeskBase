using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Administration.ExceptionsRow>;
using MyRow = SAPWebPortal.Administration.ExceptionsRow;

namespace SAPWebPortal.Administration
{
    public interface IExceptionsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ExceptionsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IExceptionsListHandler
    {
        public ExceptionsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}