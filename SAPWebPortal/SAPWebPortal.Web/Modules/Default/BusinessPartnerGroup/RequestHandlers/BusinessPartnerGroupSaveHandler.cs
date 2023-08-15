using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.BusinessPartnerGroupRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.BusinessPartnerGroupRow;

namespace SAPWebPortal.Default
{
    public interface IBusinessPartnerGroupSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class BusinessPartnerGroupSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IBusinessPartnerGroupSaveHandler
    {
        public BusinessPartnerGroupSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}