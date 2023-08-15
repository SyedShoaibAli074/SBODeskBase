using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.SapDatabasesRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.SapDatabasesRow;

namespace SAPWebPortal.Default
{
    public interface ISapDatabasesSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SapDatabasesSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISapDatabasesSaveHandler
    {
        public SapDatabasesSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}