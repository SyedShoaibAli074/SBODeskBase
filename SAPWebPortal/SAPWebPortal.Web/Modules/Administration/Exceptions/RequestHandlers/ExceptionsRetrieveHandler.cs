using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Administration.ExceptionsRow>;
using MyRow = SAPWebPortal.Administration.ExceptionsRow;

namespace SAPWebPortal.Administration
{
    public interface IExceptionsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ExceptionsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IExceptionsRetrieveHandler
    {
        public ExceptionsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}