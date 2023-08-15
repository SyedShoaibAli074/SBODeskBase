using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ItemRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ItemRow;

namespace SAPWebPortal.Default
{
    public interface IItemSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ItemSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IItemSaveHandler
    {
        public ItemSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}