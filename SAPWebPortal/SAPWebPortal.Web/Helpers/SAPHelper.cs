
using SAPWebPortal.Web.Modules.Common.Helpers; 
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Common.Pages;
using SAPWebPortal.Quotations.Endpoints; 
using Serenity;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using MyResponse = Serenity.Services.SaveResponse;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using SAPB1;
using SAPWebPortal.Administration.Pages;
using SAPWebPortal.Default.Endpoints;
using ExceptionsController = SAPWebPortal.Administration.Endpoints.ExceptionsController;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using Microsoft.AspNetCore.Http;
using SAPWebPortal.Default;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

using Serenity.Reporting;
using Serenity.Web;
using System.Globalization;
using MyRow = SAPWebPortal.Default.BusinessPartnerRow;
using SAPWebPortal.Web.Helpers;
using Serenity.Data;

using SAPWebPortal.Administration;
using HelperWebSL.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using NToastNotify;
using SAPWebPortal.Membership.Pages;
using _Ext;
using SAPWebPortal.Web.Models.SLModels;

namespace SAPWebPortal.Web.Helpers
{
    public class SAPHelper<T>
    {
        
        IRequestContext Context;
        public SAPHelper(IRequestContext context)
        {
            this.Context = context;
        }
        public MyResponse CreateInSAP(Serenity.Services.SaveRequest<T> request,bool isdraft = false)
        {
            
            var Response = new MyResponse();
            var att = request.Entity.GetType().GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName;


                var PrimaryKeyName = request.Entity.GetType().GetFieldNameOfAttribute(typeof(SAPPrimaryKeyAttribute));
                if (string.IsNullOrEmpty(PrimaryKeyName))
                    throw new Exception($"SAPPrimaryKeyAttribute is not defined in {request.Entity.GetType()} Model");
                var json = JObject.FromObject(request.Entity);

                try
                {
                    var PropertyToRemove = json.Property("DBName");
                    PropertyToRemove.Remove();
                }catch(Exception ex)
                {

                }
                var helper = ServiceLayerRestHandler.GetInstance(Context,request.DBName);
                string response;
                var username = Context.User.Identity.Name;
              
                // ExLog.LogToFile(json.ToString());
                if (isdraft && ModuleName == "IncomingPayments")
                {
                    ModuleName = "PaymentDrafts";
                    //"DocObjectCode": "bopot_IncomingPayments",
                    json.Add("DocObjectCode", "bopot_IncomingPayments");

                }
                var b = helper.AddToBO<T>(ModuleName, json.ToString(), out response);
                if (b && json.ContainsKey("U_ApprovalGUID") && response.ToString()=="-2028")
                {
                    var GUID = json?["U_ApprovalGUID"]?.ToString();
                    b = IsInApproval(GUID, request.DBName);
                    if (b)
                    {
                        Dictionary<string, object> Approval = new Dictionary<string, object>();
                        Approval.Add("Approval", b);
                        Response.CustomData = Approval;
                    }
                }
                if (!b)
                {
                    Response.EntityId = -1;
                    //payment draft
                  
                    
                    Response.Error = new ServiceError() { Code = ModuleName, Message = response };
                    ExceptionsController.Log(new Exception("Module:" + ModuleName + " Error: " + response.ToString()));
                    throw new Exception(JObject.Parse(response)?["error"]?["message"]?.ToString());
                }
                else
                {
                    if (response != "-2028")
                    {
                        try
                        {
                            var obj = JObject.Parse(response);
                            Response.EntityId = obj[PrimaryKeyName];
                        }
                        catch { }
                    }
                }
            }
            return Response;
        }
        public MyResponse UpdateInSAP(Serenity.Services.SaveRequest<T> request)
        {
            var Response = new MyResponse();
            
            
            var att = request.Entity.GetType().GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName;
                var PrimaryKeyName = request.Entity.GetType().GetFieldNameOfAttribute(typeof(SAPPrimaryKeyAttribute));
                if (string.IsNullOrEmpty(PrimaryKeyName))
                    throw new Exception($"SAPPrimaryKeyAttribute is not defined in {request.Entity.GetType()} Model");
                var PrimaryKeyType = request.Entity.GetType().GetFieldTypeOfAttribute(typeof(SAPPrimaryKeyAttribute));

                var json = JObject.FromObject(request.Entity, JsonSerializer.CreateDefault(new JsonSerializerSettings { Converters = { new StringEnumConverter() { AllowIntegerValues = false } } }));
                //todo:following is returned null
                try
                {
                    var PropertyToRemove = json.Property("DBName");
                    PropertyToRemove.Remove();
                }catch(Exception ex)
                {
                    ex.Log();
                }
                var helper = ServiceLayerRestHandler.GetInstance(Context,request.DBName);
                string response;
                object keyvalue ;
                if (PrimaryKeyType == typeof(string) || PrimaryKeyType == typeof(String))
                    keyvalue = $"{json[PrimaryKeyName]?.ToString()}";
                else keyvalue =Convert.ToInt32( json[PrimaryKeyName]?.ToString());
                var b = helper.UpdateBO(ModuleName, keyvalue, json.ToString(), out response,request.ReplaceCollectionsOnPatch);
                if (!b)
                {
                    Response.EntityId = -1;
                    Response.Error = new ServiceError() { Code = ModuleName, Message = response };
                    ExceptionsController.Log(new Exception("Module: "+ ModuleName +" Error: "+ response.ToString()));
                    throw new Exception(JObject.Parse(response)?["error"]?["message"]?.ToString());
                }
                else
                {
                    Response.EntityId = json[PrimaryKeyName]?.ToString();
                   
                }

            }
            return Response;
        }

        internal DeleteResponse DeleteInSAP(DeleteRequest request)
        {
            DeleteResponse response = new DeleteResponse(); 
            var t = typeof(T);
            string resp;
            var att = t.GetAttribute<ServiceLayerAttribute>();

            var PrimaryKeyType = t.GetFieldTypeOfAttribute(typeof(SAPPrimaryKeyAttribute));
            if (att != null)
            {
                string keyvalue = request.EntityId.ToString();
                if (PrimaryKeyType == typeof(String))
                {
                    keyvalue = $"'{request.EntityId.ToString()}'";
                }
                var ModuleName = att.ModuleName;
                var helper = ServiceLayerRestHandler.GetInstance(Context);
                var b = helper.DeleteBO(ModuleName, keyvalue, out resp);
                if (!b)
                {
                    response.Error = new ServiceError() { Code = "-1", Message = resp };
                    ExceptionsController.Log(new Exception("Module: " + ModuleName + "Error:" + response.ToString()));
                    throw new Exception(JObject.Parse(resp)?["error"]?["message"]?.ToString());
                }
               
              
            }
            
            return response;
        }

        internal RetrieveResponse<T> RetrieveFromSAP(RetrieveRequest request)
        {
           
            RetrieveResponse<T> response = new RetrieveResponse<T>();
            object id = request.EntityId;
            var arr = id.ToString().Split(',');
           
            if (arr.Count() == 1)
            {
                throw new Exception("Please add companydbname handler from the front end. Extend grid.ts from _Ext.GridBase1");
            }
            var EntityId = arr[0].ToString();
            var DBName = arr[1].ToString();
            request.EntityId = EntityId;
            object _id = request.EntityId;
            var t = typeof(T);
            string resp;
            var att = t.GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                object keyvalue = null;
                var ModuleName = att.ModuleName;
                var PrimaryKeyType = typeof(T).GetFieldTypeOfAttribute(typeof(SAPPrimaryKeyAttribute));


                if (PrimaryKeyType == typeof(string) || PrimaryKeyType == typeof(String))
                    keyvalue = $"{_id}";
                else keyvalue = Convert.ToInt32(_id);
                var helper = ServiceLayerRestHandler.GetInstance(Context,DBName);
                var b = helper.GetSLEntity<T>(ModuleName, keyvalue, out resp);
                if (b)
                {
                    JObject obj = JObject.Parse(resp);
                    response.Entity = TransformEntityfromSL2Serene(obj);
                }
                if (!b)
                    response.Error = new ServiceError() { Code = "-1", Message = resp };
               // ExceptionsController.Log(new Exception("Module:" + ModuleName + "Error:" + response.Error.ToString()));
            }
            return response;
        }
        static Dictionary<string,  ListResponse<T>> DataDictionary = new Dictionary<string,   ListResponse<T>>();
        public System.Collections.Generic. List<(string username,string dbname,string modlulename,int totalcount)> GetAllDataDictionary()
        {
            var list = new System.Collections.Generic.List<(string username, string dbname, string modlulename, int totalcount)>();

            var att = typeof(T).GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName;

                foreach (var item in DataDictionary)
                {
                    if (item.Value != null)
                    {
                        var username = item.Value.UserName;
                        var dbname = item.Value.DBName;
                        var modlulename = item.Value.ModuleName;
                        var totalcount = item.Value.TotalCount;
                        if (modlulename == ModuleName)
                            list.Add((username, dbname, modlulename, totalcount));
                    }
                }
            }
            return list;
        }
        
        internal ListResponse<T> List(ListRequest request,string criteriastring = "")
        {
            ListResponse<T> response = new ListResponse<T>();
            var t = typeof(T);
            response.Entities = new System.Collections.Generic.List<T>();
            string resp;
            JArray obj = null;
            long TotalCount = 0;
            var att = t.GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName;
                var PrimaryKeyType = typeof(T).GetFieldTypeOfAttribute(typeof(SAPPrimaryKeyAttribute));
                var criteria = request.Criteria.ToJson();
                var helper = ServiceLayerRestHandler.GetInstance(Context,request.CompanyDB);
                var include = request.IncludeColumns;
                var containstext = request.ContainsText;
                System.Collections.Generic.List<string> quicksearchFieldnames =null;
                if (!string.IsNullOrEmpty(containstext))
                    quicksearchFieldnames = typeof(T).GetFieldNamesOfAttribute(typeof(Serenity.Data.Mapping.QuickSearchAttribute));
                //request.criteria is not null
                var key = "";
                //key = username
                var usercontroller = new UsersController(this.Context);
                var username = this.Context.User.Identity.Name;
                /*                var companyname = usercontroller.getCompanyName(username);
                */
                Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(Startup.connectionString);
      
                var companyname = request.CompanyDB;

                key = Context.User.Identity.Name+ companyname + ModuleName;
                //if key is in DataDictionary
                
                var b = false; 
                    b = helper.GetSLList<T>(ModuleName, request, out resp, out TotalCount, include, containstext, quicksearchFieldnames, criteriastring,CompanyDB:companyname,UserName:username);

                    if (b)
                    {
                        JArray array = JArray.Parse(resp);
                        response.Entities = (System.Collections.Generic.List<T>)JsonConvert.DeserializeObject<System.Collections.Generic.List<T>>(array.ToString());
                        response.TotalCount = response.Entities.Count();
                        
                        
                            if (!DataDictionary.Keys.Contains(key))
                            {
                                DataDictionary.Add(key, response);
                            }
                            else
                            {
                                DataDictionary[key] = response;
                            } 
                        SortBy[] sort = request.Sort;
                        if (sort != null && sort.Length > 0)
                        {
                            var sortby = sort[0].Field;
                            var desc = sort[0].Descending;
                            if (desc)
                                response.Entities = response.Entities.OrderByDescending(x => x.GetType().GetProperty(sortby).GetValue(x)).ToList();
                            else
                                response.Entities = response.Entities.OrderBy(x => x.GetType().GetProperty(sortby).GetValue(x)).ToList();
                        }
                        var clone = response.Clone(); 
                        
                        if (quicksearchFieldnames != null && quicksearchFieldnames.Count > 0)
                        {
                            clone.Entities = clone.Entities.Where(x => quicksearchFieldnames.Any(y =>
                             x.GetType().GetProperty(y).GetValue(x) != null && x.GetType().GetProperty(y).GetValue(x).ToString().ToLower().Contains(containstext.ToLower()))).ToList();
                        }
                        if (request.EqualityFilter != null)
                        {
                            var filter = request.EqualityFilter;

                            foreach (var f in filter)
                            {

                                if (f.Value != null && f.Value.ToString().Trim() != "")
                                    clone.Entities = clone.Entities.Where(x => x.GetType().GetProperty(f.Key).GetValue(x).ToString().ToLower().Contains(f.Value.ToString().ToLower())).ToList();
                            }
                        }

                        clone.TotalCount = clone.Entities.Count();
                        clone.Entities = clone.Entities.Skip(request.Skip).ToList();
                        clone.Entities = clone.Entities.Take(request.Take).ToList();
                        clone.Take = request.Take;
                        clone.Skip = request.Skip;
                        clone.UserName = username;
                        clone.DBName = companyname;
                        clone.ModuleName = ModuleName;
                        response = clone;
                    }
                    if (!b)
                        response.Error = new ServiceError() { Code = "-1", Message = resp };

                //}

                if (response.Entities.Count() == 0)
                {
                    response.Error = new ServiceError() { Code = "-1", Message = "No Record Found" };
                }
            }
            response.Skip = request.Skip;
            response.Take = request.Take;
            response.TotalCount = Convert.ToInt32( TotalCount);
            var json = JsonConvert.SerializeObject(response);
            return response;
        }

        private static T TransformEntityfromSL2Serene(JToken item)
        {
            var t = typeof(T);
            
           // var entity = (T)Activator.CreateInstance(t);
            var json = item.ToString();
           var entity =  (T)JsonConvert.DeserializeObject<T>(json);

            //var properties = t.GetProperties();
            //foreach (var field in ((Serenity.Data.IRow)entity).Fields)
            //{

            //    var value = item[field.PropertyName].ToString();
            //    t.GetProperty(field.PropertyName).SetValue(entity, value);
            //    //todo: implement list filler
            //} 
            return entity;
        }
        public static T Adapt(  T input)
        {
            if(input.GetType().Name== "BusinessPartnerRow")
            { 
                var prop = input.GetType().GetProperty("CardType");
                var value = prop.GetValue(input);
               switch(value.ToString())
                {
                    case "cCustomer":
                        value = "C";
                        break;
                    case "cLid":
                        value = "L";
                        break;
                    case "cSupplier":
                        value = "S";
                        break;
                }
                prop.SetValue(input, value);
            }
            return input;
        }
        
        #region List Data
        public static System.Collections.Generic.List<SelectListItem> GetListFromQuery(T row,string FieldName,string DBName)
        {
            System.Collections.Generic.List<SelectListItem> result = new System.Collections.Generic.List<SelectListItem>();
            string query = "";
            try
            {
                row = Adapt(row);
                SAPB1.BusinessPartner partner = new SAPB1.BusinessPartner(); 
               var att =  row.GetType().GetProperty(FieldName).GetAttribute<SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditorAttribute>();
                query = att.Query;
                Regex regex = new Regex("'@.*'");
                var matches = regex.Matches(query);
                System.Collections.Generic.List <string> fieldnames = new System.Collections.Generic.List<string>();
                foreach (Match match in matches)
                {
                    if(match.Success)
                    {
                        var value = match.Value.Replace("@", "").Replace("'", "");
                        fieldnames.Add(value);
                    }
                }
                foreach (var item in fieldnames)
                {
                    var value = row.GetType().GetProperty(item).GetValue(row);
                    query= query.Replace($"@{item}",value.ToString());
                }
                  //Debug.WriteLine(query);

                using (DataTable Datatable = DBHelper.GetTableFromQuery(query, DBName))
                {
                    foreach (var v in Datatable.AsEnumerable())
                    {
                        result.Add(new SelectListItem() { Value = v[0].ToString().Trim() , Text = v[1].ToString().Trim() });

                    }
                }
                //using (var reader = DBHelper.DoQuery(query))
                //{
                //    while (reader.Read())
                //    {
                //        result.Add(new SelectListItem() { Value = reader[0].ToString().Trim() ?? "UMAR", Text = reader[1].ToString().Trim() ?? "UMAR" });
                //    }
                //}
            }
            catch (Exception ex)
            {
                ex.Log();
                (new Exception(query, ex)).Log();
                //todoL log implemntation ex.Log();
            }
            return result;
        }
        public static System.Collections.Generic.List<SelectListItem> Getseries(  string subtype)
        {
            var att = typeof(T).GetAttribute<ServiceLayerAttribute>();
            string ObjectId = att.ObjType;
            switch (subtype)
            {
                case "cCustomer":
                    subtype = "C";
                    break;
                case "cSupplier":
                    subtype = "S";
                    break;
                case "cLid":
                    subtype = "L";
                    break;
                default:
                    break;
            }
            if (string.IsNullOrEmpty(subtype)) subtype = "C";
            System.Collections.Generic.List<SelectListItem> result = new System.Collections.Generic.List<SelectListItem>();
            try
            {
                var query = DBHelper.GetQuery("Query_17");
                string GetItems = string.Format(query, ObjectId, (string.IsNullOrEmpty(subtype) ? "" : @" and nnm1.""DocSubType"" = '" + subtype + "'"));
                //Debug.WriteLine(GetItems);
                //string GetItems =string.Format(@"select ""Series"", ""SeriesName"" from  nnm1 inner join onnm where ""ObjectCode"" = "+ ObjectId+ (string.IsNullOrEmpty(subtype)?"" :@" and ""DocSubType"" = '"+subtype+"'"));
                using (var reader = DBHelper.DoQuery(GetItems))
                {
                    while (reader.Read())
                    {
                        var b = reader["Series"].ToString() == reader["DfltSeries"].ToString();
                        var ismanual = reader["IsManual"].ToString().ToUpper() == "N";
                        result.Add(new SelectListItem() { Value = reader["Series"].ToString(), Text = reader["SeriesName"].ToString(), Selected = b, Disabled = ismanual });
                    }
                } 
            }
            catch(Exception ex)
            {
                ExceptionsController.Log(ex);
                //todoL log implemntation ex.Log();
            }
            return result;
        }
        
        static string pad_an_int(int nextnumber, int Numsize, string SeriesName)
        {
            // string used in ToString() method 
            string s = "";
            for (int i = 0; i < Numsize; i++)
            {
                s += "0";
            }

            // use of ToString() method 
            string value = SeriesName + nextnumber.ToString(s);

            // return output 
            return value;
        }
        
        public static string GetNextNumber(Models.SLModels.ApiData seriesid)
        {
            var series = seriesid.Code;
            var DBName = seriesid.DBName;
            var Str = "";
            if (seriesid != null)
            {
                var query = DBHelper.GetQuery("Query_18", DBName);
                string GetItems = string.Format(query, series);
                //Debug.WriteLine(GetItems);
                //string GetItems =string.Format(@"select ""Series"", ""SeriesName"" from  nnm1 inner join onnm where ""ObjectCode"" = "+ ObjectId+ (string.IsNullOrEmpty(subtype)?"" :@" and ""DocSubType"" = '"+subtype+"'"));
                  var nextnumber = "";
                var PrefixStr = "";
                var Numsize = "";
                try
                {
                    using (var reader = DBHelper.DoQuery(GetItems,DBName))
                    {
                        if(reader.Read())
                        {

                            nextnumber = reader["NextNumber"].ToString();
                            PrefixStr = reader["BeginStr"].ToString();
                            Numsize = reader["NumSize"].ToString();
                        }
                    } 


                    Str = pad_an_int(Convert.ToInt32(nextnumber), Convert.ToInt32(Numsize), PrefixStr);




                }
                catch (Exception ex)
                {
                    ex.Log();
                }
            }
            return Str;
        }

        public static string GetMarketingNextNumber(ApiData seriesid)
        {
            var series = seriesid.Code;
            var DBName = seriesid.DBName;
            var nextnumber = "";
            if (seriesid != null)
            {
                var query = DBHelper.GetQuery("Query_18", DBName);
                string GetItems = string.Format(query, series);
                //Debug.WriteLine(GetItems);
               
                try
                {
                    using (var reader = DBHelper.DoQuery(GetItems,DBName))
                    {
                        if (reader.Read())
                        {
                            nextnumber = reader["NextNumber"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Log();
                }
            }
            return nextnumber;
        }

        public bool IsInApproval(string GUID,string DBName)
        {
            bool IsApproval = false;
            if (GUID != null)
            {
                var query = DBHelper.GetQuery("Query_53", DBName);
                string getStatus = string.Format(query, GUID);
                try
                {
                    using (var reader = DBHelper.DoQuery(getStatus, DBName))
                    {
                        if (reader.Read())
                        {
                            IsApproval = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Log();
                }
            }
            return IsApproval;
        }
        #endregion


        
        public MyResponse CreateUserInSAP(Serenity.Services.SaveRequest<T> request)
        {
            var Response = new MyResponse();
            var att = request.Entity.GetType().GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName;
                var PrimaryKeyName =request.Entity.GetType().GetFieldNameOfAttribute(typeof(SAPPrimaryKeyAttribute));
              
                var json = JObject.FromObject(request.Entity);
                var helper = ServiceLayerRestHandler.GetInstance(Context,request.DBName);
                string response;
                // ExLog.LogToFile(json.ToString());               
                var b = helper.AddToBO<T>(ModuleName, json.ToString(), out response);
                if (!b && json.ContainsKey("U_ApprovalGUID") && JObject.Parse(response)?["error"]?["code"]?.ToString() == "-2028")
                {
                    var GUID = json?["U_ApprovalGUID"]?.ToString();
                    b = IsInApproval(GUID, request.DBName);
                    if (b)
                    {
                        Dictionary<string, object> Approval = new Dictionary<string, object>();
                        Approval.Add("Approval", b);
                        Response.CustomData = Approval;
                    }
                }
                if (!b)
                {
                    Response.EntityId = -1;
                    Response.Error = new ServiceError() { Code = ModuleName, Message = response };
                    ExceptionsController.Log(new Exception("Module:" + ModuleName + " Error: " + response.ToString()));
                    throw new Exception(JObject.Parse(response)?["error"]?["message"]?.ToString());
                }
                else
                {
                    var obj = JObject.Parse(response);
                    Response.EntityId = obj[PrimaryKeyName];
                }
            }
            return Response;
        }
        
        public void RefreshFromSAPPAS()
        {
              var t = typeof(T);  
            var att = t.GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName;
                var key = "";
                var company = "";
                var users = new UsersController(this.Context);
                company = users.getCompanyName(Context.User.Identity.Name);

                //key = username
                key = Context.User.Identity.Name+ company + ModuleName;
                //if key is in DataDictionary
                DataDictionary[key].Refresh = true;
            }
        }

        internal void FillDataDictionary(string username, string password, string companyDB)
        {
            //
            var t = typeof(T);
            var ModuleName = t.GetAttribute<ServiceLayerAttribute>().ModuleName;
            var key = username+ companyDB+ ModuleName;
            //if key is in datadictionary
            if (DataDictionary.ContainsKey(key))
            { 
                    //refresh data
                    DataDictionary[key] = GetDataFromSAP(username, password, companyDB);
                    //set refresh to false
                    DataDictionary[key].Refresh = false; 
            }
            else
            {
                //add to dictionary
                DataDictionary.Add(key, GetDataFromSAP(username, password, companyDB) );
                DataDictionary[key].Refresh = false;
            }
        }

        private ListResponse<T> GetDataFromSAP(string username, string password, string companyDB)
        {
            var response = new ListResponse<T>();
            var t = typeof(T);
            var att = t.GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName;
                var PrimaryKeyName = t.GetFieldNameOfAttribute(typeof(SAPPrimaryKeyAttribute));

                ServiceLayerRestHandler helper = null;
                if (Context != null)
                {
                    helper = ServiceLayerRestHandler.GetInstance(Context);
                }
                else
                {
                    helper = ServiceLayerRestHandler.GetInstance(username, password, companyDB);
                }

                string responseString = "";
                long TotalCount = 0;
                ListRequest lr = new ListRequest();
                //load from settings UseServiceLayerForList
                if (Startup.getConfigValue("UseServiceLayerForList").ToString().ToLower() == "false")
                {
                    lr.DataSourceType = DataSourceType.SAP_DataBase;
                }
                else
                {
                    lr.DataSourceType  = DataSourceType.SAPServiceLayer;
                }
                lr.Sort = new SortBy[] { };
                var b = helper.GetSLList<T>(ModuleName,lr, out responseString, out TotalCount,null, "", null, "",CompanyDB:companyDB,UserName:username);
                 
                if (!b)
                {
                    response.Error = new ServiceError() { Code = ModuleName, Message = responseString };
                    ExceptionsController.Log(new Exception("Module:" + ModuleName + " Error: " + responseString.ToString()));
                    throw new Exception(JObject.Parse(responseString)?["error"]?["message"]?.ToString());
                }
                else
                {
                    if (string .IsNullOrEmpty(responseString))
                    {
                        b = false;
                        throw new Exception($"Response string is empity for Module Name:{ModuleName} User Name :{username}  Company DB :{companyDB}");
                    }
                    var obj = JArray.Parse(responseString);
                    var list = obj.ToObject<System.Collections.Generic.List<T>>();
                    response.Entities = list;
                    response.TotalCount = list.Count;
                }

                response.UserName = username;
                response.DBName = companyDB;
                response.ModuleName = ModuleName;
            }
            return response;
        }
        public static string ConvertFieldNameSL2DB(string fieldName)
        {
            var t = typeof(T);
            var att = t.GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName; 
                var fields = t.GetFields();
                foreach (var field in fields)
                {
                    var att2 = field.GetAttribute<SAPDBFieldNameAttribute>();
                    if (att2 != null)
                    {
                        if (field.Name == fieldName)
                        {
                            return att2.ColumnName;
                        }
                    }
                }
            }
            return fieldName;
        }
        public static string ConvertFieldNameDB2SL(string fieldName)
        {
            var t = typeof(T);
            var att = t.GetAttribute<ServiceLayerAttribute>();
            if (att != null)
            {
                var ModuleName = att.ModuleName;
                var fields = t.GetFields();
                foreach (var field in fields)
                {
                    var att2 = field.GetAttribute<SAPDBFieldNameAttribute>();
                    if (att2 != null)
                    {
                        if (att2.ColumnName == fieldName)
                        {
                            return field.Name;
                        }
                    }
                }
            }
            return fieldName;
        }
    }
}
