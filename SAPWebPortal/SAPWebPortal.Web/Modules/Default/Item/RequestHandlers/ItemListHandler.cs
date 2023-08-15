using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ItemRow>;
using MyRow = SAPWebPortal.Default.ItemRow;

namespace SAPWebPortal.Default
{
    public interface IItemListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ItemListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IItemListHandler
    {
        public ItemListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}