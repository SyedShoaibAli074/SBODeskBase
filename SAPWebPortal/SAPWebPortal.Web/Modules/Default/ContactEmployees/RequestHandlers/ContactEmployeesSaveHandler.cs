using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.ContactEmployeesRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.ContactEmployeesRow;

namespace SAPWebPortal.Default
{
    public interface IContactEmployeesSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class ContactEmployeesSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IContactEmployeesSaveHandler
    {
        public ContactEmployeesSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}