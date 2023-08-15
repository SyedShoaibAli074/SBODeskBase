using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Administration.SettingsRow>;
using MyRow = SAPWebPortal.Administration.SettingsRow;

namespace SAPWebPortal.Administration
{
    public interface ISettingsListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class SettingsListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, ISettingsListHandler
    {
        public SettingsListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}