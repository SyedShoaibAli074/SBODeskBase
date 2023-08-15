using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.BPAddressesRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.BPAddressesRow;

namespace SAPWebPortal.Default
{
    public interface IBPAddressesSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class BPAddressesSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IBPAddressesSaveHandler
    {
        public BPAddressesSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}