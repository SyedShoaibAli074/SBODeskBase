using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.OipbatchRow>;
using MyRow = SAPWebPortal.Default.OipbatchRow;

namespace SAPWebPortal.Default
{
    public interface IOipbatchRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class OipbatchRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IOipbatchRetrieveHandler
    {
        public OipbatchRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}