using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.FileRoutingRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.FileRoutingRow;

namespace SAPWebPortal.Default
{
    public interface IFileRoutingSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class FileRoutingSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IFileRoutingSaveHandler
    {
        public FileRoutingSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}