using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Orders.AddressExtensionRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Orders.AddressExtensionRow;

namespace SAPWebPortal.Orders.AddressExtension
{
    public interface IAddressExtensionSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class AddressExtensionSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IAddressExtensionSaveHandler
    {
        public AddressExtensionSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}