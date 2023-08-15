using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.SapDatabasesRow>;
using MyRow = SAPWebPortal.Default.SapDatabasesRow;

namespace SAPWebPortal.Default
{
    public interface ISapDatabasesListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SapDatabasesListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISapDatabasesListHandler
    {
        public SapDatabasesListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}