using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Orders.AddressExtensionRow;

namespace SAPWebPortal.Orders.AddressExtension
{
    public interface IAddressExtensionDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class AddressExtensionDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IAddressExtensionDeleteHandler
    {
        public AddressExtensionDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}