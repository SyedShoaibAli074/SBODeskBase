using B1SLayer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Default;
using SAPWebPortal.Orders;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity;
using Serenity.Data;
using ShopifySharp.Entities;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;


namespace SAPWebPortal.Web.DependencyInjections
{
    public interface IB1ServiceLayer
    {
        public T Create<T>(T row, string DBName);
        public void Update<T>(T row , string DBName);
        public T GetSLEntity<T>(T row , string DBName);
        public System.Collections.Generic.List<T> GetSLList<T>(string DBName);
        public void CancelDocument<T>(T row, string storeName);
        public System.Collections.Generic.List<T> FromTabletoObject<T>(System.Data.DataTable table);
        
    }

    public class B1ServiceLayer : IB1ServiceLayer
    {
        private ISqlConnections sqlConnections = null;
        private SLConnection _serviceLayer = null;
        public B1ServiceLayer(ISqlConnections sqlConnections)
        {
            this.sqlConnections = sqlConnections;
             
        }
        //Create Business Object
        public T Create<T>(T row,string DBName)
        {
            T res = default(T);
            
            res=AddBO<T>(row, DBName);
            
            return res;
        }
        //Create Business Object
        public void Update<T>(T row, string DBName)
        {
            try
            {
                UpdateBO<T>(row, DBName);
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
               // throw;
            }
        }
        
        
        

        private void ConnectSL(string DBName=null)
        {
            try
            {
                if(!String.IsNullOrEmpty(DBName))
                {
                    using (var con = this.sqlConnections.NewFor<SapDatabasesRow>())
                    {
                        con.Open();
                        var creds = con.List<SapDatabasesRow>().First();
                        this._serviceLayer = new SLConnection(creds.ServiceLayerUrl + "b1s/v2/", creds.CompanyDb, creds.UserName, AES.DecryptString(creds.Password));

                    }
                }
                
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
                //throw;
            }
        }
        private T AddBO<T>(T row,string DBName)
        {
            if (_serviceLayer == null)
            {
                ConnectSL(DBName);
            }
            var json = JObject.FromObject(row);
            var PropertyToRemove = json.Property("DBName");
            if (PropertyToRemove != null)
            {
                PropertyToRemove.Remove();

            }
            var attributeobj=row.GetType().GetAttribute<ServiceLayerAttribute>();
            T response = default(T);
            
                if(row.GetType() == typeof(Modules.Returns.DocumentRow))
                {
                    ExceptionsController.Log(new Exception("DataforReturn"), JsonConvert.SerializeObject(row));

                }
                else
                {
                    //ExceptionsController.Log(new Exception("Data"), JsonConvert.SerializeObject(row));

                }
                response = this._serviceLayer.Request(attributeobj.ModuleName).PostAsync<T>(json).GetAwaiter().GetResult();

                return response;
           

             


        }
        private void UpdateBO<T>(T row, string DBName)
        {
            if (_serviceLayer == null)
            {
                ConnectSL(DBName);
            }
            var json = JObject.FromObject(row);
            var PropertyToRemove = json.Property("DBName");
            if (PropertyToRemove != null)
            {
                PropertyToRemove.Remove();

            }
            var attributeobj = row.GetType().GetAttribute<ServiceLayerAttribute>();
            SLRequest req = null;
            if (typeof(BusinessPartnerRow) == row.GetType())
            {
                var _row = row as BusinessPartnerRow;
                req = this._serviceLayer.Request(attributeobj.ModuleName, _row.CardCode);
            }
            else if (typeof(ItemRow) == row.GetType())
            {
                var _row = row as ItemRow;
                req = this._serviceLayer.Request(attributeobj.ModuleName, _row.ItemCode);
            }
            else if (typeof(Orders.DocumentRow) == row.GetType())
            {
                var _row = row as Orders.DocumentRow;
                req = this._serviceLayer.Request(attributeobj.ModuleName, _row.DocEntry);
            } 
            else if (typeof(APInvoice.DocumentRow) == row.GetType())
            {
                var _row = row as Orders.DocumentRow;
                req = this._serviceLayer.Request(attributeobj.ModuleName, _row.DocEntry);
            }
            //ExceptionsController.Log(new Exception("Data"), JsonConvert.SerializeObject(row));

            req = req.WithReplaceCollectionsOnPatch();
            req.PatchStringAsync(json.ToString()).GetAwaiter().GetResult();
        }
        public T GetSLEntity<T>(T row, string DBName)
        {
            if (_serviceLayer == null)
            {
                ConnectSL(DBName);
            }

            var attributeobj = row.GetType().GetAttribute<ServiceLayerAttribute>();
            T req = default(T);
            
            try
            {
                if (typeof(BusinessPartnerRow) == row.GetType())
                {
                    var _row = row as BusinessPartnerRow;
                    req = this._serviceLayer.Request(attributeobj.ModuleName, _row.CardCode).GetAsync<T>().Result; ;
                }
                else if (typeof(ItemRow) == row.GetType())
                {
                    var _row = row as ItemRow;
                    //ExceptionsController.Log(new Exception("Item"),JsonConvert.SerializeObject(_row));

                    req = this._serviceLayer.Request(attributeobj.ModuleName, _row.ItemCode).GetAsync<T>().Result; ;
                }
                else if (typeof(Orders.DocumentRow) == row.GetType())
                {
                    var _row = row as Orders.DocumentRow;
                    req = this._serviceLayer.Request(attributeobj.ModuleName, _row.DocEntry).GetAsync<T>().Result; ;
                }
                else if (typeof(ARInvoice.DocumentRow) == row.GetType())
                {
                    var _row = row as Orders.DocumentRow;
                    req = this._serviceLayer.Request(attributeobj.ModuleName, _row.DocEntry).GetAsync<T>().Result; ;
                }
                else if (typeof(APInvoice.DocumentRow) == row.GetType())
                {
                    var _row = row as Orders.DocumentRow;
                    req = this._serviceLayer.Request(attributeobj.ModuleName, _row.DocEntry).GetAsync<T>().Result; ;
                }
                else if (typeof(Delivery.DocumentRow) == row.GetType())
                {
                    var _row = row as Delivery.DocumentRow;
                    req = this._serviceLayer.Request(attributeobj.ModuleName, _row.DocEntry).GetAsync<T>().Result; ;
                }
                else if (typeof(SAPWebPortal.Web.Modules.DownPayment.DocumentRow) == row.GetType())
                {
                    var _row = row as SAPWebPortal.Web.Modules.DownPayment.DocumentRow;
                    req = this._serviceLayer.Request(attributeobj.ModuleName, _row.DocEntry).GetAsync<T>().Result; ;
                }
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
               // throw;
            }
            return req;
        }
        public void CancelDocument<T>(T row, string storeName)
        {
            try
            {
                if (_serviceLayer == null)
                {
                    ConnectSL();
                }
                SLRequest req = null;
                if (row.GetType() == typeof(Orders.DocumentRow))
                {
                    var orderrow =  row as Orders.DocumentRow;
                    req = this._serviceLayer.Request(@$"Orders({orderrow.DocEntry})/Cancel");


                    req.PostAsync<Orders.DocumentRow>().GetAwaiter().GetResult();
                }
                
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
                throw;
            }
        }
        public System.Collections.Generic.List<T> FromTabletoObject<T>(System.Data.DataTable table)
        {
            System.Collections.Generic.List<T> obj = new System.Collections.Generic.List<T>();
            //convert table to T
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(table);
            obj = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<T>>(json);

            return obj;
        }

        public System.Collections.Generic.List<T> GetSLList<T>(string DBName)
        {
            if (_serviceLayer == null)
            {
                ConnectSL(DBName: DBName);
            }

            var attributeobj = (typeof(T)).GetAttribute<ServiceLayerAttribute>();
            System.Collections.Generic.List<T> req = default(System.Collections.Generic.List<T>);

            try
            {
                if (typeof(BusinessPartnerRow) == (typeof(T)))
                {
                    req = this._serviceLayer.Request(attributeobj.ModuleName).GetAllAsync<T>().Result.ToList();
                }
                else if (typeof(ItemRow) == (typeof(T)))
                {

                    req = this._serviceLayer.Request(attributeobj.ModuleName).GetAllAsync<T>().Result.ToList();
                }
                
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
                // throw;
            }

            return req;
        }
    }
}

