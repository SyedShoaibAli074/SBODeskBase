using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.VatGroups.VatGroupRow>;
using MyRow = SAPWebPortal.VatGroups.VatGroupRow;

namespace SAPWebPortal.VatGroups
{
    public interface IVatGroupListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class VatGroupListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IVatGroupListHandler
    {
        public VatGroupListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}