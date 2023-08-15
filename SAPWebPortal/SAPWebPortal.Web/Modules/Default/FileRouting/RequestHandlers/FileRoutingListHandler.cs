using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.FileRoutingRow>;
using MyRow = SAPWebPortal.Default.FileRoutingRow;

namespace SAPWebPortal.Default
{
    public interface IFileRoutingListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class FileRoutingListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IFileRoutingListHandler
    {
        public FileRoutingListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}