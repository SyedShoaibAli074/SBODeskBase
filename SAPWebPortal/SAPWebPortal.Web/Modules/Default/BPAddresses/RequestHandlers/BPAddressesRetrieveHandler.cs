using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.BPAddressesRow>;
using MyRow = SAPWebPortal.Default.BPAddressesRow;

namespace SAPWebPortal.Default
{
    public interface IBPAddressesRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class BPAddressesRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IBPAddressesRetrieveHandler
    {
        public BPAddressesRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}