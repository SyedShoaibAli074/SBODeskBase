using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.AdditionalExpenseRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.AdditionalExpenseRow;

namespace SAPWebPortal.Default
{
    public interface IAdditionalExpenseSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class AdditionalExpenseSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IAdditionalExpenseSaveHandler
    {
        public AdditionalExpenseSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}