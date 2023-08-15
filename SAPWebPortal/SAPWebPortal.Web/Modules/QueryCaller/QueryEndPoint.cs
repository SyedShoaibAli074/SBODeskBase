//make a class to serve as the controller and the endpoint
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SAPWebPortal.Modules.QueryCaller
{
    [Route("Services/Queries/List/[action]")]
    public class QueryController : ServiceEndpoint
    {
        [HttpPost, IgnoreAntiforgeryToken]
        public List<OWHS> OWHS(Request request)
        {
            var result = new List<OWHS>();
            var conncetion = DBHelper.GetDBConnection(request.DBName);
            var query = @$"select ""WhsCode"",""WhsName"" from OWHS";
            var tablename = DBHelper.GetTableFromQuery(query, conncetion);
            foreach (DataRow row in tablename.Rows)
            {
                result.Add(new OWHS
                {
                    WhsCode = row["WhsCode"].ToString(),
                    WhsName = row["WhsName"].ToString()
                });
            }
            return result;
        }
        [HttpPost, IgnoreAntiforgeryToken]
        public List<OITW> OITW(Request request)
        {
            var result = new List<OITW>();
            var conncetion = DBHelper.GetDBConnection(request.DBName);
            var query = $@"select OITW.""ItemCode"",OITW.""WhsCode"",OITW.""OnHand"", OWHS.""WhsName"" from OITW inner join OWHS on OITW.""WhsCode""=OWHS.""WhsCode""";
            var tablename = DBHelper.GetTableFromQuery(query, conncetion);
            foreach (DataRow row in tablename.Rows)
            {
                result.Add(new OITW
                {
                    ItemCode = row["ItemCode"].ToString(),
                    WhsCode = row["WhsCode"].ToString(),
                    WhsName = row["WhsName"].ToString(),
                    OnHand = Convert.ToDouble(row["OnHand"].ToString())
                });
            }
            return result;
        }
        [HttpPost, IgnoreAntiforgeryToken]
        public String GetDefaultWhsCode(Request request)
        {
            var result = "";
            using (var connection = DBHelper.GetSerenDBConnection())
            {
                //select WarehouseCode from users where Username = 'manager'
                var query = $@"select WarehouseCode from users where Username = '{request.Username}'";
                using (var tablename = DBHelper.GetTableFromQuery(query, connection))
                {
                    foreach (DataRow row in tablename.Rows)
                    {
                        result = row["WarehouseCode"].ToString();
                    }
                }
            }
            return result;

        }
        [HttpPost, IgnoreAntiforgeryToken]
        public List<STOCK_STATUS> GET_STOCK_STATUS(Request request)
        {

            var result = new List<STOCK_STATUS>();
            var conncetion = DBHelper.GetDBConnection(request.DBName);
            var defaultwarehousecode = GetDefaultWhsCode(request);

            var query = $@"select c.""ItemCode"",""ItemName"",a.""OnHand"",b.""WhsCode"",""WhsName"",c.""InvntryUom"" ""UOMCode""
                        from OITW a inner join owhs b on a.""WhsCode"" = b.""WhsCode""   
                        inner join oitm c on c.""ItemCode"" = a.""ItemCode"" 
                        where b.""WhsCode"" = '{defaultwarehousecode}'  
                        order by a.""OnHand"" desc";

            var tablename = DBHelper.GetTableFromQuery(query, conncetion);
            foreach (DataRow row in tablename.Rows)
            {
                double onHand = 0.0;
                Double.TryParse(row["OnHand"].ToString(), out onHand);
                result.Add(new STOCK_STATUS
                {
                    ItemCode = row["ItemCode"].ToString(),
                    ItemName = row["ItemName"].ToString(),
                    OnHand = onHand,
                    WhsCode = row["WhsCode"].ToString(),
                    WhsName = row["WhsName"].ToString(),
                    UomCode = row["UOMCode"].ToString()
                });
            }
            return result;
        }

        // SELECT T0."ItemCode", T0."CardCode"  FROM OSCN T0
        [HttpPost, IgnoreAntiforgeryToken]
        public List<OSCN> Get_Table_OSCN(Request request)
        {
            var result = new List<OSCN>();
            var conncetion = DBHelper.GetDBConnection(request.DBName);
            var query = @$"select ""ItemCode"",""CardCode"" from OSCN";
            var tablename = DBHelper.GetTableFromQuery(query, conncetion);
            foreach (DataRow row in tablename.Rows)
            {
                result.Add(new OSCN
                {
                    ItemCode = row["ItemCode"].ToString(),
                    CardCode = row["CardCode"].ToString()
                });
            }
            return result;
        }

        [HttpPost, IgnoreAntiforgeryToken]
        public List<SAPWebPortal.Default.ItemRow> Getitems(Request request)
        {
            var result = new List<SAPWebPortal.Default.ItemRow>();
            var conncetion = DBHelper.GetDBConnection(request.DBName);
            var query = @$"select ""ItemCode"",""ItemName"" from OITM";
            var tablename = DBHelper.GetTableFromQuery(query, conncetion);
            foreach (DataRow row in tablename.Rows)
            {
                result.Add(new SAPWebPortal.Default.ItemRow
                {
                    ItemCode = row["ItemCode"].ToString(),
                    ItemName = row["ItemName"].ToString()
                });
            }
            return result;
        }
        [HttpPost, IgnoreAntiforgeryToken]
        public JArray GetObjects(Request request)
        {
            JArray result = new JArray();
            if (!string.IsNullOrEmpty(request.Query))
            {
                //Header_DocEntry:"select * from OQUT",DocumentLines_DocEntry:"select * from qut1" 
                var queries = request.Query.Split(";");
                var headerquery = queries[0].Split(":")[1];
                var key = queries[0].Split(":")[0].Split("_")[1];

                

                var header = DBHelper.GetTableFromQuery(headerquery, request.DBName);

                    var headerjarray = JArray.Parse(JsonConvert.SerializeObject(header));
                System.Data.DataTable detail = null;
                try
                {
                    //loop the header and get the list of key
                    var keys = new List<string>();
                    foreach (DataRow row in header.Rows)
                    {
                        keys.Add(row[key].ToString());
                    }
                    //csv of keys for where clause in detail query
                    if (keys.Count > 0)
                    {
                        var keycsv = string.Join(",", keys);
                        if (!string.IsNullOrEmpty(queries[1]))
                        {
                            var detailquery = queries[1].Split(":")[1];
                            // apend the where clause to the detail query
                            var key2 = queries[1].Split(":")[0].Split("_")[1];
                            detailquery = detailquery + $" where {key2} in ({keycsv})";
                            // convert header to jarray
                            detail = DBHelper.GetTableFromQuery(detailquery, request.DBName);
                        }
                    }
                }catch (Exception ex)
                {
                    ex.Log();
                }
                //loop through headerjarray and add the detail query result to the header where the key matches
                foreach (JObject obj in headerjarray)
                {
                    if(detail !=null)
                    { 
                        var keyvalue = obj[key].ToString();
                        var detailjarray = JArray.Parse(JsonConvert.SerializeObject(detail));
                        var detailjarray2 = new JArray();
                        foreach (JObject obj2 in detailjarray)
                        {
                            var key2 = queries[1].Split(":")[0].Split("_")[1];
                            if (obj2[key2].ToString() == keyvalue)
                            {
                                detailjarray2.Add(obj2);
                            }
                        }
                        var DetailName = queries[1].Split(":")[0].Split("_")[0];
                        obj.Add(DetailName, detailjarray2);
                    }
                    result.Add(obj);
                }
            }
            else
            {
                var   query = @$"select {request.Columns ?? "*"} from {request.TableName}";
                var table = DBHelper.GetTableFromQuery(query, request.DBName); 
                // Convert DataTable to JArray
                foreach (DataRow row in table.Rows)
                {
                    JObject obj = new JObject();
                    foreach (DataColumn col in table.Columns)
                    {
                        obj.Add(col.ColumnName, JToken.FromObject(row[col]));
                    }
                    result.Add(obj);
                }
            }

            return result;
        }

        public static JArray MergeFields(JArray input)
        {
            //get first field name
            JArray output = new JArray();
            foreach (JObject obj in input)
            {
                JObject header = new JObject();
                JArray details = new JArray();

                bool headerDone = false;
                var seperatorTag = "";
                //first property name
                foreach (JProperty prop in obj.Properties())
                {
                    if (prop.Name == "saparator")
                    {
                        seperatorTag = prop.Value.ToString();
                        headerDone = true;
                        continue;
                    }

                    if (!headerDone)
                    {
                        header.Add(prop);
                    }
                    else
                    {
                        details.Add(prop);
                    }
                }

                header.Add(seperatorTag, details);
                output.Add(header);
            }

            return output;
        }

        [HttpPost, IgnoreAntiforgeryToken]
        public bool PostObject(Request request)
        {

            return true;
        }


    }
    public class OSCN
    {
        public string ItemCode { get; set; }
        public string CardCode { get; set; }
    }
    public class Request
    {
        public string TableName { get; set; }
        public string DBName { get; set; }
        public string Username { get; set; }
        public string Columns { get; set; }
        public string Payload { get; set; }
        public string Query { get; set; }
    }
    public class OWHS
    {
        public string WhsCode { get; set; }
        public string WhsName { get; set; }
    }
    public class OITW
    {
        public string WhsCode { get; set; }
        public string WhsName { get; set; }
        public string ItemCode { get; set; }
        public double OnHand { get; set; }
    }

    public class STOCK_STATUS
    {
        public String ItemCode { get; set; }
        public String ItemName { get; set; }
        public String WhsCode { get; set; }
        public String WhsName { get; set; }
        public double OnHand { get; set; }
        public String UomCode { get; set; }
    }
}