using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ItemRow;

namespace SAPWebPortal.Default
{
    public interface IItemDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ItemDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IItemDeleteHandler
    {
        public ItemDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}