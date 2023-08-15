using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ItemRow>;
using MyRow = SAPWebPortal.Default.ItemRow;

namespace SAPWebPortal.Default
{
    public interface IItemRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ItemRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IItemRetrieveHandler
    {
        public ItemRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}