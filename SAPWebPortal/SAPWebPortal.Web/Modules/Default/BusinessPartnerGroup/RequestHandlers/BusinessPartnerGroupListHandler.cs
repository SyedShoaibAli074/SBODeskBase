using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.ListRequest;
using MyResponse = Serenity.Services.ListResponse<SAPWebPortal.Default.BusinessPartnerGroupRow>;
using MyRow = SAPWebPortal.Default.BusinessPartnerGroupRow;

namespace SAPWebPortal.Default
{
    public interface IBusinessPartnerGroupListHandler : IListHandler<MyRow, MyRequest, MyResponse> {}

    public class BusinessPartnerGroupListHandler : ListRequestHandler<MyRow, MyRequest, MyResponse>, IBusinessPartnerGroupListHandler
    {
        public BusinessPartnerGroupListHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}