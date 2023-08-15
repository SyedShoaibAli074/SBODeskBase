using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.Ipbatch1Row;

namespace SAPWebPortal.Default
{
    public interface IIpbatch1DeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class Ipbatch1DeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IIpbatch1DeleteHandler
    {
        public Ipbatch1DeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}