using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.BPAddressesRow>;
using MyRow = SAPWebPortal.Default.BPAddressesRow;

namespace SAPWebPortal.Default
{
    public interface IBPAddressesListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class BPAddressesListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IBPAddressesListHandler
    {
        public BPAddressesListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}