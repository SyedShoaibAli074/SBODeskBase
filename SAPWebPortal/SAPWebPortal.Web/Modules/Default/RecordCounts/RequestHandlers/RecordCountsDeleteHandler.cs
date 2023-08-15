using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.RecordCountsRow;

namespace SAPWebPortal.Default
{
    public interface IRecordCountsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class RecordCountsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IRecordCountsDeleteHandler
    {
        public RecordCountsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}