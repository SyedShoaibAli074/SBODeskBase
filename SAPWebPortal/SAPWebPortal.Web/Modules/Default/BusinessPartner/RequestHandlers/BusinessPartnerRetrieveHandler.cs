using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.RetrieveRequest;
using MyResponse = Serenity.Services.RetrieveResponse<SAPWebPortal.Default.BusinessPartnerRow>;
using MyRow = SAPWebPortal.Default.BusinessPartnerRow;

namespace SAPWebPortal.Default
{
    public interface IBusinessPartnerRetrieveHandler : IRetrieveHandler<MyRow, MyRequest, MyResponse> {}

    public class BusinessPartnerRetrieveHandler : RetrieveRequestHandler<MyRow, MyRequest, MyResponse>, IBusinessPartnerRetrieveHandler
    {
        public BusinessPartnerRetrieveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}