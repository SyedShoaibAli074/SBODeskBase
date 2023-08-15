
using SAPWebPortal.Administration.Endpoints;
using Sap.Data.Hana;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal;
using Serenity.Data;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace SAPWebPortal.Web.Modules.Common.Helpers
{
    public static class DBHelper
    {

    
        /// <summary>
        /// SAP Connection
        /// </summary>
        /// <returns></returns>
        internal static IDbConnection GetDBConnection()
        {
            IDbConnection connection;
            if (SapDatabasesController.isHana())
            {
                var row = SapDatabasesController.Row;
                var conctionstring = string.Format("DRIVER={{HDBODBC}};UID={1};PWD={2};SERVERNODE={0};POOLING=TRUE;Max Pool Size=1000", row.ODBCServer, row.DbUserName,AES.DecryptString( row.DbPassword));

                connection = new HanaConnection(conctionstring);
                connection.Open();

                var setscema = string.Format("SET SCHEMA {0}", row.CompanyDb);
                var myCommand = new HanaCommand(setscema, (HanaConnection)connection);
                myCommand.ExecuteNonQuery();
            }
            else
            {
                var row = SapDatabasesController.Row;
                var connectionstring = string.Format("Data Source={0};User ID={1};Password={2};Integrated security=False;database={3}", row.ServerName, row.DbUserName, AES.DecryptString(row.DbPassword), row.CompanyDb);
                connection = new SqlConnection(connectionstring);


            }
            return connection;
        }
        /// <summary>
        /// SAP Connection
        /// </summary>
        /// <param name="odbcserver"></param>
        /// <param name="companydb"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="dbservertype"></param>
        /// <param name="odbcDriver"></param>
        /// <returns></returns>
        public static IDbConnection GetDBConnection(string odbcserver,string companydb,string username,string password,string dbservertype,string odbcDriver="")
        {
            IDbConnection connection;
            if (dbservertype == "dst_HANADB")
            {
                if (odbcDriver == "") odbcDriver = "HDBODBC";
                var conctionstring = string.Format("DRIVER={{{3}}};UID={1};PWD={2};SERVERNODE={0};POOLING=TRUE;Max Pool Size=1000", odbcserver, username, password, odbcDriver);

                connection = new HanaConnection(conctionstring);
                connection.Open();

                var setscema = string.Format("SET SCHEMA {0}", companydb);
                var myCommand = new HanaCommand(setscema, (HanaConnection)connection);
                myCommand.ExecuteNonQuery();
            }
            else
            {
                //"Server=sap;Database=ABiT_SBO_Desk;Persist Security Info=true;User ID=sa;Password=P($$30r)"
                var connectionstring = string.Format("Server={0};User ID={1};Password={2};Database={3}", odbcserver, username, password, companydb);
                connection = new SqlConnection(connectionstring);
                connection.Open();

            }
            return connection;
        }
        /// <summary>
        /// SAP Connection
        /// </summary>
        /// <param name="SAPCompanyDB"></param>
        /// <returns></returns>
        internal static IDbConnection GetDBConnection(String SAPCompanyDB)
        {
            IDbConnection connection = null;
            if (SapDatabasesController.isHana(SAPCompanyDB))
            {
                
                var row = SapDatabasesController.SAPRow(SAPCompanyDB);
                var conctionstring = string.Format("DRIVER={{{3}}};UID={1};PWD={2};SERVERNODE={0};POOLING=TRUE;Max Pool Size=1000", row.ODBCServer, row.DbUserName,AES.DecryptString( row.DbPassword), row.DBDriver);

                connection = new HanaConnection(conctionstring);
                connection.Open();

                var setscema = string.Format("SET SCHEMA {0}", SAPCompanyDB);
                var myCommand = new HanaCommand(setscema, (HanaConnection)connection);
                myCommand.ExecuteNonQuery();
            }
            else
            {
                var row = SapDatabasesController.SAPRow(SAPCompanyDB);
                var connectionstring = string.Format("Data Source={0};User ID={1};Password={2};Integrated security=False;database={3}", row.ServerName, row.DbUserName,AES.DecryptString( row.DbPassword), row.CompanyDb);
                connection = new SqlConnection(connectionstring);


            }
            return connection;
        }
        public static IDataReader DoQuery(string query,string DBName="")
        {
            IDataReader resultSet = null;
            try
            {
                using (var connection = DBHelper.GetDBConnection(DBName))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        resultSet = command.ExecuteReader();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                //throw;
            }
            return resultSet;
        }public static IDataReader DoNonQuery(string query,string DBName="")
        {
            IDataReader resultSet = null;
            try
            {
                using (var connection = DBHelper.GetDBConnection(DBName))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

              //  throw;
            }
            return resultSet;
        }
        /// <summary>
        /// SAP SQL Command
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="dbConnection"></param>
        /// <returns></returns>
        internal static DbCommand GetDbCommand(string commandText, IDbConnection dbConnection)
        {
            DbCommand dbCommand=null;
            try
            {
                if (dbConnection is HanaConnection)
                {
                    dbCommand = new HanaCommand(commandText, (HanaConnection)dbConnection);
                }
                else
                {
                    dbCommand = new SqlCommand(commandText, (SqlConnection)dbConnection);
                }
            }
            catch (Exception ex)
            {

                //throw;
            }
            return dbCommand;

        }

        public static DataTable GetTableFromQuery(string query,string DBName="")
        {
            var dt = new DataTable();
            try
            {
                using (var dbConnection = GetDBConnection(DBName))
                {
                    if(dbConnection.State != ConnectionState.Open)
                        dbConnection.Open();    
                    try
                    {
                        using (var command = GetDbCommand(query, dbConnection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        ExceptionsController.Log(Ex, query);
                    }
                    finally{
                        dbConnection.Close();
                    } 
                }
                return dt;
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex, query);
                return null;
            }
            
        }
        public static DataTable GetTableFromQuery(string query,IDbConnection dbConnection,string primarykeyname = "")
        {
            var dt = new DataTable();  
            // if(!string.IsNullOrEmpty(primarykeyname))
            //     dt.PrimaryKey = new DataColumn[]{ new DataColumn(){ ColumnName =  primarykeyname} };
            
            try
            {
                    try
                    {
                    //if dbconnection is not open then open
                    if (dbConnection.State != ConnectionState.Open) dbConnection.Open();
                    //Debug.WriteLine(query);
                    Sentry.SentrySdk.CaptureMessage(query);
                    using (var command = GetDbCommand(query, dbConnection))
                        { 
                            using (var reader = command.ExecuteReader())
                            { 
                                 
                                dt.Load(reader);
                                reader.Close();
                            }
                        }

                    }
                    catch (Exception Ex)
                    {
                        ExceptionsController.Log(Ex);
                        ExceptionsController.Log(new Exception(query, Ex));
                    }
                    finally{
                        dbConnection.Close();
                    }
             
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex, query);
            }
            return dt;
        }
        /// <summary>
        /// Get Db Connection for serenity
        /// </summary>
        /// <returns></returns>
        internal static System.Data.IDbConnection GetSerenDBConnection()
        {
            return new System.Data.SqlClient.SqlConnection(SAPWebPortal.Startup.connectionString);
        }
        #region Query Handlers 
        internal static string GetQuery(string key,string DBName="")
        {
            string DbServerType = "sql";
            DbServerType = GetSAPDbServerType(DBName);
            var xmlPathBuilder = new StringBuilder("/Queries/Query[@name=\"{0}\"]/");

            if (DbServerType.ToLower() == "dst_HANADB".ToLower())
                xmlPathBuilder.Append("HANA").ToString();
            else
                xmlPathBuilder.Append("SQL").ToString();

            var path = "";
            if (!Startup.isTest)
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "App_Data\\Queries\\Queries.xml");
            else
                path = Startup._Configuration["QueryPath"];
            return GetXmlNodeValue(path, string.Format(xmlPathBuilder.ToString(), key));
        }
        //static string servertype = "";
        private static string GetSAPDbServerType(string DBName)
        {
            SapDatabasesController.isHana(DBName);
            return SapDatabasesController.SAPRow(DBName).DbServerType;
        }
        static string GetXmlNodeValue(string file, string xPath)
        {
            var doc = new System.Xml.XmlDocument();
            doc.Load(file);
            var xmlPath = string.Empty;
            var node = doc.DocumentElement.SelectSingleNode(xPath);
            return node.InnerText;
        }
        public static DbDataReader GetDbDataReaderFromQuery(string Query,string DBName)
        {
            var table = GetTableFromQuery(Query, DBName);
            DbDataReader reader = table.CreateDataReader();
            return reader;
        }

        internal static bool ColumnExistsInTable(string tablename, string v,string DBName)
        {
            var ishana = SapDatabasesController.isHana(DBName);
            var issqlserver = !ishana;
            
            var query = "";
            
            if (ishana)
                query = string.Format("SELECT * FROM SYS.TABLE_COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", tablename, v);
            else
                query = string.Format("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}' AND COLUMN_NAME = '{1}'", tablename, v); 
            var dt = GetTableFromQuery(query, DBName);
            return dt.Rows.Count > 0;
        }
        #endregion
    }
    public class JsonData
    {
        public string rptPath { get; set; }
        public int DocEntry { get; set; }
        public int ObjectCode { get; set; }
        public string ServerName { get; set; }
        public string CompanyDB { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }
        public string pdfPath { get; set; }
    }
}
