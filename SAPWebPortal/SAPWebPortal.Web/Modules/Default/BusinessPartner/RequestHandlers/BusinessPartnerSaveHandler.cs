using Newtonsoft.Json.Linq;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Data;
using MyRequest = Serenity.Services.SaveRequest<SAPWebPortal.Default.BusinessPartnerRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = SAPWebPortal.Default.BusinessPartnerRow;
using sapRow = SAPB1.BusinessPartner;
using System.Linq; 

namespace SAPWebPortal.Default
{
    public interface IBusinessPartnerSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> {}

    public class BusinessPartnerSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IBusinessPartnerSaveHandler
    {
        public BusinessPartnerSaveHandler(IRequestContext context)
             : base(context)
        {
        }
        public MyResponse CreateInSAP(MyRequest request)
        {
            var att = request.Entity.GetType().GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName;
                var PrimaryKeyName = request.Entity.GetType().GetFieldNameOfAttribute(typeof(SAPPrimaryKeyAttribute));
                 
                
                Response = new MyResponse();
                var json = JObject.FromObject(request.Entity);
                
                    var helper = ServiceLayerRestHandler.GetInstance(Context);
                    string response;

                    var b = helper.AddToBO(ModuleName, json.ToString(), out response);
                    if (!b)
                    {
                        Response.EntityId = -1;
                        Response.Error = new ServiceError() { Code = ModuleName, Message = response };
                    }
                    else
                    {
                        var obj = JObject.Parse(response);
                        Response.EntityId = obj[PrimaryKeyName];
                    }
                 
            }
            return Response;
        }
        public MyResponse UpdateInSAP(MyRequest request)
        {
            var att = request.Entity.GetType().GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            { 
                var ModuleName = att.ModuleName;
                var PrimaryKeyName = request.Entity.GetType().GetFieldNameOfAttribute(typeof(SAPPrimaryKeyAttribute));
                var PrimaryKeyType = request.Entity.GetType().GetFieldTypeOfAttribute(typeof(SAPPrimaryKeyAttribute));

                Response = new MyResponse();
                var json = JObject.FromObject(request.Entity);
                 
                    var helper = ServiceLayerRestHandler.GetInstance(Context);
                    string response;
                string keyvalue = "";
                if (PrimaryKeyType == typeof( string ) || PrimaryKeyType == typeof(String) )
                    keyvalue = $"'{json[PrimaryKeyName]?.ToString()}'";
                else keyvalue = json[PrimaryKeyName]?.ToString();
                    var b = helper.UpdateBO(ModuleName, keyvalue, json.ToString(), out response);
                    if (!b)
                    {
                        Response.EntityId = -1;
                        Response.Error = new ServiceError() { Code = ModuleName, Message = response };
                    }
                    else
                    { 
                        Response.EntityId = json[PrimaryKeyName]?.ToString();
                    }
                 
            }
            return Response;
        }

    }
}