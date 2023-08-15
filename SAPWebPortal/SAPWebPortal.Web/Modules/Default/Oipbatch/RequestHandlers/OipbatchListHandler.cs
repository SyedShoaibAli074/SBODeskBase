using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.OipbatchRow>;
using MyRow = SAPWebPortal.Default.OipbatchRow;

namespace SAPWebPortal.Default
{
    public interface IOipbatchListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class OipbatchListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IOipbatchListHandler
    {
        public OipbatchListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}