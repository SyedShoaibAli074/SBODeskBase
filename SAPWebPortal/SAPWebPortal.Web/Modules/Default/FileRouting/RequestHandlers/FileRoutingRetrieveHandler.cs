using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.FileRoutingRow>;
using MyRow = SAPWebPortal.Default.FileRoutingRow;

namespace SAPWebPortal.Default
{
    public interface IFileRoutingRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class FileRoutingRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IFileRoutingRetrieveHandler
    {
        public FileRoutingRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}