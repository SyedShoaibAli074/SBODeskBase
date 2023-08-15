using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Administration.ExceptionsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Administration.ExceptionsRow;

namespace SAPWebPortal.Administration
{
    public interface IExceptionsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ExceptionsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IExceptionsSaveHandler
    {
        public ExceptionsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}