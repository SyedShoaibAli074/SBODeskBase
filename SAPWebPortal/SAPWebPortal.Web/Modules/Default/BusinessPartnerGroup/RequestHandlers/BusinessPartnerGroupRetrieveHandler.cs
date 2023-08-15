using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.BusinessPartnerGroupRow>;
using MyRow = SAPWebPortal.Default.BusinessPartnerGroupRow;

namespace SAPWebPortal.Default
{
    public interface IBusinessPartnerGroupRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class BusinessPartnerGroupRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IBusinessPartnerGroupRetrieveHandler
    {
        public BusinessPartnerGroupRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}