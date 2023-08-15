using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.Ipbatch1Row>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.Ipbatch1Row;

namespace SAPWebPortal.Default
{
    public interface IIpbatch1SaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class Ipbatch1SaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IIpbatch1SaveHandler
    {
        public Ipbatch1SaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}