using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.OipbatchRow;

namespace SAPWebPortal.Default
{
    public interface IOipbatchDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class OipbatchDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IOipbatchDeleteHandler
    {
        public OipbatchDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}