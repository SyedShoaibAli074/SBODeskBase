using SAPWebPortal.Web.Modules.Common.Helpers;
using System.Data;
using System.Linq;
using Serenity.Data;
using SAPWebPortal.Default;
using System;
using SAPWebPortal.Administration.Columns;
using SAPWebPortal.Administration.Endpoints;

namespace SAPWebPortal.Web.DependencyInjections
{
    public interface IChangeTracking
    {
        public void Initialize();
    }


    public class ChangeTracking : IChangeTracking 
    {
        IDbConnection _dbConnection;
        public ChangeTracking(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Initialize()
        {
            var Rows=_dbConnection.List<SapDatabasesRow>().ToList();
            
            try
            {
                foreach (var r in Rows)
                {

                    try
                    {
                        DBHelper.DoQuery(DBHelper.GetQuery("Query_63_Create_AB_CTRK", r.CompanyDb), r.CompanyDb);
                        DBHelper.DoQuery(DBHelper.GetQuery("Query_64_Create_AB_TRKOBJ", r.CompanyDb), r.CompanyDb);
                        DBHelper.DoQuery(DBHelper.GetQuery("Query_65_Create_Expiry", r.CompanyDb), r.CompanyDb);


                        string[] splitter = new string[] { "GO" };
                        string[] Query_66_CreateProcedure_GET_CHANGES = DBHelper.GetQuery("Query_66_CreateProcedure_GET_CHANGES", r.CompanyDb).Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string commandText in Query_66_CreateProcedure_GET_CHANGES)
                        {
                            DBHelper.DoQuery(commandText, r.CompanyDb);

                        }


                        string[] Query_67_CreateFunction_AB_VN = DBHelper.GetQuery("Query_67_CreateFunction_AB_VN", r.CompanyDb).Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string commandText in Query_67_CreateFunction_AB_VN)
                        {
                            DBHelper.DoQuery(commandText, r.CompanyDb);

                        }

                        string[] Query_68_CreateProcedure_ChangeTracking = DBHelper.GetQuery("Query_68_CreateProcedure_ChangeTracking", r.CompanyDb).Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string commandText in Query_68_CreateProcedure_ChangeTracking)
                        {
                            DBHelper.DoQuery(commandText, r.CompanyDb);

                        }



                        DBHelper.DoQuery(DBHelper.GetQuery("Query_69_CreateTable_Log", r.CompanyDb), r.CompanyDb);

                        var AB_TRKOBJRows = DBHelper.GetTableFromQuery(DBHelper.GetQuery("Query_70_Check_AB_TRKOBJ", r.CompanyDb), r.CompanyDb);

                        if (AB_TRKOBJRows.Rows.Count == 0)
                        {
                            DBHelper.DoQuery(DBHelper.GetQuery("Query_71_InsertInto_AB_TRKOBJ", r.CompanyDb), r.CompanyDb);

                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionsController.Log(ex);
                       // throw;
                    }

                }
            }
            catch (Exception ex)
            {

                //throw;
            }


        }


        
    
    }

}
