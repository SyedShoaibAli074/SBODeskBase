using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.AdditionalExpenseRow>;
using MyRow = SAPWebPortal.Default.AdditionalExpenseRow;

namespace SAPWebPortal.Default
{
    public interface IAdditionalExpenseRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class AdditionalExpenseRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IAdditionalExpenseRetrieveHandler
    {
        public AdditionalExpenseRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}