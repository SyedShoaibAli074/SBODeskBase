using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.WarehouseRow>;
using MyRow = SAPWebPortal.Default.WarehouseRow;

namespace SAPWebPortal.Default
{
    public interface IWarehouseListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class WarehouseListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IWarehouseListHandler
    {
        public WarehouseListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}