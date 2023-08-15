using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Administration.SettingsRow>;
using MyRow = SAPWebPortal.Administration.SettingsRow;

namespace SAPWebPortal.Administration
{
    public interface ISettingsRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class SettingsRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, ISettingsRetrieveHandler
    {
        public SettingsRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}