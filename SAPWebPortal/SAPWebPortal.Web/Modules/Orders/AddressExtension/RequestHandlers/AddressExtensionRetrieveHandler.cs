using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Orders.AddressExtensionRow>;
using MyRow = SAPWebPortal.Orders.AddressExtensionRow;

namespace SAPWebPortal.Orders.AddressExtension
{
    public interface IAddressExtensionRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class AddressExtensionRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IAddressExtensionRetrieveHandler
    {
        public AddressExtensionRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}