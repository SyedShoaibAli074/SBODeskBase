using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.SapDatabasesRow>;
using MyRow = SAPWebPortal.Default.SapDatabasesRow;

namespace SAPWebPortal.Default
{
    public interface ISapDatabasesRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SapDatabasesRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISapDatabasesRetrieveHandler
    {
        public SapDatabasesRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}