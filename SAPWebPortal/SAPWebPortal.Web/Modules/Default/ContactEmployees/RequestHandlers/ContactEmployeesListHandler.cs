using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.ContactEmployeesRow>;
using MyRow = SAPWebPortal.Default.ContactEmployeesRow;

namespace SAPWebPortal.Default
{
    public interface IContactEmployeesListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class ContactEmployeesListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IContactEmployeesListHandler
    {
        public ContactEmployeesListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}