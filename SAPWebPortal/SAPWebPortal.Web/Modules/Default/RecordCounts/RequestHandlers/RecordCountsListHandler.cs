using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.RecordCountsRow>;
using MyRow = SAPWebPortal.Default.RecordCountsRow;

namespace SAPWebPortal.Default
{
    public interface IRecordCountsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class RecordCountsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IRecordCountsListHandler
    {
        public RecordCountsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}