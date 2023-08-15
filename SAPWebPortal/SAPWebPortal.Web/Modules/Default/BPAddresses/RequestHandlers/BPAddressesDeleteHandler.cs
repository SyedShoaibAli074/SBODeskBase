using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.BPAddressesRow;

namespace SAPWebPortal.Default
{
    public interface IBPAddressesDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class BPAddressesDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IBPAddressesDeleteHandler
    {
        public BPAddressesDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}