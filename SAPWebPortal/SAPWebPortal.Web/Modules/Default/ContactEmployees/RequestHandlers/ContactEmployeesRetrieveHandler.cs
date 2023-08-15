using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.ContactEmployeesRow>;
using MyRow = SAPWebPortal.Default.ContactEmployeesRow;

namespace SAPWebPortal.Default
{
    public interface IContactEmployeesRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class ContactEmployeesRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IContactEmployeesRetrieveHandler
    {
        public ContactEmployeesRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}