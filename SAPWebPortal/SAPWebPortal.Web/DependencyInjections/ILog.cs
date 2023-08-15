using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Default;
using Serenity.Data;
using System;
using System.Data.SqlClient;

namespace SAPWebPortal.Web.DependencyInjections
{
    public interface ILog
    {
        public void Log(Default.LogRow log);
    }
    public class Logger : ILog
    {
        ISqlConnections _sqlConnections;
        public Logger(ISqlConnections sqlConnections) {

            _sqlConnections= sqlConnections;


        } 
        public void Log(LogRow log)
        {
            try
            {
                var conn = _sqlConnections.NewByKey("Default");
                
                
                    //conn.Open();
                    var query = @$"INSERT INTO Log(U_DateTime,U_Direction,U_Error,U_Response,U_ObjType,ShopifyID,ShopifyPayload) 
                           VALUES(@U_DateTime,@U_Direction,@U_Error,@U_Response,@U_ObjType,@ShopifyID,@ShopifyPayload)";
                    var connection = new SqlConnection(conn.ConnectionString);
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@U_DateTime", log.UDateTime);
                        command.Parameters.AddWithValue("@U_Direction", log.UDirection ?? "");
                        command.Parameters.AddWithValue("@U_Error", log.UError ?? "");
                        command.Parameters.AddWithValue("@U_Response", log.UResponse ?? "");
                        command.Parameters.AddWithValue("@U_ObjType", log.UObjType ?? "");
                        command.Parameters.AddWithValue("@ShopifyID", log.ShopifyId??"");
                        command.Parameters.AddWithValue("@ShopifyPayload", log.ShopifyPayload ?? "");

                        command.ExecuteNonQuery();
                    }
               
                    
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
                //throw;
            }


        }
    }
}
