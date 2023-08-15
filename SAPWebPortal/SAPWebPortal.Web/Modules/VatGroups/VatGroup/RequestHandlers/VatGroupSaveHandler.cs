using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.VatGroups.VatGroupRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.VatGroups.VatGroupRow;

namespace SAPWebPortal.VatGroups
{
    public interface IVatGroupSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class VatGroupSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IVatGroupSaveHandler
    {
        public VatGroupSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}