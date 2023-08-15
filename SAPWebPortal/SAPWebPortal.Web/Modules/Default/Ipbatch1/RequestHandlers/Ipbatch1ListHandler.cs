using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.Ipbatch1Row>;
using MyRow = SAPWebPortal.Default.Ipbatch1Row;

namespace SAPWebPortal.Default
{
    public interface IIpbatch1ListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class Ipbatch1ListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IIpbatch1ListHandler
    {
        public Ipbatch1ListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}