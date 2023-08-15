using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.BusinessPartnerRow>;
using MyRow = SAPWebPortal.Default.BusinessPartnerRow;

namespace SAPWebPortal.Default
{
    public interface IBusinessPartnerListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class BusinessPartnerListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IBusinessPartnerListHandler
    {
        public BusinessPartnerListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}