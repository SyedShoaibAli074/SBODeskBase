using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Administration.SettingsRow;

namespace SAPWebPortal.Administration
{
    public interface ISettingsDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class SettingsDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, ISettingsDeleteHandler
    {
        public SettingsDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}