using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.BusinessPartnerRow;

namespace SAPWebPortal.Default
{
    public interface IBusinessPartnerDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class BusinessPartnerDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IBusinessPartnerDeleteHandler
    {
        public BusinessPartnerDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}