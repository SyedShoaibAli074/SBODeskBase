using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.DeleteRequest;
using MyResponse = Serenity.Services.DeleteResponse;
using MyRow = SAPWebPortal.Default.BusinessPartnerGroupRow;

namespace SAPWebPortal.Default
{
    public interface IBusinessPartnerGroupDeleteHandler : IDeleteHandler<MyRow, MyRequest, MyResponse> {}

    public class BusinessPartnerGroupDeleteHandler : DeleteRequestHandler<MyRow, MyRequest, MyResponse>, IBusinessPartnerGroupDeleteHandler
    {
        public BusinessPartnerGroupDeleteHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}