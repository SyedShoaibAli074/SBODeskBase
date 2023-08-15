using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.RecordCountsRow>;
using MyRow = SAPWebPortal.Default.RecordCountsRow;

namespace SAPWebPortal.Default
{
    public interface IRecordCountsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class RecordCountsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IRecordCountsRetrieveHandler
    {
        public RecordCountsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}