using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Orders.AddressExtensionRow>;
using MyRow = SAPWebPortal.Orders.AddressExtensionRow;

namespace SAPWebPortal.Orders.AddressExtension
{
    public interface IAddressExtensionListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class AddressExtensionListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IAddressExtensionListHandler
    {
        public AddressExtensionListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}