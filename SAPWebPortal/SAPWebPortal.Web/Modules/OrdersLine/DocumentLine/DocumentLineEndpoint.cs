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
using MyRow = SAPWebPortal.OrdersLine.DocumentLineRow;
using SAPWebPortal.Web.Models.SLModels;

namespace SAPWebPortal.OrdersLine.Endpoints
{
    [Route("Services/OrdersLine/DocumentLine/[action]")]
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
        public class GetItemDetailData
        {
            public string ItemCode { get; set; }
            public string CardCode { get; set; }
            public string DBName { get; set; }
        }
            public JsonResult getItemDetail(GetItemDetailData data)
            {
                double Price = 0;
                string WhsCode = "";
                string UOM = "";
                string TaxCode = "";
                double Discount = 0;
                double UnitsOfMeasurment = 0;
                double InventoryQuantity = 0;
                double LineTotal = 0.0;
                double GrossTotal = 0.0;
                string ObjCode = "";
                string ItmsGrpCod = "";
                double Tax = 0;
                double Rate = 0;
                double TotalAfterTax = 0;
                double UOMPrice = 0.0;
                try
                {
                    var query = String.Format(DBHelper.GetQuery("ItemPrice", data.DBName), data.ItemCode, data.CardCode);
                    using (var reader = DBHelper.DoQuery(query, data.DBName))
                    {
                        if (reader.Read())
                        {
                            ObjCode = reader["GroupCode"].ToString();
                            ItmsGrpCod = reader["ItmsGrpCod"].ToString();
                            Price = Convert.ToDouble(reader["Price"].ToString());
                            WhsCode = reader["DfltWH"].ToString();
                            UOM = reader["UgpCode"].ToString();
                            TaxCode = reader["ECVatGroup"].ToString();

                            var query1 = String.Format(DBHelper.GetQuery("Query_56", data.DBName), ObjCode, ItmsGrpCod);
                            using (var reader1 = DBHelper.DoQuery(query1, data.DBName))
                            {
                                if (reader1.Read())
                                {
                                    Discount = Convert.ToDouble(reader1["Discount"].ToString());
                                }
                            }

                            UnitsOfMeasurment = Convert.ToDouble(reader["NumInBuy"].ToString());
                            Price = Price * UnitsOfMeasurment;
                            LineTotal = Price - (Price * Discount / 100);
                            var query2 = String.Format(DBHelper.GetQuery("Query_52", data.DBName), TaxCode);
                            using (var reader2 = DBHelper.DoQuery(query2, data.DBName))
                            {
                                if (reader2.Read())
                                {
                                    Rate = Convert.ToDouble(reader2["Rate"].ToString());

                                }
                            }
                            Tax = (Price) * (Rate / 100);
                            TotalAfterTax = Price + Tax;
                            GrossTotal = (TotalAfterTax) - ((TotalAfterTax) * (Discount / 100));
                            InventoryQuantity = UnitsOfMeasurment;
                        }
                    }
                }
                catch (Exception Ex)
                {
                    ExceptionsController.Log(Ex);
                }
                var res = new { Price, WhsCode, UOM, TaxCode, Discount, UnitsOfMeasurment, LineTotal, GrossTotal, InventoryQuantity };
                return Json(res);
            }
            public JsonResult getTaxDetail(ApiData TaxCode)
            {
                var _TaxCode = TaxCode.Code;
                var DBName = TaxCode.DBName;
                double Rate = 0;
                try
                {
                    var query = String.Format(DBHelper.GetQuery("Query_52", DBName), _TaxCode);
                    using (var reader = DBHelper.DoQuery(query, DBName))
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
        }
    }
