using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.OipbatchRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.OipbatchRow;

namespace SAPWebPortal.Default
{
    public interface IOipbatchSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class OipbatchSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IOipbatchSaveHandler
    {
        public OipbatchSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}