using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.VatGroups.VatGroupRow;

namespace SAPWebPortal.VatGroups
{
    public interface IVatGroupDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class VatGroupDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IVatGroupDeleteHandler
    {
        public VatGroupDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}