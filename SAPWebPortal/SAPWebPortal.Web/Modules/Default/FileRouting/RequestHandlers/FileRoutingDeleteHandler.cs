using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.FileRoutingRow;

namespace SAPWebPortal.Default
{
    public interface IFileRoutingDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class FileRoutingDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IFileRoutingDeleteHandler
    {
        public FileRoutingDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}