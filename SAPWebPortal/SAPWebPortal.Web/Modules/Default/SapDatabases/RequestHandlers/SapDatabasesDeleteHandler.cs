using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.SapDatabasesRow;

namespace SAPWebPortal.Default
{
    public interface ISapDatabasesDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SapDatabasesDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISapDatabasesDeleteHandler
    {
        public SapDatabasesDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}