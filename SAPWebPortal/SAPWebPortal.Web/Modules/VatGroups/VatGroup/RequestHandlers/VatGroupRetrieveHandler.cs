using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.VatGroups.VatGroupRow>;
using MyRow = SAPWebPortal.VatGroups.VatGroupRow;

namespace SAPWebPortal.VatGroups
{
    public interface IVatGroupRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class VatGroupRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IVatGroupRetrieveHandler
    {
        public VatGroupRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}