using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.RecordCountsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.RecordCountsRow;

namespace SAPWebPortal.Default
{
    public interface IRecordCountsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class RecordCountsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IRecordCountsSaveHandler
    {
        public RecordCountsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}