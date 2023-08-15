using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using SAPWebPortal.Web.DependencyInjections;
using SAPWebPortal.Web.Modules.Common.Helpers;
using SAPWebPortal.Web.Modules.SAPApp;
using Serenity.Data;
using System;
using System.Linq;

namespace SAPWebPortal.Web.Modules.ARInvoiceToAPInvoiceIntegration
{
    public class ARInvoiceToAPInvoiceIntegration
    {
        IB1ServiceLayer _iB1ServiceLayer;
        ISqlConnections _sqlConnections;
        public ARInvoiceToAPInvoiceIntegration(IB1ServiceLayer b1ServiceLayer,ISqlConnections sqlConnections)
        {
            _iB1ServiceLayer = b1ServiceLayer;
            _sqlConnections = sqlConnections;
        }
        public APInvoice.DocumentRow generateAPInvoicefromARInvoice(ARInvoice.DocumentRow ARrow,string DBName)
        {




            APInvoice.DocumentRow AProw = new APInvoice.DocumentRow();
            AProw.CardCode = ARrow.CardCode;
            AProw.DocDate = DateTime.Now;
            AProw.DocDueDate = DateTime.Now;
            AProw.DocType = "dDocument_Service";
            AProw.DocObjectCode = "oPurchaseInvoices";
            var lines = new System.Collections.Generic.List<APInvoiceLine.DocumentLineRow>();
            foreach (var r in ARrow.DocumentLines)
            {
                try
                {
                    var line = new APInvoiceLine.DocumentLineRow();

                    line.ItemDescription = r.ItemCode;
                    line.AccountCode = "";
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

        public bool PostAPInvoice(string DBName)
        {
            var flag = false;
            var getChanges = DBHelper.GetTableFromQuery(String.Format("exec [dbo].[GET_CHANGES] {0},13", 0), DBName);

            var Changes = _iB1ServiceLayer.FromTabletoObject<GetChangesObject>(getChanges).ToList();
            if (Changes.Count() != 0)
            {
                foreach (var s in Changes)
                {


                    try
                    {
                        var _ARRow = _iB1ServiceLayer.GetSLEntity<ARInvoice.DocumentRow>(new ARInvoice.DocumentRow() { DocEntry = Convert.ToInt32(s.DocEntry) }, DBName);

                        var AProw = generateAPInvoicefromARInvoice(_ARRow, DBName);

                        var response = _iB1ServiceLayer.Create<APInvoice.DocumentRow>(AProw, DBName);

                        if (response != null && !String.IsNullOrEmpty(response?.DocNum.ToString()))
                        {
                            flag = true;
                        }
                    }
                    catch (Exception ex)
                    {

                        //throw;
                    }

                }


            }


           
            return flag;
        }
    }
}
