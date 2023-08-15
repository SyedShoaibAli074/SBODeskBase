using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Administration.SettingsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Administration.SettingsRow;

namespace SAPWebPortal.Administration
{
    public interface ISettingsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class SettingsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ISettingsSaveHandler
    {
        public SettingsSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}