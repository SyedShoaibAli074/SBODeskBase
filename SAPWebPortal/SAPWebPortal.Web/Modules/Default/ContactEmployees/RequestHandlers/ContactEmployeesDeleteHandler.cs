using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.ContactEmployeesRow;

namespace SAPWebPortal.Default
{
    public interface IContactEmployeesDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class ContactEmployeesDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IContactEmployeesDeleteHandler
    {
        public ContactEmployeesDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}