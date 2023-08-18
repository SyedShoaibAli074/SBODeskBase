using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Web.DependencyInjections;
using SAPWebPortal.Web.Modules.Common.Helpers;
using SAPWebPortal.Web.Modules.SAPApp;
using SAPWebPortal.Default;
using Serenity.Data;
using System;
using System.Linq;
using System.Data;
using Serenity;
using Serenity.Services;
using System.Data.SqlClient;

namespace SAPWebPortal.Web.Modules.ARInvoiceToAPInvoiceIntegration
{
    interface IARInvoiceToAPInvoiceIntegration
    {
        public void IterationFunc();
    }
    public class ARInvoiceToAPInvoiceIntegration
    {
        IB1ServiceLayer _iB1ServiceLayer;
        IDbConnection _dbConnection;

        public ARInvoiceToAPInvoiceIntegration()
        {
            _iB1ServiceLayer = new B1ServiceLayer().SLConnection();
            _dbConnection = DBHelper.GetSerenDBConnection();
        }
        public APInvoice.DocumentRow generateAPInvoicefromARInvoice(ARInvoice.DocumentRow ARrow,string DBName)
        {




            APInvoice.DocumentRow AProw = new APInvoice.DocumentRow();
            var DT=DBHelper.GetTableFromQuery(@$"Select ConnBP from OCRD Where CardCode='{ARrow.CardCode}'", DBName);
            var ConnBP=_iB1ServiceLayer.FromTabletoObject<BusinessPatrner>(DT)?.FirstOrDefault();
            if(ConnBP!=null && !String.IsNullOrEmpty(ConnBP.ConnBP))
            {
                AProw.CardCode = ConnBP.ConnBP;

            }
            AProw.U_ARInvoiceNo = ARrow.DocNum.ToString();
            AProw.DocDate = DateTime.Now;
            AProw.DocDueDate = DateTime.Now;
            AProw.DocType = "dDocument_Service";
            AProw.DocObjectCode = "oPurchaseInvoices";
            AProw.BPL_IDAssignedToInvoice = ARrow.BPL_IDAssignedToInvoice;
            AProw.Comments = @$"Document Based on A/R Invoice No. {ARrow.DocNum}.";
            var lines = new System.Collections.Generic.List<APInvoiceLine.DocumentLineRow>();
            foreach (var r in ARrow.DocumentLines)
            {
                try
                {
                    var line = new APInvoiceLine.DocumentLineRow();
                    line.ItemDescription = "Trade Profit Amount";
                    line.AccountCode = "20030009";
                    //line.AccountCode = "101000";
                    line.LineTotal = Convert.ToDecimal(r.U_Payable);
                    line.U_CustOrderNo = r.U_CustOrderNo;

                    lines.Add(line);
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }


            AProw.DocumentLines = lines;


            return AProw;

        }

        public void PostAPInvoice(string DBName)
        {
            var LocalDBName = DBHelper.GetSerenDBConnection();
            var getChanges = DBHelper.GetTableFromQuery(String.Format("exec [dbo].[ARGET_CHANGES] {0}, '{1}'", 0, LocalDBName.Database), DBName);

            var Changes = _iB1ServiceLayer.FromTabletoObject<GetChangesObject>(getChanges).ToList();
            if (Changes.Count() != 0)
            {
                foreach (var s in Changes)
                {


                    try
                    {
                        var _ARRow = _iB1ServiceLayer._GetSLEntity<ARInvoice.DocumentRow>(new ARInvoice.DocumentRow() { DocEntry = Convert.ToInt32(s.U_Key) }, DBName);

                        if (!_ARRow.DocumentLines.Any(x => String.IsNullOrEmpty(x.U_Payable)))
                        {
                            var AProw = generateAPInvoicefromARInvoice(_ARRow, DBName);

                            var response = _iB1ServiceLayer._Create<APInvoice.DocumentRow>(AProw, DBName);

                            if (response != null && !String.IsNullOrEmpty(response?.DocNum.ToString()))
                            {
                                CreateOrUpdateLog(s, "Y");

                            }

                        }

                        
                    }
                    catch (Exception ex)
                    {
                        CreateOrUpdateLog(s,"N");
                        ExceptionsController.Log(ex, s.ToJson());
                        //throw;
                    }

                }


            }


           
        }
        private void CreateLog(GetChangesObject _object,string SyncStatus)
        {
            Serenity.Data.SqlInsert insert = new SqlInsert("SAPToShopifySyncLog");
            insert.SetTo("DocEntry", @$"'{_object.DocEntry}'");
            insert.SetTo("SyncStatus", @$"'{SyncStatus}'");
            insert.SetTo("TargetStoreId", @$"'N/A'");
            insert.SetTo("SourceObjType", @$"'{_object.U_ObjType}'");
            insert.SetTo("SyncTime", @$"'{DateTime.Now}'");
            insert.Execute(_dbConnection);
        }
        private void CreateOrUpdateLog(GetChangesObject _object, string SyncStatus)
        {
            using (var conn = new SqlConnection(Startup.connectionString))
            {
                conn.Open();
                string selectQuery = $"SELECT DocEntry FROM SAPToShopifySyncLog WHERE DocEntry = '{_object.DocEntry}' AND SourceObjType = '{_object.U_ObjType}'";
                using (var cmd = new SqlCommand(selectQuery, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Record exists, update it
                        {
                            string updateQuery = $@"UPDATE SAPToShopifySyncLog
                                        SET SyncStatus = '{SyncStatus}'
                                        WHERE DocEntry = '{_object.DocEntry}' AND SourceObjType = '{_object.U_ObjType}'";
                            reader.Close();
                            using (var updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else // Record does not exist, create it
                        {
                            var insert = new SqlInsert("SAPToShopifySyncLog")
                                .SetTo("DocEntry", @$"'{_object.DocEntry}'")
                                .SetTo("SyncStatus", @$"'{SyncStatus}'")
                                .SetTo("TargetStoreId", @$"'N/A'")
                                .SetTo("SourceObjType", @$"'{_object.U_ObjType}'")
                                .SetTo("SyncTime", @$"'{DateTime.Now}'");
                            insert.Execute(_dbConnection);
                        }
                    }
                }
                conn.Close();
            }
           
        }

        public void IterationFunc()
        {

            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(IterationWorker);
            t.Interval = 10000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        }

        protected void IterationWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Stop();

            try
            {
                var SAPDatabases = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().ToList();
                foreach (var r in SAPDatabases)
                {
                    PostAPInvoice(r.CompanyDb);
                }
            }
            catch (Exception ex)
            {
                ex.Log();
            }
            finally
            {
                ((System.Timers.Timer)sender).Start();
            }
        }
        public class BusinessPatrner
        {
            public string ConnBP { get; set; }

        }
    }
}
