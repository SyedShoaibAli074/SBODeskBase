using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.AdditionalExpenseRow>;
using MyRow = SAPWebPortal.Default.AdditionalExpenseRow;

namespace SAPWebPortal.Default
{
    public interface IAdditionalExpenseListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class AdditionalExpenseListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IAdditionalExpenseListHandler
    {
        public AdditionalExpenseListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}