using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Web.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using MyRow = SAPWebPortal.APInvoiceLine.DocumentLineRow;
using SAPWebPortal.Default.Endpoints;

namespace SAPWebPortal.APInvoiceLine.Endpoints
{
    [Route("Services/APInvoiceLine/DocumentLine/[action]")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class DocumentLineController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IDocumentLineSaveHandler handler)
        {
           SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
           return helper.CreateInSAP(request); 
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request,
            [FromServices] IDocumentLineSaveHandler handler)
        { 
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.UpdateInSAP(request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request,
            [FromServices] IDocumentLineDeleteHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.DeleteInSAP(request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request,
            [FromServices] IDocumentLineRetrieveHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context); 
            return helper.RetrieveFromSAP(request); 
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request,
            [FromServices] IDocumentLineListHandler handler)
        {
            SAPHelper<MyRow> helper = new SAPHelper<MyRow>(Context);
            return helper.List(request);
        }

        public FileContentResult ListExcel(IDbConnection connection, ListRequest request,
            [FromServices] IDocumentLineListHandler handler,
            [FromServices] IExcelExporter exporter)
        {
            var data = List(connection, request, handler).Entities;
            var bytes = exporter.Export(data, typeof(Columns.DocumentLineColumns), request.ExportColumns);
            return ExcelContentResult.Create(bytes, "DocumentLineList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".xlsx");
        }
        public class GetItemDetailData { public string ItemCode { get; set; } public string CardCode { get; set; } }
        public JsonResult getItemDetail(GetItemDetailData data)
        {
            double Price = 0;
            string WhsCode = "";
            string UOM = "";
            string TaxCode = "";
            double Discount = 0;
             
            double InvQty = 0;
            double LineTotal = 0.0;
            double GrossTotal = 0.0;
            string ObjCode = "";
            string ItmsGrpCod = "";
            double Tax = 0;
            double Rate = 0;
            double TotalAfterTax = 0;
            double UOMPrice = 0.0;
            double onhand = 0.0;
            double iscommited = 0.0;
            double instock = 0.0;
            string WtyItem = "";
            try
            {
                var query = String.Format(DBHelper.GetQuery("ItemPrice"), data.ItemCode, data.CardCode);
                using (var reader = DBHelper.DoQuery(query))
                {
                    if (reader.Read())
                    {
                        ObjCode = reader["GroupCode"].ToString();
                        ItmsGrpCod = reader["ItmsGrpCod"].ToString();
                        Price = Convert.ToDouble(reader["Price"].ToString());
                        WhsCode = reader["DfltWH"].ToString();
                        UOM = reader["UgpCode"].ToString();
                        TaxCode = reader["ECVatGroup"].ToString();
                        WtyItem = reader["U_WRNT"].ToString();
                        var query1 = String.Format(DBHelper.GetQuery("Query_56"), ObjCode, ItmsGrpCod);
                        using (var reader1 = DBHelper.DoQuery(query1))
                        {
                            if (reader1.Read())
                            {
                                Discount = Convert.ToDouble(reader1["Discount"].ToString());
                            }
                        }
                        var query3 = String.Format(DBHelper.GetQuery("Query_67"), data.ItemCode, WhsCode);
                        using (var reader3 = DBHelper.DoQuery(query3))
                        {
                            if (reader3.Read())
                            {
                                onhand = Convert.ToDouble(reader3["OnHand"].ToString());
                                iscommited = Convert.ToDouble(reader3["IsCommited"].ToString());
                            }

                        }

                        LineTotal = Price - (Price * Discount/100);
                        var query2 = String.Format(DBHelper.GetQuery("Query_52"), TaxCode);
                        using (var reader2 = DBHelper.DoQuery(query2))
                        {
                            if (reader2.Read())
                            {
                                Rate = Convert.ToDouble(reader2["Rate"].ToString());

                            }
                        }
                        Tax = (Price) * (Rate / 100);
                        TotalAfterTax = Price + Tax;
                        GrossTotal = (TotalAfterTax) - ((TotalAfterTax) * (Discount / 100));
                        
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { Price, WhsCode, UOM, TaxCode, Discount, LineTotal, GrossTotal,WtyItem, instock };
            return Json(res);
        }
        public JsonResult getTaxDetail(string TaxCode)
        {
            double Rate = 0;
            try
            {
                var query = String.Format(DBHelper.GetQuery("Query_52"), TaxCode);
                using (var reader = DBHelper.DoQuery(query))
                {
                    if (reader.Read())
                    {
                        Rate = Convert.ToDouble(reader["Rate"].ToString());
                       
                    }
                }
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { Rate };
            return Json(res);
        }
        public class getInStockValueData { public string ItemCode { get; set; } public string WhsCode { get; set; } }

        public JsonResult getInStockValue(getInStockValueData data)
        {
            double onhand = 0;
            double iscommited = 0;
            double instock = 0;
            try
            {
                var query = String.Format(DBHelper.GetQuery("Query_67"), data.ItemCode, data.WhsCode);
                using (var reader = DBHelper.DoQuery(query))
                {

                    if (reader.Read())
                    {
                        onhand = Convert.ToDouble(reader["OnHand"].ToString());
                        iscommited = Convert.ToDouble(reader["IsCommited"].ToString());
                    }

                }
                instock = onhand - iscommited;

            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
            }
            var res = new { instock };
            return Json(res);
        }
        public System.Collections.Generic.List<(string CardCode, string CardName)> GetGLAccounts(IDbConnection connection)
        {
            var result = new System.Collections.Generic.List<(string AccountCode, string AccountName)>();
            result.Clear();
            var usercontroller = new UsersController(this.Context);
            var username = this.Context.User.Identity.Name;
            var companyname = usercontroller.getCompanyName(username);
            using (var connectionsap = DBHelper.GetDBConnection(companyname))
            {
                if (connectionsap.State != ConnectionState.Open)
                    connectionsap.Open();
                var condition = string.Empty;

                var sql = $@"select ""AcctCode"",""AcctName"" from OACT Where ""Postable"" = 'Y'";
                var table = DBHelper.GetTableFromQuery(sql, connectionsap);
                foreach (System.Data.DataRow row in table.Rows)
                {
                    result.Add((row["AcctCode"].ToString(), row["AcctName"].ToString()));
                }
                connectionsap.Close();
            }
            return result;
        }

    }
}