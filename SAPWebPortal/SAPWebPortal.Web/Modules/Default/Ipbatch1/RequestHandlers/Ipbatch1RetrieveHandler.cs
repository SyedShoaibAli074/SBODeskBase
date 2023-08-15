using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.Ipbatch1Row>;
using MyRow = SAPWebPortal.Default.Ipbatch1Row;

namespace SAPWebPortal.Default
{
    public interface IIpbatch1RetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class Ipbatch1RetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IIpbatch1RetrieveHandler
    {
        public Ipbatch1RetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}