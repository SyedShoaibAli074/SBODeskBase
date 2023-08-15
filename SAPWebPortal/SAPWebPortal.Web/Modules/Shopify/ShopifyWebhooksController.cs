using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Default;
using SAPWebPortal.Default.Endpoints;
using SAPWebPortal.Web.DependencyInjections;
using SAPWebPortal.Web.Helpers;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ShopifySharp;
using Customer = ShopifySharp.Customer;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using Microsoft.Extensions.Logging.Abstractions;
using Org.BouncyCastle.Utilities;
using SAPWebPortal.Web.Modules.Default.Log;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.Data.Common;
using System.Data.SqlClient;
using static MVC.Views.Default;
using System.Threading.Tasks;
using NUglify.Helpers;
using SAPbobsCOM;
using SAPB1;
using static System.Net.Mime.MediaTypeNames;

namespace SAPWebPortal.Web.Modules.SAPApp
{
    [Route("Services/ShopifyWebhooksController/Api/[action]")]
    public class ShopifyWebhooksController : ServiceEndpoint
    {
        IB1ServiceLayer _iB1ServiceLayer; 
        ISqlConnections _sqlConnections;
        ILog _log;
        ISharpShopify _iSharpShopify;

        public ShopifyWebhooksController(IB1ServiceLayer iB1ServiceLayer, ISharpShopify iSharpShopify, ISqlConnections sqlConnections, ILog log)
        {
            _iB1ServiceLayer = iB1ServiceLayer;
            _sqlConnections = sqlConnections;
            _log = log;
            _iSharpShopify= iSharpShopify;
        }
        //customers/create
        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult CreateBusinessPartner(object ShopifyCustomerRequest)
        {
            BusinessPartnerRow row = new BusinessPartnerRow();
            var StoreName = Request.Headers["X-Shopify-Shop-Domain"];
            LogRow log = new LogRow();
            log.ShopifyId = StoreName;
            log.ShopifyPayload = JsonConvert.SerializeObject(ShopifyCustomerRequest);
            log.UDirection = LogEnums.UDirection.ShopifyToSAP.ToString();
            try
            {
                var ShopifyCustomerobj = JsonConvert.DeserializeObject<Customer>(ShopifyCustomerRequest.ToString());


                var conn=DBHelper.GetSerenDBConnection();
                var shopifysettings=conn.List<ShopifySettingsRow>().Where(x=>x.ApiBaseURL== StoreName).FirstOrDefault();
                var Lines = from A0 in conn.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                            join A1 in conn.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };



                var CustomerSeries = Lines.Where(x=>x.ShopifySubSettingsName== "CustomerSeries").FirstOrDefault().ShopifySubSettingsSapValue;
                var CustomerGroup = Lines.Where(x => x.ShopifySubSettingsName == "CustomerGroup").FirstOrDefault().ShopifySubSettingsSapValue;
                var CashAccount = Lines.Where(x => x.ShopifySubSettingsName == "CashAccount").FirstOrDefault().ShopifySubSettingsSapValue;
                var SAPDBRow=conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt32(shopifysettings.SapDatabase)).FirstOrDefault();
                
                row.DBName = SAPDBRow.CompanyDb;
                var dtable = DBHelper.GetTableFromQuery(@$"Select T0.""CardCode"" from ""OCRD"" T0 Where T0.""Phone1""='{ShopifyCustomerobj.Phone}' and T0.""Series""='{CustomerSeries}' and T0.""GroupCode""='{CustomerGroup}'", SAPDBRow.CompanyDb);

                var rowobj = _iB1ServiceLayer.FromTabletoObject<BusinessPartnerRow>(dtable);
                if (rowobj.Count() == 0)
                {
                    row.CardName = ShopifyCustomerobj.FirstName + ShopifyCustomerobj.LastName;
                    row.CardType = "C";
                    row.Series = Convert.ToInt32(CustomerSeries);
                    row.GroupCode = CustomerGroup;
                    row.Phone1 = ShopifyCustomerobj.Phone;
                    row.Notes = ShopifyCustomerobj.Note;
                    row.EmailAddress = ShopifyCustomerobj.Email;
                    row.U_TotalOrders = ShopifyCustomerobj.OrdersCount.ToString();
                    row.U_TotalSpent = Convert.ToInt64(ShopifyCustomerobj.TotalSpent).ToString();
                    row.U_source = "Website";
                    row.DownPaymentInterimAccount = CashAccount;
                    row.DownPaymentInterimAccount = CashAccount;
                    if (ShopifyCustomerobj.Addresses.Count() > 0)
                    {
                        var addresses = new System.Collections.Generic.List<BPAddressesRow>();
                        foreach (var r in ShopifyCustomerobj.Addresses)
                        {
                            BPAddressesRow address = new BPAddressesRow()
                            {
                                AddressName = r.Address1,
                                Street = r .Address2,
                                City = r .City,
                                Country = r .CountryCode,
                                County = r .Country,
                                ZipCode = r .Zip,
                                AddressType = "bo_BillTo"
                            };
                            BPAddressesRow address1 = new BPAddressesRow()
                            {
                                AddressName = r .Address1,
                                Street = r .Address2,
                                City = r .City,
                                Country = r .CountryCode,
                                County = r .Country,
                                ZipCode = r .Zip,
                                AddressType = "bo_ShipTo"
                            };
                            addresses.Add(address);
                            addresses.Add(address1);
                        }
                        row.BPAddresses = addresses;


                    }

                    var response = _iB1ServiceLayer.Create<BusinessPartnerRow>(row, StoreName);
                    if (response != null)
                    {
                        log.UError = LogEnums.UError.False.ToString();
                        log.UObjType = "CustomerCreate";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = JsonConvert.SerializeObject(response);
                        _log.Log(log);
                        
                    }
                }
                



                return Ok("Customer Created successfully");

            }
            catch (Exception ex)
            {
                log.UError = LogEnums.UError.True.ToString();
                log.UObjType = "CustomerCreate";
                log.UDateTime = DateTime.Now;
                log.UResponse = ex.Message;
                _log.Log(log);
              
                ExceptionsController.Log(ex);
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult LogTest(object ShopifyCustomerRequest)
        {
            var StoreName = Request.Headers["X-Shopify-Shop-Domain"];
            LogRow log = new LogRow();
            log.ShopifyId = StoreName;
            log.ShopifyPayload = JsonConvert.SerializeObject(ShopifyCustomerRequest);
            log.UDirection = LogEnums.UDirection.ShopifyToSAP.ToString();
            log.UError = LogEnums.UError.False.ToString();
            log.UObjType = "CustomerCreate";
            log.UDateTime = DateTime.Now;
            log.UResponse = JsonConvert.SerializeObject(ShopifyCustomerRequest);
            _log.Log(log);
            return Ok();
        }
        //customers/update
        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult UpdateBusinessPartner(object ShopifyCustomerRequest)
        {
            var StoreName = Request.Headers["X-Shopify-Shop-Domain"];

            LogRow log = new LogRow();
            log.ShopifyId = StoreName;
            log.ShopifyPayload = JsonConvert.SerializeObject(ShopifyCustomerRequest);
            log.UDirection = LogEnums.UDirection.ShopifyToSAP.ToString();
            
            BusinessPartnerRow row = new BusinessPartnerRow();
            try
            {
                var ShopifyCustomerobj = JsonConvert.DeserializeObject<Customer>(ShopifyCustomerRequest.ToString());

                var conn = DBHelper.GetSerenDBConnection();
                var shopifysettings = conn.List<ShopifySettingsRow>().Where(x => x.ApiBaseURL == StoreName).FirstOrDefault();
                var Lines = from A0 in conn.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                            join A1 in conn.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                var CustomerSeries = Lines.Where(x => x.ShopifySubSettingsName == "CustomerSeries").FirstOrDefault().ShopifySubSettingsSapValue;
                var CustomerGroup = Lines.Where(x => x.ShopifySubSettingsName == "CustomerGroup").FirstOrDefault().ShopifySubSettingsSapValue;
                var CashAccount = Lines.Where(x => x.ShopifySubSettingsName == "CashAccount").FirstOrDefault().ShopifySubSettingsSapValue;

                var SAPDBRow = conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt32(shopifysettings.SapDatabase)).FirstOrDefault();
                row.DBName = SAPDBRow.CompanyDb;
                if (!String.IsNullOrEmpty(ShopifyCustomerobj.Phone))
                {
                    var dtable = DBHelper.GetTableFromQuery(@$"Select T0.""CardCode"" from ""OCRD"" T0 Where T0.""Phone1""='{ShopifyCustomerobj.Phone}' and T0.""Series""='{CustomerSeries}' and T0.""GroupCode""='{CustomerGroup}'", SAPDBRow.CompanyDb);
                    var rowobj = _iB1ServiceLayer.FromTabletoObject<BusinessPartnerRow>(dtable);
                    if (rowobj.Count() > 0)
                    {
                        row.CardName = ShopifyCustomerobj.FirstName + ShopifyCustomerobj.LastName;
                        row.CardType = "C";
                        row.CardCode = rowobj.FirstOrDefault().CardCode;
                        row.Series = Convert.ToInt32(CustomerSeries);
                        row.GroupCode = CustomerGroup;
                        row.Phone1 = ShopifyCustomerobj.Phone;
                        row.Notes = ShopifyCustomerobj.Note;
                        row.EmailAddress = ShopifyCustomerobj.Email;
                        row.U_TotalOrders = ShopifyCustomerobj.OrdersCount.ToString();
                        row.U_TotalSpent = ShopifyCustomerobj.TotalSpent.ToString();
                        row.U_source = "Website";
                        row.DownPaymentInterimAccount = CashAccount;
                        row.DownPaymentClearAct = CashAccount;
                        
                        if (ShopifyCustomerobj.Addresses.Count() > 0)
                        {
                            var addresses = new System.Collections.Generic.List<BPAddressesRow>();
                            addresses.AddRange(rowobj.FirstOrDefault().BPAddresses);
                            foreach (var r in ShopifyCustomerobj.Addresses)
                            {
                                BPAddressesRow address = new BPAddressesRow()
                                {
                                    AddressName = r.Address1,
                                    Street = r.Address2,
                                    City = r.City,
                                    Country = r.CountryCode,
                                    County = r.Country,
                                    ZipCode = r.Zip,
                                    AddressType = "bo_BillTo"
                                };
                                BPAddressesRow address1 = new BPAddressesRow()
                                {
                                    AddressName = r.Address1,
                                    Street = r.Address2,
                                    City = r.City,
                                    Country = r.CountryCode,
                                    County = r.Country,
                                    ZipCode = r.Zip,
                                    AddressType = "bo_ShipTo"
                                };
                                addresses.Add(address);
                                addresses.Add(address1);
                            }
                            row.BPAddresses = addresses;

                        }

                        _iB1ServiceLayer.Update<BusinessPartnerRow>(row, StoreName);
                        log.UError = LogEnums.UError.False.ToString();
                        log.UObjType = "CustomerUpdate";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = "";
                        _log.Log(log);

                    }
                    else
                    {
                        CreateBusinessPartner(ShopifyCustomerRequest);
                    }



                    return Ok("Customer Updated Succesfully");
                }
                else
                {
                    return Ok("No Customer Found with PhoneNo");
                }
                

            }
            catch (Exception ex)
            {
                log.UError = LogEnums.UError.True.ToString();
                log.UObjType = "CustomerUpdate";
                log.UDateTime = DateTime.Now;
                log.UResponse = ex.Message;
                _log.Log(log);
                
                
                ExceptionsController.Log(ex);
                return BadRequest(ex.Message);
            }
        }

        //orders/create
        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult CreateSalesOrder(object ShopifyOrderRequest)
        {
            var StoreName = Request.Headers["X-Shopify-Shop-Domain"];
            LogRow log = new LogRow();
            log.ShopifyId = StoreName;
            log.ShopifyPayload = JsonConvert.SerializeObject(ShopifyOrderRequest);
            log.UDirection = LogEnums.UDirection.ShopifyToSAP.ToString();
            
            try
            {
                var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());


                var row = generateSaleOrderObject(ShopifyOrderRequest,StoreName);
                if (row!=null && row.Type == "C")
                {
                    var test=_iB1ServiceLayer.Create<Orders.DocumentRow>(row.Row, StoreName);
                    
                    log.UError = LogEnums.UError.False.ToString();
                    log.UObjType = "SaleOrderCreate";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = JsonConvert.SerializeObject(test);
                    _log.Log(log);
                    
                    return Ok("Order Created");
                }
                else
                {
                    log.UError = LogEnums.UError.True.ToString();
                    log.UObjType = "SaleOrderCreate";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = new Exception(@$"Order {ShopifyOrderobj.OrderNumber} Not Created for Store {StoreName}").Message;
                    _log.Log(log);
                   
                    ExceptionsController.Log(new Exception(@$"Order {ShopifyOrderobj.OrderNumber} Not Created for Store {StoreName}"));
                    return BadRequest();
                }



                

            }
            catch (Exception ex)
            {
                log.UError = LogEnums.UError.False.ToString();
                log.UObjType = "SaleOrderCreate";
                log.UDateTime = DateTime.Now;
                log.UResponse = ex.Message;
                _log.Log(log);
                
                ExceptionsController.Log(ex);
                return BadRequest(ex.Message);
            }
        }

        //orders/update
        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult UpdateSalesOrder(object ShopifyOrderRequest)
        {
            var StoreName = Request.Headers["X-Shopify-Shop-Domain"];
            LogRow log = new LogRow();
            log.ShopifyId = StoreName;
            log.ShopifyPayload = JsonConvert.SerializeObject(ShopifyOrderRequest);
            log.UDirection = LogEnums.UDirection.ShopifyToSAP.ToString();
            try
            {

                var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());

                var row = generateSaleOrderObject(ShopifyOrderRequest, StoreName);

                if (row != null && row.Type == "C")
                {
                    var response=_iB1ServiceLayer.Create<Orders.DocumentRow>(row.Row, StoreName); 
                    log.UError = LogEnums.UError.False.ToString();
                    log.UObjType = "SaleOrderCreate";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = JsonConvert.SerializeObject(response);
                    _log.Log(log);
                    
                    return Ok("Order Created");
                }
                else if(row != null && row.Type == "U")
                {
                    _iB1ServiceLayer.Update<Orders.DocumentRow>(row.Row, StoreName);
                    log.UError = LogEnums.UError.False.ToString();
                    log.UObjType = "SaleOrderUpdate";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = "";
                    _log.Log(log);
                    
                    return Ok("Order Updated");
                }
                else
                {
                    log.UError = LogEnums.UError.True.ToString();
                    log.UObjType = "SaleOrderCreate";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = new Exception(@$"Order {ShopifyOrderobj.OrderNumber} Not Created for Store {StoreName}").Message;
                    _log.Log(log);
                    ExceptionsController.Log(new Exception(@$"Order {ShopifyOrderobj.OrderNumber} Not Created for Store {StoreName}"));
                    return BadRequest();
                }
                





                

            }
            catch (Exception ex)
            {
                log.UError = LogEnums.UError.True.ToString();
                log.UObjType = "SaleOrderCreate";
                log.UDateTime = DateTime.Now;
                log.UResponse = ex.Message;
                _log.Log(log);
               
                ExceptionsController.Log(ex);
                return BadRequest(ex.Message);
            }
        }

        //orders/cancelled
        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult CancelSalesOrder(object ShopifyOrderRequest)
        {
            var StoreName = Request.Headers["X-Shopify-Shop-Domain"];
            LogRow log = new LogRow();
            log.ShopifyId = StoreName;
            log.ShopifyPayload = JsonConvert.SerializeObject(ShopifyOrderRequest);
            log.UDirection = LogEnums.UDirection.ShopifyToSAP.ToString();
            try
            {


                var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());
                var conn = DBHelper.GetSerenDBConnection();
                var shopifysettings = conn.List<ShopifySettingsRow>().Where(x => x.ApiBaseURL == StoreName).FirstOrDefault();
                var SAPDBRow = conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt32(shopifysettings.SapDatabase)).FirstOrDefault();
                var orderdtable = DBHelper.GetTableFromQuery(@$"Select T0.""DocNum"",T0.""DocEntry"" from ""ORDR"" T0 Where T0.""U_ShopifyOrderId""='{ShopifyOrderobj.Id.ToString()}' AND T0.""DocStatus""='O'", SAPDBRow.CompanyDb);

                var orderrowobj = _iB1ServiceLayer.FromTabletoObject<Orders.DocumentRow>(orderdtable);
                if (orderrowobj.Count() > 0)
                {
                    var OrderRow = _iB1ServiceLayer.GetSLEntity<Orders.DocumentRow>(orderrowobj.FirstOrDefault(), SAPDBRow.CompanyDb);
                    

                    _iB1ServiceLayer.CancelDocument<Orders.DocumentRow>(OrderRow, StoreName);
                    
                    log.UError = LogEnums.UError.False.ToString();
                    log.UObjType = "SaleOrderCancel";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = "Order Not Found";
                    _log.Log(log);
                    
                    return Ok();
                }
                else
                {
                    log.UError = LogEnums.UError.True.ToString();
                    log.UObjType = "SaleOrderCancel";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = "";
                    _log.Log(log);
                   
                    return BadRequest("Order Not found");
                }
                   
                   
                
            }
            catch (Exception ex)
            {
                log.UError = LogEnums.UError.True.ToString();
                log.UObjType = "SaleOrderCancel";
                log.UDateTime = DateTime.Now;
                log.UResponse = ex.Message;
                _log.Log(log);

                return BadRequest(ex.Message);
            
            }

        }

        //fulfillments/create
        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult CreateDeliveryNote(object ShopifyOrderRequest)
        {
            var StoreName = Request.Headers["X-Shopify-Shop-Domain"];
            var con = DBHelper.GetSerenDBConnection();
            var shopifycreds = con.List<ShopifySettingsRow>().First(x => x.ApiBaseURL == StoreName);
            var creds = con.List<SapDatabasesRow>().First(x => x.Id == Convert.ToInt32(shopifycreds.SapDatabase));
            LogRow log = new LogRow();
            log.ShopifyId = StoreName;
            log.ShopifyPayload = JsonConvert.SerializeObject(ShopifyOrderRequest);
            log.UDirection = LogEnums.UDirection.ShopifyToSAP.ToString();
            try
            {
                


                var row = generateDeliveryNoteObject(ShopifyOrderRequest, StoreName);

                if(row!=null) 
                {
                    if(row.DocumentStatus!= "DocumentAlreadyInApproval")
                    {
                        try
                        {
                            var test = _iB1ServiceLayer.Create<Delivery.DocumentRow>(row, StoreName);
                            log.UError = LogEnums.UError.False.ToString();
                            log.UObjType = "DeliveryNoteCreate";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(test);
                            _log.Log(log);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("No matching records found (ODBC -2028)") || ex.Message.Contains("One or more errors occurred. (Input string was not in a correct format.)"))
                            {
                                
                                    log.UError = LogEnums.UError.False.ToString();
                                    log.UObjType = "DeliveryNoteSentInApproval";
                                    log.UDateTime = DateTime.Now;
                                    log.UResponse = JsonConvert.SerializeObject(row);
                                    _log.Log(log);
                                    return Ok("DeliveryNote Sent In Approval");

                                
                                

                            }

                            // throw;
                        }
                       


                        return Ok("Delivery Note Created");
                    }
                    else
                    {
                        log.UError = LogEnums.UError.False.ToString();
                        log.UObjType = "DeliveryNoteAlreadyInApproval";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = JsonConvert.SerializeObject(row);
                        _log.Log(log);


                        return Ok("DeliveryNote Already In Approval");

                    }
                    
                }
                else
                {
                    var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());
                    log.UError = LogEnums.UError.True.ToString();
                    log.UObjType = "DeliveryNoteCreate";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = new Exception(@$"Sales Order Not Found for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName}").Message;
                    _log.Log(log);
                    
                    ExceptionsController.Log(new Exception(@$"Sales Order Not Found for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName}"));
                    return BadRequest();
                }



                

            }
            catch (Exception ex)
            {
                var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());
                log.UError = LogEnums.UError.True.ToString();
                log.UObjType = "DeliveryNoteCreate";
                log.UDateTime = DateTime.Now;
                log.UResponse = ex.Message;
                _log.Log(log);
                
                ExceptionsController.Log(ex);
                return BadRequest(ex.Message);
            }

        }

        //orders/paid
        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult CheckOrderPayment(object ShopifyOrderRequest)
        {
            var StoreName = Request.Headers["X-Shopify-Shop-Domain"];
            LogRow log = new LogRow();
            log.ShopifyId = StoreName;
            log.ShopifyPayload = JsonConvert.SerializeObject(ShopifyOrderRequest);
            log.UDirection = LogEnums.UDirection.ShopifyToSAP.ToString();
            try
            {



                var row = generateDownPaymentObject(ShopifyOrderRequest, StoreName);
                var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());

                if (row != null)
                {
                    if (row.Type == "C")
                    {
                        var response1 = _iB1ServiceLayer.Create<DownPayment.DocumentRow>(row.Row, StoreName);
                        //return Ok("Down Payment Created");
                        log.UError = LogEnums.UError.False.ToString();
                        log.UObjType = "DownPaymentCreate";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = JsonConvert.SerializeObject(response1);
                        _log.Log(log);
                        if (response1 != null)
                        {

                            var row2 = generateIncomingPaymentObject(ShopifyOrderRequest, response1, StoreName);
                            var response2 = _iB1ServiceLayer.Create<IncomingPayment.PaymentRow>(row2, StoreName);
                            if(response2 != null)
                            {
                                log.UError = LogEnums.UError.False.ToString();
                                log.UObjType = "IncomingPaymnetCreate";
                                log.UDateTime = DateTime.Now;
                                log.UResponse = JsonConvert.SerializeObject(response2);
                                _log.Log(log);

                                return Ok("Down Payment and Incoming Created");
                            }
                            else
                            {
                                log.UError = LogEnums.UError.True.ToString();
                                log.UObjType = "IncomingPaymnetCreate";
                                log.UDateTime = DateTime.Now;
                                log.UResponse = JsonConvert.SerializeObject(response2);
                                _log.Log(log);

                                return Ok("Incoming Not Created");
                            }
                        }
                        else
                        {
                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "IncomingPaymnetCreate";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(response1);
                            _log.Log(log);

                            ExceptionsController.Log(new Exception(@$"Incoming Payment for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName} failed"));
                            return BadRequest();
                        }

                    }
                    else if (row.Type == "U")
                    {
                        if (row.Row != null)
                        {

                            var row2 = generateIncomingPaymentObject(ShopifyOrderRequest, row.Row, StoreName);
                            if(row2 != null)
                            {
                                var response2 = _iB1ServiceLayer.Create<IncomingPayment.PaymentRow>(row2, StoreName);
                                if(response2 != null)
                                {
                                    log.UError = LogEnums.UError.False.ToString();
                                    log.UObjType = "IncomingPaymnetCreate";
                                    log.UDateTime = DateTime.Now;
                                    log.UResponse = JsonConvert.SerializeObject(response2);
                                    _log.Log(log);

                                    return Ok("Down Payment and Incoming Created");
                                }
                                else
                                {
                                    log.UError = LogEnums.UError.True.ToString();
                                    log.UObjType = "IncomingPaymnetCreate";
                                    log.UDateTime = DateTime.Now;
                                    log.UResponse = JsonConvert.SerializeObject(response2);
                                    _log.Log(log);
                                    return BadRequest("Incoming Not Created");
                                }
                               

                            }
                            else
                            {
                                log.UError = LogEnums.UError.True.ToString();
                                log.UObjType = "IncomingPaymnetCreate";
                                log.UDateTime = DateTime.Now;
                                log.UResponse = JsonConvert.SerializeObject(row.Row);
                                _log.Log(log);

                                ExceptionsController.Log(new Exception(@$"Incoming Payment for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName} Already Created"));
                                return Ok();
                            }
                           
                        }
                        else
                        {
                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "IncomingPaymnetCreate";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(row.Row);
                            _log.Log(log);

                            ExceptionsController.Log(new Exception(@$"Incoming Payment for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName} failed"));
                            return BadRequest();
                        }
                    }
                    else
                    {
                        log.UError = LogEnums.UError.True.ToString();
                        log.UObjType = "OrderPaymentCheck";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = new Exception(@$"Sales Order Not Found for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName}").Message;
                        _log.Log(log);

                        ExceptionsController.Log(new Exception(@$"Sales Order Not Found for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName}"));
                        return BadRequest();
                    }
                    
                }
                else
                {
                    log.UError = LogEnums.UError.True.ToString();
                    log.UObjType = "IncomingPaymnetCreate";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = new Exception(@$"Sales Order Not Found for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName}").Message;
                    _log.Log(log);
                    
                    ExceptionsController.Log(new Exception(@$"Sales Order Not Found for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName}"));
                    return BadRequest();
                }






            }
            catch (Exception ex)
            {
                log.UError = LogEnums.UError.True.ToString();
                log.UObjType = "OrderPaymentCheck";
                log.UDateTime = DateTime.Now;
                log.UResponse = ex.Message;
                _log.Log(log);
                
                ExceptionsController.Log(ex);
                return BadRequest(ex.Message);
            }

        }

        //orders/updated
        [HttpPost, IgnoreAntiforgeryToken]
        public IActionResult CreateReturn(object ShopifyOrderRequest)
        {
            var StoreName = Request.Headers["X-Shopify-Shop-Domain"];
            var con = DBHelper.GetSerenDBConnection();
            var shopifycreds = con.List<ShopifySettingsRow>().First(x => x.ApiBaseURL == StoreName);
            var creds = con.List<SapDatabasesRow>().First(x => x.Id == Convert.ToInt32(shopifycreds.SapDatabase)); 
            LogRow log = new LogRow();
            log.ShopifyId = StoreName;
            log.UDirection = LogEnums.UDirection.ShopifyToSAP.ToString();
            log.ShopifyPayload = JsonConvert.SerializeObject(ShopifyOrderRequest);
            var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());
            if (ShopifyOrderobj.FinancialStatus == "refunded"|| ShopifyOrderobj.FinancialStatus == "partially_refunded")
            {
                try
                {



                    var row = generateReturnObject(ShopifyOrderRequest, StoreName);
                    
                    if (row != null)
                    {
                        if (row.DocumentStatus != "DocumentAlreadyInApproval")
                        {
                            try
                            {
                                var response1 = _iB1ServiceLayer.Create<Returns.DocumentRow>(row, StoreName);
                                //return Ok("Down Payment Created");
                                log.UError = LogEnums.UError.False.ToString();
                                log.UObjType = "ReturnCreate";
                                log.UDateTime = DateTime.Now;
                                log.UResponse = JsonConvert.SerializeObject(response1);
                                _log.Log(log);
                                return Ok("Return Created");
                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("No matching records found (ODBC -2028)") || ex.Message.Contains("One or more errors occurred. (Input string was not in a correct format.)"))
                                {
                                    var flag=IsInApproval(row.U_ApprovalGUID, creds.CompanyDb);
                                    if (flag)
                                    {
                                        log.UError = LogEnums.UError.False.ToString();
                                        log.UObjType = "ReturnSentInApproval";
                                        log.UDateTime = DateTime.Now;
                                        log.UResponse = JsonConvert.SerializeObject(row);
                                        _log.Log(log);
                                        return Ok("Return Sent In Approval");
                                    }
                                    else
                                    {
                                        log.UError = LogEnums.UError.True.ToString();
                                        log.UObjType = "ReturnNotSentInApproval";
                                        log.UDateTime = DateTime.Now;
                                        log.UResponse = JsonConvert.SerializeObject(row);
                                        _log.Log(log);
                                        return Ok("Return Not Sent In Approval");

                                    }
                                   

                                }
                                //throw;
                            }

                            log.UError = LogEnums.UError.False.ToString();
                            log.UObjType = "ReturnCreate";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(row);
                            _log.Log(log);
                            return Ok("Return Created");
                        }
                        else
                        {
                            log.UError = LogEnums.UError.False.ToString();
                            log.UObjType = "ReturnAlreadyInApproval";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(row);
                            _log.Log(log);


                            return Ok("Return Already In Approval");
                        }
                        
                    }
                    else
                    {
                        log.UError = LogEnums.UError.True.ToString();
                        log.UObjType = "ReturnCreate";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = new Exception(@$"Delivery Note Not Found for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName}").Message;
                        _log.Log(log);

                        ExceptionsController.Log(new Exception(@$"Delivery Note Not Found for Order Number {ShopifyOrderobj.OrderNumber} for Shopify Store {StoreName}"));
                        return BadRequest();
                    }






                }
                catch (Exception ex)
                {
                    log.UError = LogEnums.UError.True.ToString();
                    log.UObjType = "ReturnCreate";
                    log.UDateTime = DateTime.Now;
                    log.UResponse = ex.Message;
                    _log.Log(log);

                    ExceptionsController.Log(ex);
                    return BadRequest(ex.Message);
                }
            }
            
            else
            {
                log.UError = LogEnums.UError.False.ToString();
                log.UObjType = "ReturnCreate";
                log.UDateTime = DateTime.Now;
                log.UResponse = "Update Not of Type Refund";
                _log.Log(log);
                return Ok("Update not of type Refund");
            }
        }
        private SaleOrderObject generateSaleOrderObject(object ShopifyOrderRequest,string StoreName)
        {
            try
            {

                var ShopifyOrderFullfilmentobj = JsonConvert.DeserializeObject<Fulfillment>(ShopifyOrderRequest.ToString());
                var ShopifyOrderobj = _iSharpShopify.GetOrder(StoreName, ShopifyOrderFullfilmentobj.OrderId.ToString());


                Orders.DocumentRow row = new Orders.DocumentRow();
                var conn = DBHelper.GetSerenDBConnection();
                var shopifysettings = conn.List<ShopifySettingsRow>().Where(x => x.ApiBaseURL == StoreName).FirstOrDefault();
                var SAPDBRow = conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt32(shopifysettings.SapDatabase)).FirstOrDefault();

                var Lines = from A0 in conn.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                            join A1 in conn.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };


                
                var TaxCode = Lines.Where(x => x.ShopifySubSettingsName == "TaxCode").FirstOrDefault().ShopifySubSettingsSapValue;
                
                var SOSeries = Lines.Where(x => x.ShopifySubSettingsName == "SOSeries").FirstOrDefault().ShopifySubSettingsSapValue;
                row.Series = Convert.ToInt32(SOSeries);

                row.DBName = SAPDBRow.CompanyDb;
                var orderdtable = DBHelper.GetTableFromQuery(@$"Select T0.""DocNum"",T0.""DocEntry"" from ""ORDR"" T0 Where T0.""U_ShopifyOrderId""='{ShopifyOrderobj.Id.ToString()}'", SAPDBRow.CompanyDb);

                var orderrowobj = _iB1ServiceLayer.FromTabletoObject<Orders.DocumentRow>(orderdtable);
                if (orderrowobj.Count() > 0)
                {
                    return new SaleOrderObject() { Type = "U", Row = null };
                }
                else
                {
                    row.U_ShopifyOrderId = ShopifyOrderobj.Id.ToString();

                    row.DocDate = Convert.ToDateTime(ShopifyOrderobj.CreatedAt.Value.DateTime);
                    row.DocDueDate = Convert.ToDateTime(ShopifyOrderobj.CreatedAt.Value.DateTime);
                    row.U_CUSNAME = ShopifyOrderobj.Customer.FirstName + " " + ShopifyOrderobj.Customer.LastName;
                    row.U_CUSNUMBER = ShopifyOrderobj.BillingAddress.Phone ?? ShopifyOrderobj.ShippingAddress.Phone;
                    row.U_Address = ShopifyOrderobj.BillingAddress.Address1 + ", " + ShopifyOrderobj.BillingAddress.Address2 + ", " + ShopifyOrderobj.BillingAddress.City + ", " + ShopifyOrderobj.BillingAddress.CountryCode + ", " + ShopifyOrderobj.BillingAddress.Country + ", " + ShopifyOrderobj.BillingAddress.Zip;

                    var dtable = DBHelper.GetTableFromQuery(@$"Select T0.""CardCode"" from ""OCRD"" T0 Where T0.""CardName"" in '({string.Join(',', ShopifyOrderobj.Tags.Select(tag => $"'{tag}'"))})'", SAPDBRow.CompanyDb);
                    var rowobj = _iB1ServiceLayer.FromTabletoObject<BusinessPartnerRow>(dtable);
                    BusinessPartnerRow businessPartnerRow = new BusinessPartnerRow();
                  

                    
                    var CustomerRow = _iB1ServiceLayer.GetSLEntity<BusinessPartnerRow>(rowobj.FirstOrDefault(), SAPDBRow.CompanyDb);

                    row.CardCode = businessPartnerRow.CardCode;
                    row.CardName = businessPartnerRow.CardName;
                   
                    
                    var lines = new System.Collections.Generic.List<OrdersLine.DocumentLineRow>();
                    int iteration = 0;
                    var Shipping = ShopifyOrderobj.TotalShippingPriceSet.ShopMoney.Amount;

                    row.DocumentAdditionalExpenses = new System.Collections.Generic.List<OrdersExpense.DocumentAdditionalExpenseRow>() { new OrdersExpense.DocumentAdditionalExpenseRow() { ExpenseCode=1,LineTotal = Shipping,VatGroup= TaxCode } };

                    foreach (var itemline in ShopifyOrderobj.LineItems)
                    {
                        lines.Add(new OrdersLine.DocumentLineRow()
                        {
                            ItemCode = itemline.SKU,
                            Quantity = itemline.Quantity,
                            ItemDescription = itemline.Name,
                            U_ShopifyOrderLineId=itemline.Id.ToString(),
                            LineNum= iteration,
                            VatGroup=TaxCode


                        });
                        iteration++;
                    }
                    row.DocumentLines = lines;
                    return new SaleOrderObject() { Row = row, Type = "C" }; 
                }
                

                
            }


            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
                return null;

            }

        }
        private Delivery.DocumentRow generateDeliveryNoteObject(object ShopifyOrderRequest, string StoreName)
        {
            try
            {
                var deliveryRow = new Delivery.DocumentRow();

                var ShopifyOrderobj = JsonConvert.DeserializeObject<Fulfillment>(ShopifyOrderRequest.ToString());
                var conn = DBHelper.GetSerenDBConnection();
                var shopifysettings = conn.List<ShopifySettingsRow>().Where(x => x.ApiBaseURL == StoreName).FirstOrDefault();
                var SAPDBRow = conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt32(shopifysettings.SapDatabase)).FirstOrDefault();
                var Lines = from A0 in conn.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                            join A1 in conn.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };

                var DOSeries = Lines.Where(x => x.ShopifySubSettingsName == "DOSeries").FirstOrDefault().ShopifySubSettingsSapValue;

                var orderfromFulfilment = _iSharpShopify.GetOrder(shopifysettings.StoreName, ShopifyOrderobj.OrderId.ToString());
                
                var draftdtTable = DBHelper.GetTableFromQuery(@$"Select ""DocNum"",""DocEntry"" from ODRF Where ""U_ShopifyOrderId"" ='{ShopifyOrderobj.OrderId.ToString()}' and ""U_FullfilmentId""='{ShopifyOrderobj.Id.ToString()}' and ""ObjType""=15", SAPDBRow.CompanyDb);
                var draftdtTableObj = _iB1ServiceLayer.FromTabletoObject<Orders.DocumentRow>(draftdtTable);
                deliveryRow.U_ApprovalGUID = Guid.NewGuid().ToString();
                deliveryRow.Series = Convert.ToInt32(DOSeries);
                if (draftdtTableObj.Count==0)
                {
                    var orderdtable = DBHelper.GetTableFromQuery(@$"SELECT T0.""DocNum"" ,T0.""DocEntry"" FROM ORDR T0 LEFT OUTER JOIN DLN1 T1 on T0.""DocEntry""=T1.""BaseEntry"" WHERE T0.""U_ShopifyOrderId""='{ShopifyOrderobj.OrderId.ToString()}' and T0.""DocStatus""='O'", SAPDBRow.CompanyDb);
                    var orderrowobj = _iB1ServiceLayer.FromTabletoObject<Orders.DocumentRow>(orderdtable);
                    var OrderRow = _iB1ServiceLayer.GetSLEntity<Orders.DocumentRow>(orderrowobj.FirstOrDefault(), SAPDBRow.CompanyDb);
                    deliveryRow.DBName = SAPDBRow.CompanyDb;
                    if (OrderRow != null || OrderRow.DocNum != null)
                    {
                        deliveryRow.U_FullfilmentId = ShopifyOrderobj.Id.ToString();
                        deliveryRow.CardCode = OrderRow.CardCode;
                        deliveryRow.DocDate = DateTime.Now;
                        deliveryRow.DocDueDate = DateTime.Now;
                        
                        deliveryRow.U_TID = ShopifyOrderobj.TrackingNumber??"".ToString();
                        deliveryRow.U_dosource = ShopifyOrderobj.TrackingCompany??"".ToString() ?? "Out Source";
                        var lines = new System.Collections.Generic.List<DeliveryLine.DocumentLineRow>();
                        foreach (var itemline in ShopifyOrderobj.LineItems)
                        {
                            var OrderItemLine=OrderRow.DocumentLines.Where(x => x.ItemCode == itemline.SKU).FirstOrDefault();
                            lines.Add(new DeliveryLine.DocumentLineRow()
                            {
                                ItemCode = OrderItemLine.ItemCode,
                                Quantity = ShopifyOrderobj.LineItems.Where(x => x.SKU == OrderItemLine.ItemCode).FirstOrDefault().Quantity,
                                ItemDescription = OrderItemLine.ItemDescription,
                                LineTotal = OrderItemLine.LineTotal,
                                TaxTotal = OrderItemLine.TaxTotal,
                                DiscountPercent = OrderItemLine.DiscountPercent,
                                BaseEntry = OrderRow.DocEntry,
                                BaseType = Convert.ToInt32(17),
                                BaseLine = OrderItemLine.LineNum,
                                VatGroup = OrderItemLine.VatGroup,
                                U_ShopifyOrderLineId = OrderItemLine.U_ShopifyOrderLineId,
                                WarehouseCode = GetWarehosueCodeWithLocation(StoreName,orderfromFulfilment.Fulfillments.Where(x => x.LineItems.Select(x => x.SKU == OrderItemLine.ItemCode).Count() > 0).FirstOrDefault().LocationId.ToString()),





                            });
                        }
                        deliveryRow.DocumentLines = lines;
                        return deliveryRow;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return new Delivery.DocumentRow() { DocumentStatus = "DocumentAlreadyInApproval" };
                }
               

                
            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
                return null;
            }
        }


        private DownPaymentObject generateDownPaymentObject(object ShopifyOrderRequest, string StoreName)
        {
            DownPaymentObject response = new DownPaymentObject();
            try
            {
                
                var downPaymentRow = new DownPayment.DocumentRow();

                var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());
                var conn = DBHelper.GetSerenDBConnection();
                var shopifysettings = conn.List<ShopifySettingsRow>().Where(x => x.ApiBaseURL == StoreName).FirstOrDefault();
                var SAPDBRow = conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt32(shopifysettings.SapDatabase)).FirstOrDefault();
                var table = DBHelper.GetTableFromQuery(@$"SELECT T2.""DocNum"",T2.""DocEntry"" FROM ORDR T0 Inner Join DLN1 T1 on T0.""DocEntry""=T1.""BaseEntry"" Inner Join ODLN T2 on T1.DocEntry=T2.DocEntry WHERE T0.""U_ShopifyOrderId""='{ShopifyOrderobj.Id.ToString()}'", SAPDBRow.CompanyDb);
                var rowobj = _iB1ServiceLayer.FromTabletoObject<Delivery.DocumentRow>(table);
                DataTable dpdtable = null;
                if (rowobj.Count() == 0)
                {
                    dpdtable = DBHelper.GetTableFromQuery(@$"Select T0.DocEntry,T0.DocNum from ODPI T0 Inner Join DPI1 T1 on T0.DocEntry=T1.DocEntry Inner Join ORDR T2 on T1.BaseEntry=T2.DocEntry and T1.BaseType=T2.ObjType Where T2.U_ShopifyOrderId='{ShopifyOrderobj.Id.ToString()}' AND T2.CANCELED='N' AND T0.CANCELED='N'", SAPDBRow.CompanyDb);


                }
                else
                {
                    var dpdtablecheck = DBHelper.GetTableFromQuery(@$"Select T0.DocEntry,T0.DocNum from ODPI T0 Inner Join DPI1 T1 on T0.DocEntry=T1.DocEntry Inner Join ORDR T2 on T1.BaseEntry=T2.DocEntry and T1.BaseType=T2.ObjType Where T2.U_ShopifyOrderId='{ShopifyOrderobj.Id.ToString()}' AND T2.CANCELED='N' AND T0.CANCELED='N'", SAPDBRow.CompanyDb);

                    var dprowobjcheck = _iB1ServiceLayer.FromTabletoObject<DownPayment.DocumentRow>(dpdtablecheck);
                    if(dprowobjcheck.Count() == 0)
                    {
                        dpdtable = DBHelper.GetTableFromQuery(@$"Select T0.DocEntry,T0.DocNum from ODPI T0 Inner Join DPI1 T1 on T0.DocEntry=T1.DocEntry Inner Join ODLN T2 on T1.BaseEntry=T2.DocEntry and T1.BaseType=T2.ObjType Where T2.U_ShopifyOrderId='{ShopifyOrderobj.Id.ToString()}' AND T2.CANCELED='N' AND T0.CANCELED='N'", SAPDBRow.CompanyDb);

                    }
                    else
                    {
                        dpdtable = DBHelper.GetTableFromQuery(@$"Select T0.DocEntry,T0.DocNum from ODPI T0 Inner Join DPI1 T1 on T0.DocEntry=T1.DocEntry Inner Join ORDR T2 on T1.BaseEntry=T2.DocEntry and T1.BaseType=T2.ObjType Where T2.U_ShopifyOrderId='{ShopifyOrderobj.Id.ToString()}' AND T2.CANCELED='N' AND T0.CANCELED='N'", SAPDBRow.CompanyDb);

                    }

                }
                var dprowobj = _iB1ServiceLayer.FromTabletoObject<DownPayment.DocumentRow>(dpdtable);

                if (dprowobj.Count() == 0)
                {

                   
                    if (rowobj.Count() == 0)
                    {
                        var orderdtable = DBHelper.GetTableFromQuery(@$"SELECT T0.""DocNum"" ,T0.""DocEntry"" FROM ORDR T0  WHERE T0.""U_ShopifyOrderId""='{ShopifyOrderobj.Id.ToString()}'", SAPDBRow.CompanyDb);
                        var orderrowobj = _iB1ServiceLayer.FromTabletoObject<Orders.DocumentRow>(orderdtable);
                        var OrderRow = _iB1ServiceLayer.GetSLEntity<Orders.DocumentRow>(orderrowobj.FirstOrDefault(), SAPDBRow.CompanyDb);
                        downPaymentRow.CardCode = OrderRow.CardCode;
                        downPaymentRow.DocDate = DateTime.Now;
                        downPaymentRow.DocDueDate = DateTime.Now;
                        downPaymentRow.DocType = OrderRow.DocType;
                        downPaymentRow.DownPaymentType = "dptRequest";
                        downPaymentRow.DocObjectCode = "oDownPayments";
                        
                        var lines = new System.Collections.Generic.List<DownPayment.DocumentLineRow>();
                        foreach (var itemline in OrderRow.DocumentLines)
                        {
                            lines.Add(new DownPayment.DocumentLineRow()
                            {
                                ItemCode = itemline.ItemCode,
                                Quantity = itemline.Quantity,
                                ItemDescription = itemline.ItemDescription,
                                LineTotal = itemline.LineTotal,
                                TaxTotal = itemline.TaxTotal,
                                DiscountPercent = itemline.DiscountPercent,
                                VatGroup = itemline.VatGroup,
                                BaseEntry = OrderRow.DocEntry,

                                BaseType = Convert.ToInt32(17),
                                BaseLine = itemline.LineNum




                            });
                        }
                        downPaymentRow.DocumentLines = lines;
                        response.Row = downPaymentRow;
                        response.Type = "C";
                        return response;

                    }
                    else
                    {
                        var DLOrderRow = _iB1ServiceLayer.GetSLEntity<Delivery.DocumentRow>(rowobj.FirstOrDefault(), SAPDBRow.CompanyDb);
                        downPaymentRow.CardCode = DLOrderRow.CardCode;
                        downPaymentRow.DocDate = DateTime.Now;
                        downPaymentRow.DocDueDate = DateTime.Now;
                        downPaymentRow.DocType = DLOrderRow.DocType;
                        downPaymentRow.DownPaymentType = "dptRequest";
                        downPaymentRow.DocObjectCode = "oDownPayments";
                        downPaymentRow.U_CanceledAt = DLOrderRow.U_CanceledAt;
                        downPaymentRow.U_PaymentMethod = DLOrderRow.U_PaymentMethod;
                        downPaymentRow.U_OrderNumber = DLOrderRow.U_OrderNumber.ToString();
                        var lines = new System.Collections.Generic.List<DownPayment.DocumentLineRow>();
                        foreach (var itemline in DLOrderRow.DocumentLines)
                        {
                            lines.Add(new DownPayment.DocumentLineRow()
                            {
                                ItemCode = itemline.ItemCode,
                                Quantity = itemline.Quantity,
                                ItemDescription = itemline.ItemDescription,
                                LineTotal = itemline.LineTotal,
                                TaxTotal = itemline.TaxTotal,
                                DiscountPercent = itemline.DiscountPercent,
                                BaseEntry = DLOrderRow.DocEntry,
                                BaseType = Convert.ToInt32(15),
                                BaseLine = itemline.LineNum




                            });
                        }
                        downPaymentRow.DocumentLines = lines;
                        response.Row = downPaymentRow;
                        response.Type = "C";
                        return response;
                    }
                   
                    
                }
                else
                {
                    var DPRow = _iB1ServiceLayer.GetSLEntity<DownPayment.DocumentRow>(dprowobj.FirstOrDefault(), SAPDBRow.CompanyDb);
                    downPaymentRow.DocEntry = DPRow.DocEntry;
                    downPaymentRow.DocNum = DPRow.DocNum;
                    downPaymentRow.CardCode = DPRow.CardCode;
                    downPaymentRow.DocDate = DateTime.Now;
                    downPaymentRow.DocDueDate = DateTime.Now;
                    downPaymentRow.DocType = DPRow.DocType;
                    downPaymentRow.DownPaymentType = DPRow.DownPaymentType;
                    downPaymentRow.DocObjectCode = DPRow.DocObjectCode;
                    downPaymentRow.U_CanceledAt = DPRow.U_CanceledAt;
                    downPaymentRow.U_PaymentMethod = DPRow.U_PaymentMethod;
                    downPaymentRow.U_OrderNumber = DPRow.U_OrderNumber.ToString();
                    response.Row = downPaymentRow;
                    response.Type = "U";

                    return response;
                }



            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
                return null;
            }
        }
        private IncomingPayment.PaymentRow generateIncomingPaymentObject(object ShopifyOrderRequest,DownPayment.DocumentRow documentRow, string StoreName)
        {
            try
            {
                var PaymentRow = new IncomingPayment.PaymentRow();
                var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());
                var conn = DBHelper.GetSerenDBConnection();
                var shopifysettings = conn.List<ShopifySettingsRow>().Where(x => x.ApiBaseURL == StoreName).FirstOrDefault();
                var SAPDBRow = conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt32(shopifysettings.SapDatabase)).FirstOrDefault();

                var table = DBHelper.GetTableFromQuery(@$"Select T1.DocEntry,T1.DocNum from RCT2 T0  Inner Join ODPI T1 on T1.DocEntry=T0.DocEntry and T0.InvType=T1.ObjType Where T0.DocEntry='{documentRow.DocEntry}' ", SAPDBRow.CompanyDb);
                var rowobj = _iB1ServiceLayer.FromTabletoObject<DownPayment.DocumentRow>(table);
                var Lines = from A0 in conn.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                            join A1 in conn.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                var INCPSeries = Lines.Where(x => x.ShopifySubSettingsName == "INCPSeries").FirstOrDefault().ShopifySubSettingsSapValue;
                PaymentRow.Series = Convert.ToInt32(INCPSeries);
                if (rowobj.Count() == 0)
                {
                    

                    if (documentRow != null || documentRow.DocNum != null)
                    {
                        PaymentRow.CardCode = documentRow.CardCode;
                        PaymentRow.DocDate = DateTime.Now;
                        PaymentRow.DueDate = DateTime.Now;
                        PaymentRow.TransferDate = DateTime.Now;
                        PaymentRow.U_Sector = "Website";
                        var Invoicelines = new System.Collections.Generic.List<IncomingPayment.PaymentInvoiceRow>();
                        Invoicelines.Add(new IncomingPayment.PaymentInvoiceRow()
                        {
                            DocEntry = documentRow.DocEntry,
                            InvoiceType = "it_DownPayment"
                        });


                        PaymentRow.CheckAccount= Lines.Where(x => x.ShopifySubSettingsName == "CheckAccount").FirstOrDefault().ShopifySubSettingsSapValue;


                        #region Commented Code
                        /*if (ShopifyOrderobj.PaymentGatewayNames.Any(x => x == "Cash on Delivery (COD)"))
                        {

                            if (Lines.Any(x => x.ShopifySubSettingsName == "CashAccount"))
                            {
                                PaymentRow.PaymentChecks = new System.Collections.Generic.List<IncomingPayment.PaymentCheckRow>() {
                                    new IncomingPayment.PaymentCheckRow() {
                                        CheckAccount = Lines.Where(x => x.ShopifySubSettingsName == "CashAccount").FirstOrDefault().ShopifySubSettingsSapValue,
                                        CheckSum = Convert.ToDouble(documentRow.DocTotal),
                                        BankCode = Lines.Where(x => x.ShopifySubSettingsName == "BankCode").FirstOrDefault().ShopifySubSettingsSapValue
                                    }
                                };                                *//*PaymentRow.CashAccount = Lines.Where(x => x.ShopifySubSettingsName == "CashAccount").FirstOrDefault().ShopifySubSettingsSapValue;
                                PaymentRow.CashSum = Convert.ToDouble(documentRow.DocTotal);*//*
                            }


                        }
                        if (ShopifyOrderobj.PaymentGatewayNames.Any(x => x == "Bank Deposit"))
                        {
                            if (Lines.Any(x => x.ShopifySubSettingsName == "TransferAccount"))
                            {
                                PaymentRow.PaymentChecks = new System.Collections.Generic.List<IncomingPayment.PaymentCheckRow>() {
                                    new IncomingPayment.PaymentCheckRow() {
                                        CheckAccount = Lines.Where(x => x.ShopifySubSettingsName == "CashAccount").FirstOrDefault().ShopifySubSettingsSapValue,
                                        CheckSum = Convert.ToDouble(documentRow.DocTotal),
                                        BankCode = Lines.Where(x => x.ShopifySubSettingsName == "BankCode").FirstOrDefault().ShopifySubSettingsSapValue
                                    }
                                };
                                *//* PaymentRow.TransferAccount = Lines.Where(x => x.ShopifySubSettingsName == "TransferAccount").FirstOrDefault().ShopifySubSettingsSapValue;
                                 PaymentRow.TransferSum = Convert.ToDouble(documentRow.DocTotal);*//*
                            }

                        }
                        if (ShopifyOrderobj.PaymentGatewayNames.Any(x => x == "manual"))
                        {
                            if (Lines.Any(x => x.ShopifySubSettingsName == "CashAccount"))
                            {
                                PaymentRow.PaymentChecks = new System.Collections.Generic.List<IncomingPayment.PaymentCheckRow>() { 
                                    new IncomingPayment.PaymentCheckRow() {
                                        CheckAccount = Lines.Where(x => x.ShopifySubSettingsName == "CashAccount").FirstOrDefault().ShopifySubSettingsSapValue, 
                                        CheckSum = Convert.ToDouble(documentRow.DocTotal), 
                                        BankCode = Lines.Where(x => x.ShopifySubSettingsName == "BankCode").FirstOrDefault().ShopifySubSettingsSapValue
                                    } 
                                };

                                *//*PaymentRow.CashAccount = Lines.Where(x => x.ShopifySubSettingsName == "CashAccount").FirstOrDefault().ShopifySubSettingsSapValue;
                                PaymentRow.CashSum = Convert.ToDouble(documentRow.DocTotal);*//*
                            }
                        }*/
                        #endregion


                        PaymentRow.PaymentChecks = new System.Collections.Generic.List<IncomingPayment.PaymentCheckRow>() {
                                    new IncomingPayment.PaymentCheckRow() {
                                        CheckAccount = Lines.Where(x => x.ShopifySubSettingsName == "CheckAccount").FirstOrDefault().ShopifySubSettingsSapValue,
                                        CheckSum = Convert.ToDouble(documentRow.DocTotal),
                                        BankCode = Lines.Where(x => x.ShopifySubSettingsName == "BankCode").FirstOrDefault().ShopifySubSettingsSapValue,
                                        CountryCode="PK"


                                    }
                                };
                        PaymentRow.PaymentInvoices = Invoicelines;
                        return PaymentRow;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }



            }
            catch (Exception Ex)
            {
                ExceptionsController.Log(Ex);
                return null;
            }
        }

        private Returns.DocumentRow generateReturnObject(object ShopifyOrderRequest,string StoreName)
        {
            Returns.DocumentRow documentRow = new Returns.DocumentRow();

            var ShopifyOrderobj = JsonConvert.DeserializeObject<Order>(ShopifyOrderRequest.ToString());

            try
            {



                var conn = DBHelper.GetSerenDBConnection();
                var shopifysettings = conn.List<ShopifySettingsRow>().Where(x => x.ApiBaseURL == StoreName).FirstOrDefault();
                var SAPDBRow = conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt32(shopifysettings.SapDatabase)).FirstOrDefault();

                var Lines = from A0 in conn.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                            join A1 in conn.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                var draftdtTable = DBHelper.GetTableFromQuery(@$"Select ""DocNum"",""DocEntry"" from ODRF Where ""U_ShopifyOrderId"" ='{ShopifyOrderobj.Id.ToString()}' and ""DocStatus""='O' and ""ObjType""=16", SAPDBRow.CompanyDb);
                var draftdtTableObj = _iB1ServiceLayer.FromTabletoObject<Orders.DocumentRow>(draftdtTable);
                var RTRNSeries = Lines.Where(x => x.ShopifySubSettingsName == "RTRNSeries").FirstOrDefault().ShopifySubSettingsSapValue;
                documentRow.Series = Convert.ToInt32(RTRNSeries);
                documentRow.U_ApprovalGUID = Guid.NewGuid().ToString();
                if (draftdtTableObj.Count==0)
                {
                    

                    var returndtable = DBHelper.GetTableFromQuery(@$"Select T0.DocEntry,T0.DocNum from ORDN T0 Inner Join RDN1 T1 on T0.DocEntry=T1.DocEntry Inner Join ODLN T2 on T1.BaseEntry=T2.DocEntry Inner Join DLN1 T3 on T2.DocEntry=T3.DocEntry Inner Join ORDR T4 on T3.BaseEntry=T4.DocEntry and T3.BaseType=T4.ObjType Where T2.U_ShopifyOrderId='{ShopifyOrderobj.Id.ToString()}'", SAPDBRow.CompanyDb);
                    var returnrowobj = _iB1ServiceLayer.FromTabletoObject<Delivery.DocumentRow>(returndtable);

                    var deliverydtable = DBHelper.GetTableFromQuery(@$"Select T0.DocEntry,T0.DocNum from ODLN T0 Inner Join DLN1 T1 on T0.DocEntry=T1.DocEntry Inner Join ORDR T2 on T1.BaseEntry=T2.DocEntry Where T2.U_ShopifyOrderId='{ShopifyOrderobj.Id.ToString()}' and T0.DocStatus='O' ", SAPDBRow.CompanyDb);
                    var deliveryrowobj = _iB1ServiceLayer.FromTabletoObject<Delivery.DocumentRow>(deliverydtable);
                    if (deliveryrowobj != null)
                    {
                        var DeliveryRow = _iB1ServiceLayer.GetSLEntity<Delivery.DocumentRow>(deliveryrowobj.FirstOrDefault(), SAPDBRow.CompanyDb);

                        if (DeliveryRow != null)
                        {
                            documentRow.U_FullfilmentId=DeliveryRow.U_FullfilmentId;
                            documentRow.CardCode = DeliveryRow.CardCode;
                            documentRow.DocDate = DateTime.Now;
                            documentRow.DocDueDate = DateTime.Now;
                            documentRow.DocType = DeliveryRow.DocType;
                            documentRow.DocObjectCode = "oReturns";
                            documentRow.U_CanceledAt = DeliveryRow.U_CanceledAt;
                            documentRow.U_PaymentMethod = DeliveryRow.U_PaymentMethod;
                            documentRow.U_OrderNumber = DeliveryRow.U_OrderNumber.ToString();
                            documentRow.U_ReturnReason = ShopifyOrderobj.Refunds.FirstOrDefault().Note;
                            var refunddtable = DBHelper.GetTableFromQuery(@$"Select T0.DocEntry,T0.DocNum from ODLN T0 Inner Join DLN1 T1 on T0.DocEntry=T1.DocEntry Inner Join ORDR T2 on T1.BaseEntry=T2.DocEntry Where T2.U_ShopifyOrderId='{ShopifyOrderobj.Id.ToString()}' and T0.DocStatus='O' ", SAPDBRow.CompanyDb);
                            var refundyrowobj = _iB1ServiceLayer.FromTabletoObject<Delivery.DocumentRow>(refunddtable);
                            if (refundyrowobj.Count() != 0)
                            {
                                foreach (var r in ShopifyOrderobj.Refunds)
                                {

                                    var refdtable = DBHelper.GetTableFromQuery(@$"select T0.DocEntry,T0.DocNum from ORDN T0 Where T0.U_RefundId='{r.Id}' ", SAPDBRow.CompanyDb);
                                    var refrowobj = _iB1ServiceLayer.FromTabletoObject<Returns.DocumentRow>(refdtable);
                                    if (refrowobj.Count() == 0)
                                    {
                                        documentRow.U_RefundId = r.Id.ToString();


                                        var lines = new System.Collections.Generic.List<Returns.DocumentLineRow>();


                                        foreach (var t in r.RefundLineItems)
                                        {

                                            var ShopifyItemId = ShopifyOrderobj.LineItems.Where(x => x.Id == t.LineItemId).FirstOrDefault();
                                            var itemdtable = DBHelper.GetTableFromQuery(@$"Select T0.ItemCode,T0.ItemName from OITM T0 Where ItemCode='{ShopifyItemId.SKU}'", SAPDBRow.CompanyDb);
                                            var itemrowobj = _iB1ServiceLayer.FromTabletoObject<ItemRow>(itemdtable).FirstOrDefault();
                                            var itemline = DeliveryRow.DocumentLines.Where(x => x.ItemCode == itemrowobj.ItemCode && x.U_ShopifyOrderLineId == t.LineItemId.ToString()).FirstOrDefault();
                                            lines.Add(new Returns.DocumentLineRow()
                                            {
                                                ItemCode = itemrowobj.ItemCode,
                                                Quantity = t.Quantity,
                                                VatGroup = itemline.VatGroup,

                                                ItemDescription = itemrowobj.ItemName,
                                                LineTotal = itemline.LineTotal,
                                                TaxTotal = itemline.TaxTotal,
                                                DiscountPercent = itemline.DiscountPercent,
                                                BaseEntry = DeliveryRow.DocEntry,
                                                BaseType = 15,
                                                BaseLine = itemline.LineNum,
                                                U_ShopifyOrderLineId = itemline.U_ShopifyOrderLineId





                                            });
                                        }

                                        documentRow.DocumentLines = lines;
                                    }

                                }

                            }


                            return documentRow;



                        }
                        else
                        {
                            return null;

                        }

                    }
                    else
                    {
                        return null;

                    }

                }
                else
                {
                    return new Returns.DocumentRow(){ DocumentStatus = "DocumentAlreadyInApproval" };

                }

               
               

                




            }
            catch (Exception ex)
            {
               

                ExceptionsController.Log(ex);
                return null;
            }

        }

        private bool IsInApproval(string GUID, string DBName)
        {
            bool IsApproval = false;
            if (GUID != null)
            {
                var query = String.Format(DBHelper.GetQuery("Query_53", DBName), GUID);
                try
                {
                    using (var reader = DBHelper.DoQuery(query, DBName))
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
        private string GetWarehosueCodeWithLocation(string StoreName,string LocationId)
        {
            var conn = DBHelper.GetSerenDBConnection();
            var shopifysettings = conn.List<ShopifySettingsRow>().Where(x => x.ApiBaseURL == StoreName).FirstOrDefault();
            var SAPDBRow = conn.List<SapDatabasesRow>().Where(x => x.Id == Convert.ToInt32(shopifysettings.SapDatabase)).FirstOrDefault();

            var Lines = conn.List<ShopifyLocationDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id && x.ShopifyLocationCode==LocationId).FirstOrDefault();
                        
            
            return Lines.SapWarhouseCode;
        }
        




    }
    interface ISAPtoShopifyController {
         void SAPToShopifyIterationItemFunc();
         void SAPToShopifyIterationItemPricesFunc();
         void SAPToShopifyIterationStockFunc();
         void SAPToShopifyGetItemsFunc();
         void SAPToShopifyGetItemsFunc2();
    }

    [Route("Services/SAPtoShopifyController/Api/[action]")]
    public class SAPtoShopifyController:ServiceEndpoint, ISAPtoShopifyController
    {
        IB1ServiceLayer _iB1ServiceLayer;
        ISharpShopify _iSharpShopify;
        ISqlConnections _sqlConnections;
        IDbConnection _dbConnection;
        ILog _ilog;
        public SAPtoShopifyController(IB1ServiceLayer iB1ServiceLayer, ISharpShopify iSharpShopify,ISqlConnections sqlConnections,ILog ilog)
        {
            _dbConnection= DBHelper.GetSerenDBConnection();
            _iB1ServiceLayer = iB1ServiceLayer;
            _iSharpShopify = iSharpShopify;
            _sqlConnections = sqlConnections;
            _ilog = ilog;
        }
        [HttpPost,IgnoreAntiforgeryToken]
        public void CreateItem(GetChangesObject _object,string CompanyDB)
        {
            try
            {
                var CompanyDb = CompanyDB;

                var DatabaseRow = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().Where(x => x.CompanyDb == CompanyDb).FirstOrDefault();

                var ItemCode = _object.U_Key;

                var ItemObj = _iB1ServiceLayer.GetSLEntity<ItemRow>(new ItemRow() { ItemCode = ItemCode }, CompanyDb);

                LogRow log = new LogRow();
                log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
                log.ShopifyPayload = "";
                if (ItemObj != null && ItemObj.U_ItemStat == "Y")
                {
                    if (ItemObj.U_Yatas == "Y" && ItemObj.U_Enza == "Y")
                    {
                        try
                        {

                            var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString());

                            foreach (var q in stores)
                            {
                                var StoreName = q.StoreName;
                                log.ShopifyId = StoreName;
                                var _Items = _iSharpShopify.GetAllItems(StoreName).SelectMany(x => x.Variants).Where(x => x.SKU == ItemCode);
                                if (_Items.Count() > 0)
                                {
                                    var Items = _Items.FirstOrDefault();


                                    var allRows = _iB1ServiceLayer.GetSLList<ItemRow>(CompanyDb);

                                    var ChildRows = allRows.Where(x => x.U_IsParent == "Y" && x.ItemCode == ItemCode).ToList();



                                    Product row = new Product();
                                    row.Title = ItemObj.U_SH_Des;
                                    row.BodyHtml = ItemObj.User_Text;
                                    //row.Vendor = ItemObj.Mainsupplier;
                                    if (ItemObj.U_Active == "Y")
                                    {
                                        row.Status = "active";

                                    }
                                    else
                                    {
                                        row.Status = "draft";

                                    }
                                    row.ProductType = ItemObj.U_sub;
                                    var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                    var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                                join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                                select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };

                                    var PriceList = "";
                                    if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                    {
                                        PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                    }
                                    var Varients = new System.Collections.Generic.List<ProductVariant>();
                                    foreach (var r in ChildRows)
                                    {
                                        var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                        var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                        var varient = new ProductVariant()
                                        {
                                            Title = r.ItemName,
                                            SKU = r.ItemCode,
                                            Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                            CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                            //CompareAtPrice = 20

                                        };
                                        Varients.Add(varient);
                                    }

                                    row.Variants = Varients;



                                    var response = _iSharpShopify.Create<Product>(row, StoreName);
                                    if (response != null)
                                    {
                                        CreateLog(_object, StoreName);


                                        log.URequest = JsonConvert.SerializeObject(row);
                                        log.UError = LogEnums.UError.False.ToString();
                                        log.UObjType = "CreateProduct";
                                        log.UDateTime = DateTime.Now;
                                        log.UResponse = JsonConvert.SerializeObject(response);
                                        _ilog.Log(log);
                                    }
                                    else
                                    {

                                        log.URequest = JsonConvert.SerializeObject(row);
                                        log.UError = LogEnums.UError.True.ToString();
                                        log.UObjType = "CreateProduct";
                                        log.UDateTime = DateTime.Now;
                                        log.UResponse = JsonConvert.SerializeObject(response);
                                        _ilog.Log(log);
                                    }
                                }
                                else
                                {
                                    var allRows = _iB1ServiceLayer.GetSLList<ItemRow>(CompanyDb);

                                    var ChildRows = allRows.Where(x => x.U_IsParent == "Y" && x.ItemCode == ItemCode).ToList();



                                    Product row = new Product();
                                    row.Title = ItemObj.U_SH_Des;
                                    row.BodyHtml = ItemObj.User_Text;
                                   // row.Vendor = ItemObj.Mainsupplier;

                                    if (ItemObj.U_Active == "Y")
                                    {
                                        row.Status = "active";

                                    }
                                    else
                                    {
                                        row.Status = "draft";

                                    }
                                    row.ProductType = ItemObj.U_sub;
                                    var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                    var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                                join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                                select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };

                                    var PriceList = "";
                                    if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                    {
                                        PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                    }
                                    var Varients = new System.Collections.Generic.List<ProductVariant>();
                                    foreach (var r in ChildRows)
                                    {
                                        var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                        var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                        var varient = new ProductVariant()
                                        {
                                            Title = r.U_SH_Des,
                                            SKU = r.ItemCode,

                                            Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                            CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                            //CompareAtPrice = 20

                                        };
                                        Varients.Add(varient);
                                    }

                                    row.Variants = Varients;



                                    var response = _iSharpShopify.Create<Product>(row, StoreName);
                                    if (response != null)
                                    {
                                        CreateLog(_object, StoreName);


                                        log.URequest = JsonConvert.SerializeObject(row);
                                        log.UError = LogEnums.UError.False.ToString();
                                        log.UObjType = "CreateProduct";
                                        log.UDateTime = DateTime.Now;
                                        log.UResponse = JsonConvert.SerializeObject(response);
                                        _ilog.Log(log);
                                    }
                                    else
                                    {

                                        log.URequest = JsonConvert.SerializeObject(row);
                                        log.UError = LogEnums.UError.True.ToString();
                                        log.UObjType = "CreateProduct";
                                        log.UDateTime = DateTime.Now;
                                        log.UResponse = JsonConvert.SerializeObject(response);
                                        _ilog.Log(log);
                                    }

                                }

                            }
                            //check if item Exists in Shopify
                            //Check if Item is header or not

                        }
                        catch (Exception ex)
                        {
                            //log.URequest = JsonConvert.SerializeObject(row);
                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "CreateProduct";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex);
                            //throw;
                        }
                    }
                    else if (ItemObj.U_Enza == "Y")
                    {
                        try
                        {

                            var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString() && x.SAPStoreName == "Enza");
                            var StoreName = stores.FirstOrDefault().StoreName;
                            log.ShopifyId = StoreName;

                            //check if item Exists in Shopify
                            //Check if Item is header or not
                            var _Items = _iSharpShopify.GetAllItems(StoreName).SelectMany(x => x.Variants).Where(x => x.SKU == ItemCode);
                            if (_Items.Count() > 0)
                            {
                                var Items = _Items.FirstOrDefault();


                                var allRows = _iB1ServiceLayer.GetSLList<ItemRow>(CompanyDb);

                                var ChildRows = allRows.Where(x => x.U_IsParent == "Y" && x.ItemCode == ItemCode).ToList();



                                Product row = new Product();
                                row.Title = ItemObj.U_SH_Des;
                                row.BodyHtml = ItemObj.User_Text;
                                //row.Vendor = ItemObj.Mainsupplier;
                                if (ItemObj.U_Active == "Y")
                                {
                                    row.Status = "active";

                                }
                                else
                                {
                                    row.Status = "draft";

                                }
                                row.ProductType = ItemObj.U_sub;
                                var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                            join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                                //ExceptionsController.Log(new Exception("ShopifyDetailLines"), JsonConvert.SerializeObject(Lines));

                                var PriceList = "";
                                if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                {
                                    PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                }
                                var Varients = new System.Collections.Generic.List<ProductVariant>();
                                foreach (var r in ChildRows)
                                {
                                    var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                    var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                    var varient = new ProductVariant()
                                    {
                                        Title = r.ItemName,
                                        SKU = r.ItemCode,
                                        Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                        CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                        //CompareAtPrice = 20

                                    };
                                    Varients.Add(varient);
                                }

                                row.Variants = Varients;



                                var response = _iSharpShopify.Create<Product>(row, StoreName);
                                if (response != null)
                                {
                                    CreateLog(_object, StoreName);


                                    log.URequest = JsonConvert.SerializeObject(row);
                                    log.UError = LogEnums.UError.False.ToString();
                                    log.UObjType = "CreateProduct";
                                    log.UDateTime = DateTime.Now;
                                    log.UResponse = JsonConvert.SerializeObject(response);
                                    _ilog.Log(log);
                                }
                                else
                                {

                                    log.URequest = JsonConvert.SerializeObject(row);
                                    log.UError = LogEnums.UError.True.ToString();
                                    log.UObjType = "CreateProduct";
                                    log.UDateTime = DateTime.Now;
                                    log.UResponse = JsonConvert.SerializeObject(response);
                                    _ilog.Log(log);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            //log.URequest = JsonConvert.SerializeObject(row);
                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "CreateProduct";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex);
                            //throw;
                        }
                    }
                    else if (ItemObj.U_Yatas == "Y")
                    {
                        try
                        {

                            var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString() && x.SAPStoreName == "Yatas");
                            var StoreName = stores.FirstOrDefault().StoreName;
                            log.ShopifyId = StoreName;

                            //check if item Exists in Shopify
                            //Check if Item is header or not
                            var _Items = _iSharpShopify.GetAllItems(StoreName).SelectMany(x => x.Variants).Where(x => x.SKU == ItemCode);
                            if (_Items.Count() > 0)
                            {
                                var Items = _Items.FirstOrDefault();

                                var allRows = _iB1ServiceLayer.GetSLList<ItemRow>(CompanyDb);

                                var ChildRows = allRows.Where(x => x.U_IsParent == "Y" && x.ItemCode == ItemCode).ToList();



                                Product row = new Product();
                                row.Title = ItemObj.U_SH_Des;
                                row.BodyHtml = ItemObj.User_Text;
                                //row.Vendor = ItemObj.Mainsupplier;
                                if (ItemObj.U_Active == "Y")
                                {
                                    row.Status = "active";

                                }
                                else
                                {
                                    row.Status = "draft";

                                }
                                row.ProductType = ItemObj.U_sub;
                                var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                            join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                                //ExceptionsController.Log(new Exception("ShopifyDetailLines"), JsonConvert.SerializeObject(Lines));

                                var PriceList = "";
                                if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                {
                                    PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                }
                                var Varients = new System.Collections.Generic.List<ProductVariant>();
                                foreach (var r in ChildRows)
                                {
                                    var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                    var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                    var varient = new ProductVariant()
                                    {
                                        Title = r.ItemName,
                                        SKU = r.ItemCode,
                                        Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                        CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                        //CompareAtPrice = 20

                                    };
                                    Varients.Add(varient);
                                }

                                row.Variants = Varients;



                                var response = _iSharpShopify.Create<Product>(row, StoreName);
                                if (response != null)
                                {
                                    CreateLog(_object, StoreName);


                                    log.URequest = JsonConvert.SerializeObject(row);
                                    log.UError = LogEnums.UError.False.ToString();
                                    log.UObjType = "CreateProduct";
                                    log.UDateTime = DateTime.Now;
                                    log.UResponse = JsonConvert.SerializeObject(response);
                                    _ilog.Log(log);
                                }
                                else
                                {

                                    log.URequest = JsonConvert.SerializeObject(row);
                                    log.UError = LogEnums.UError.True.ToString();
                                    log.UObjType = "CreateProduct";
                                    log.UDateTime = DateTime.Now;
                                    log.UResponse = JsonConvert.SerializeObject(response);
                                    _ilog.Log(log);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            //log.URequest = JsonConvert.SerializeObject(row);
                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "CreateProduct";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex);
                            //throw;
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
                //throw;
            }
            

            
        }


        [HttpPost, IgnoreAntiforgeryToken]
        public void UpdateItem(GetChangesObject _object, string CompanyDB)
        {
            try
            {
                var CompanyDb = CompanyDB;

                var DatabaseRow = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().Where(x => x.CompanyDb == CompanyDb).FirstOrDefault();

                var ItemCode = _object.U_Key;

                var ItemObj = _iB1ServiceLayer.GetSLEntity<ItemRow>(new ItemRow() { ItemCode = ItemCode }, CompanyDb);

                LogRow log = new LogRow();
                log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
                log.ShopifyPayload = "";

                if (ItemObj.U_ItemStat == "Y" && ItemObj != null)
                {
                    if (ItemObj.U_Enza == "Y" && ItemObj.U_Yatas == "Y")
                    {
                        var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString());

                        foreach (var r in stores)
                        {
                            var StoreName = r.StoreName;
                            log.ShopifyId = StoreName;
                            try
                            {




                                //check if item Exists in Shopify
                                //Check if Item is header or not
                                var _Itemslst = _iSharpShopify.GetAllItems(StoreName);
                                var _Items = _Itemslst?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemCode);
                                if (_Items != null)
                                {
                                    var Items = _Items.FirstOrDefault();
                                    var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                    var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                                join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                                select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                                    var PriceList = "";
                                    if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                    {
                                        PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                    }

                                    if (Items != null)
                                    {
                                        var isParent = (ItemObj.U_IsParent == "Y");
                                        if (isParent)
                                        {
                                            Product row = new Product();
                                            row.Id = Items.ProductId;
                                            row.Title = ItemObj.U_SH_Des;
                                            row.BodyHtml = ItemObj.User_Text;
                                            //row.Vendor = ItemObj.Mainsupplier;
                                           
                                            if (ItemObj.U_Active == "Y")
                                            {
                                                row.Status = "active";

                                            }
                                            else
                                            {
                                                row.Status = "draft";

                                            }
                                            row.ProductType = ItemObj.U_sub;
                                            var Varients = new System.Collections.Generic.List<ProductVariant>();

                                            var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                            var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                            var varient = new ProductVariant()
                                            {
                                                Id= _Items.FirstOrDefault().Id,
                                                Title = ItemObj.U_SH_Des,
                                                SKU = ItemObj.ItemCode,
                                                Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                                CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                                InventoryItemId = _Items.FirstOrDefault().InventoryItemId,
                                                InventoryManagement= "shopify",
                                                InventoryPolicy = "deny",


                                            };


                                            Varients.Add(varient);


                                            row.Variants = Varients;
                                            var response = _iSharpShopify.Update<Product>(row, StoreName);
                                            if (response != null)
                                            {
                                                CreateLog(_object, StoreName);
                                                log.URequest = JsonConvert.SerializeObject(row);
                                                log.UError = LogEnums.UError.False.ToString();
                                                log.UObjType = "UpdateProduct";
                                                log.UDateTime = DateTime.Now;
                                                log.UResponse = JsonConvert.SerializeObject(response);
                                                _ilog.Log(log);
                                            }

                                        }
                                        else
                                        {


                                            var Varients = new System.Collections.Generic.List<ProductVariant>();
                                            var ChildItemRow = _iSharpShopify?.GetAllItems(StoreName)?.SelectMany(x => x.Variants)?.Where(x => x.SKU == ItemCode)?.FirstOrDefault();


                                            var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                            var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                            var varient = new ProductVariant()
                                            {
                                                Id = ChildItemRow.Id,
                                                ProductId = ChildItemRow.ProductId,
                                                Title = ItemObj.U_SH_Des,
                                                SKU = ItemObj.ItemCode,
                                                InventoryItemId = _Items.FirstOrDefault().InventoryItemId,
                                                InventoryManagement = "shopify",
                                                InventoryPolicy= "deny",
                                                Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                                CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                            };

                                            var response = _iSharpShopify.Update<ProductVariant>(varient, StoreName);
                                            if (response != null)
                                            {
                                                CreateLog(_object, StoreName);
                                                log.ShopifyId = StoreName;
                                                log.URequest = JsonConvert.SerializeObject(varient);
                                                log.UError = LogEnums.UError.False.ToString();
                                                log.UObjType = "UpdateVarient";
                                                log.UDateTime = DateTime.Now;
                                                log.UResponse = JsonConvert.SerializeObject(response);
                                                _ilog.Log(log);
                                            }

                                        }
                                    }
                                    else
                                    {
                                        CreateItem(_object, CompanyDB);
                                    }
                                }


                            }
                            catch (Exception ex)
                            {
                                log.ShopifyId = StoreName;

                                log.UError = LogEnums.UError.True.ToString();
                                log.UObjType = "UpdateProductOrVarient";
                                log.UDateTime = DateTime.Now;
                                log.UResponse = JsonConvert.SerializeObject(ex);
                                _ilog.Log(log);
                                ExceptionsController.Log(ex);
                                //throw;
                            }
                        }
                    }
                    else if (ItemObj.U_Enza == "Y")
                    {
                        var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString() && x.SAPStoreName == "Enza");
                        var StoreName = stores.FirstOrDefault().StoreName;
                        log.ShopifyId = StoreName;
                        try
                        {




                            //check if item Exists in Shopify
                            //Check if Item is header or not
                            var _Itemslst = _iSharpShopify.GetAllItems(StoreName);
                            var _Items = _Itemslst.SelectMany(x => x.Variants).Where(x => x.SKU == ItemCode);
                            if (_Items.Count() > 0)
                            {
                                var Items = _Items.FirstOrDefault();
                                var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                            join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                                var PriceList = "";
                                if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                {
                                    PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                }

                                if (Items != null)
                                {
                                    var isParent = (ItemObj.U_IsParent == "Y");
                                    if (isParent)
                                    {
                                        Product row = new Product();
                                        row.Id = Items.ProductId;
                                        row.Title = ItemObj.U_SH_Des;
                                        row.BodyHtml = ItemObj.User_Text;
                                        //row.Vendor = ItemObj.Mainsupplier;
                                        if (ItemObj.U_Active == "Y")
                                        {
                                            row.Status = "active";

                                        }
                                        else
                                        {
                                            row.Status = "draft";

                                        }
                                        row.ProductType = ItemObj.U_sub;
                                        var Varients = new System.Collections.Generic.List<ProductVariant>();

                                        var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                        var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                        var varient = new ProductVariant()
                                        {
                                            Id = _Items.FirstOrDefault().Id,

                                            Title = ItemObj.U_SH_Des,
                                            SKU = ItemObj.ItemCode,
                                            InventoryManagement = "shopify",
                                            InventoryPolicy = "deny",

                                            Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                            CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                            InventoryItemId = _Items.FirstOrDefault().InventoryItemId

                                        };
                                        Varients.Add(varient);


                                        row.Variants = Varients;
                                        var response = _iSharpShopify.Update<Product>(row, StoreName);
                                        if (response != null)
                                        {
                                            CreateLog(_object, StoreName);
                                            log.URequest = JsonConvert.SerializeObject(row);
                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateProduct";
                                            log.UDateTime = DateTime.Now;
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }

                                    }
                                    else
                                    {


                                        var Varients = new System.Collections.Generic.List<ProductVariant>();
                                        var ChildItemRow = _iSharpShopify.GetAllItems(StoreName).SelectMany(x => x.Variants).Where(x => x.SKU == ItemCode).FirstOrDefault();


                                        var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                        var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                        var varient = new ProductVariant()
                                        {
                                            Id = ChildItemRow.Id,
                                            ProductId = ChildItemRow.ProductId,
                                            Title = ItemObj.U_SH_Des,
                                            SKU = ItemObj.ItemCode,
                                            InventoryItemId = _Items.FirstOrDefault().InventoryItemId,
                                            InventoryPolicy = "deny",

                                            Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                            CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                            InventoryManagement = "shopify"

                                        };

                                        var response = _iSharpShopify.Update<ProductVariant>(varient, StoreName);
                                        if (response != null)
                                        {
                                            CreateLog(_object, StoreName);
                                            log.ShopifyId = StoreName;
                                            log.URequest = JsonConvert.SerializeObject(varient);
                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateVarient";
                                            log.UDateTime = DateTime.Now;
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }

                                    }
                                }
                                else
                                {
                                    CreateItem(_object, CompanyDB);
                                }
                            }


                        }
                        catch (Exception ex)
                        {
                            log.ShopifyId = StoreName;

                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "UpdateProductOrVarient";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex);
                            //throw;
                        }

                    }
                    else if (ItemObj.U_Yatas == "Y")
                    {
                        var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString() && x.SAPStoreName == "Yatas");
                        var StoreName = stores.FirstOrDefault().StoreName;
                        log.ShopifyId = StoreName;
                        try
                        {




                            //check if item Exists in Shopify
                            //Check if Item is header or not
                            var _Itemslst = _iSharpShopify.GetAllItems(StoreName);
                            var _Items = _Itemslst.SelectMany(x => x.Variants).Where(x => x.SKU == ItemCode);
                            if (_Items.Count() > 0)
                            {
                                var Items = _Items.FirstOrDefault();
                                var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                            join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                                var PriceList = "";
                                if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                {
                                    PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                }

                                if (Items != null)
                                {
                                    var isParent = (ItemObj.U_IsParent == "Y");
                                    if (isParent)
                                    {
                                        Product row = new Product();
                                        row.Id = Items.ProductId;
                                        row.Title = ItemObj.U_SH_Des;
                                        row.BodyHtml = ItemObj.User_Text;
                                        //row.Vendor = ItemObj.Mainsupplier;
                                        if (ItemObj.U_Active == "Y")
                                        {
                                            row.Status = "active";

                                        }
                                        else
                                        {
                                            row.Status = "draft";

                                        }
                                        row.ProductType = ItemObj.U_sub;
                                        var Varients = new System.Collections.Generic.List<ProductVariant>();

                                        var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                        var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                        var varient = new ProductVariant()
                                        {
                                            Id = _Items.FirstOrDefault().Id,

                                            Title = ItemObj.U_SH_Des,
                                            SKU = ItemObj.ItemCode,
                                            Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                            CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice) ,
                                            InventoryItemId = _Items.FirstOrDefault().InventoryItemId,
                                            InventoryManagement = "shopify",
                                            InventoryPolicy = "deny",



                                        };
                                        Varients.Add(varient);


                                        row.Variants = Varients;
                                        var response = _iSharpShopify.Update<Product>(row, StoreName);
                                        if (response != null)
                                        {
                                            CreateLog(_object, StoreName);
                                            log.URequest = JsonConvert.SerializeObject(row);
                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateProduct";
                                            log.UDateTime = DateTime.Now;
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }

                                    }
                                    else
                                    {


                                        var Varients = new System.Collections.Generic.List<ProductVariant>();
                                        var ChildItemRow = _iSharpShopify.GetAllItems(StoreName).SelectMany(x => x.Variants).Where(x => x.SKU == ItemCode).FirstOrDefault();


                                        var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemCode, PriceList), CompanyDb);
                                        var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                        var varient = new ProductVariant()
                                        {
                                            Id = ChildItemRow.Id,
                                            ProductId = ChildItemRow.ProductId,
                                            Title = ItemObj.U_SH_Des,
                                            SKU = ItemObj.ItemCode,
                                            Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                            CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                            InventoryManagement = "shopify",
                                            InventoryPolicy = "deny",


                                        };

                                        var response = _iSharpShopify.Update<ProductVariant>(varient, StoreName);
                                        if (response != null)
                                        {
                                            CreateLog(_object, StoreName);
                                            log.ShopifyId = StoreName;
                                            log.URequest = JsonConvert.SerializeObject(varient);
                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateVarient";
                                            log.UDateTime = DateTime.Now;
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }

                                    }
                                }
                                else
                                {
                                    CreateItem(_object, CompanyDB);
                                }
                            }


                        }
                        catch (Exception ex)
                        {
                            log.ShopifyId = StoreName;

                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "UpdateProductOrVarient";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex);
                            //throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
               // throw;
            }
            



        }

        #region ItemLevel
        [HttpPost, IgnoreAntiforgeryToken]
        public async void UpdateItemLevel(string CompanyDB)
        {
            LogRow log = new LogRow();

            var Databases = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().Where(x=>x.CompanyDb== CompanyDB).FirstOrDefault();
            
            var _stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>();
            var warehouses = DBHelper.GetSerenDBConnection().List<ShopifyLocationDetailRow>();
            var StockObjectTable = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_72_GetItemStock", Databases.CompanyDb), string.Join(",", warehouses.Select(x => $"'{x.SapWarhouseCode}'").Distinct())), Databases.CompanyDb);
           // ExceptionsController.Log(new Exception("Query for Item Level"), String.Format(DBHelper.GetQuery("Query_72_GetItemStock", Databases.CompanyDb), string.Join(",", warehouses.Select(x => $"'{x.SapWarhouseCode}'").Distinct())));
            var StockObject = _iB1ServiceLayer.FromTabletoObject<StockObject>(StockObjectTable);
            foreach(var r in StockObject)
            {
                if(r.SAPStoreName != null && r.SAPStoreName == "Both")
                {
                    var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == Databases.Id.ToString());

                    foreach (var q in stores)
                    {
                        try
                        {
                            log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
                            log.ShopifyId = q.StoreName;
                            log.ShopifyPayload = "";


                            var ItemCode = r.ItemCode;
                            var Warehouse = r.Warehouse;

                            var row = new InventoryLevel();
                            var _Item1 = _iSharpShopify?.GetAllItems(q?.StoreName)?.SelectMany(x => x?.Variants);
                            //ExceptionsController.Log(new Exception("Get varients"), JsonConvert.SerializeObject(_Item1));

                            if (_Item1!=null)
                            {
                                var _Item = _Item1?.Where(x => x?.SKU == ItemCode);
                               // ExceptionsController.Log(new Exception(ItemCode), JsonConvert.SerializeObject(_Item));

                                if (_Item!=null)
                                {
                                    var Item = _Item.FirstOrDefault();
                                    if (Item != null)
                                    {
                                        row.InventoryItemId = Item.InventoryItemId;

                                        var locationid = DBHelper.GetSerenDBConnection().List<ShopifyLocationDetailRow>().Where(x => x.SapWarhouseCode == Warehouse && x.ShopifySettingsId == q.Id).FirstOrDefault() ?? null;
                                        if (locationid != null)
                                        {
                                            row.LocationId = Convert.ToInt64(locationid.ShopifyLocationCode);
                                            var Quantity = Convert.ToDouble(r.OnHandQuantity);
                                            row.Available = Convert.ToInt64(Quantity);
                                            
                                            row.UpdatedAt = DateTime.Now;
                                            //var response1 = _iSharpShopify.Update<InventoryItem>(new InventoryItem() { Id = row.InventoryItemId ,Tracked=true,SKU= ItemCode }, q.StoreName);

                                            var response = _iSharpShopify.Update<InventoryLevel>(row, q.StoreName);

                                            await Task.Delay(2000);

                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateInventoryLevel";
                                            log.UDateTime = DateTime.Now;
                                            log.URequest = JsonConvert.SerializeObject(row);
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }
                                    }
                                }
                            }
                           
                            
                        }
                        catch (Exception ex)
                        {
                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "UpdateInventoryLevel";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex, JsonConvert.SerializeObject(stores));
                            //throw;
                        }
                    }
                }
                else if(r.SAPStoreName != null && r.SAPStoreName == "Enza")
                {
                    var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == Databases.Id.ToString() && x.SAPStoreName=="Enza").FirstOrDefault();
                    try
                    {
                        log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
                        log.ShopifyId = stores.StoreName;
                        log.ShopifyPayload = "";


                        var ItemCode = r.ItemCode;
                        var Warehouse = r.Warehouse;

                        var row = new InventoryLevel();
                        var _Item1 = _iSharpShopify?.GetAllItems(stores?.StoreName)?.SelectMany(x => x?.Variants);
                        if (_Item1!=null)
                        {
                            var _Item = _Item1.Where(x => x.SKU == ItemCode);
                            if (_Item.Count() > 0)
                            {
                                var Item = _Item.FirstOrDefault();
                                if (Item != null)
                                {
                                    row.InventoryItemId = Item.InventoryItemId;

                                    var locationid = DBHelper.GetSerenDBConnection().List<ShopifyLocationDetailRow>().Where(x => x.SapWarhouseCode == Warehouse && x.ShopifySettingsId == stores.Id).FirstOrDefault() ?? null;
                                    if (locationid != null)
                                    {
                                        row.LocationId = Convert.ToInt64(locationid.ShopifyLocationCode);
                                        var Quantity = Convert.ToDouble(r.OnHandQuantity);
                                        row.Available = Convert.ToInt64(Quantity);
                                        row.UpdatedAt = DateTime.Now;
                                        var response = _iSharpShopify.Update<InventoryLevel>(row, stores.StoreName);

                                        await Task.Delay(2000);

                                        log.UError = LogEnums.UError.False.ToString();
                                        log.UObjType = "UpdateInventoryLevel";
                                        log.UDateTime = DateTime.Now;
                                        log.URequest = JsonConvert.SerializeObject(row);
                                        log.UResponse = JsonConvert.SerializeObject(response);
                                        _ilog.Log(log);
                                    }
                                }
                            }
                        }
                        
                        
                    }
                    catch (Exception ex)
                    {
                        log.UError = LogEnums.UError.True.ToString();
                        log.UObjType = "UpdateInventoryLevel";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = JsonConvert.SerializeObject(ex);
                        _ilog.Log(log);
                        ExceptionsController.Log(ex, JsonConvert.SerializeObject(stores));
                        //throw;
                    }
                }
                else if(r.SAPStoreName != null && r.SAPStoreName == "Yatas")
                {
                    var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == Databases.Id.ToString() && x.SAPStoreName == "Yatas").FirstOrDefault();
                    try
                    {
                        log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
                        log.ShopifyId = stores.StoreName;
                        log.ShopifyPayload = "";


                        var ItemCode = r.ItemCode;
                        var Warehouse = r.Warehouse;

                        var row = new InventoryLevel();
                        var _Item1 = _iSharpShopify?.GetAllItems(stores?.StoreName)?.SelectMany(x => x?.Variants);
                        if (_Item1!=null)
                        {
                            var _Item = _Item1.Where(x => x.SKU == ItemCode);
                            if (_Item.Count() > 0)
                            {
                                var Item = _Item.FirstOrDefault();
                                if (Item != null)
                                {
                                    row.InventoryItemId = Item.InventoryItemId;

                                    var locationid = DBHelper.GetSerenDBConnection().List<ShopifyLocationDetailRow>().Where(x => x.SapWarhouseCode == Warehouse && x.ShopifySettingsId == stores.Id).FirstOrDefault() ?? null;
                                    if (locationid != null)
                                    {
                                        row.LocationId = Convert.ToInt64(locationid.ShopifyLocationCode);
                                        var Quantity = Convert.ToDouble(r.OnHandQuantity);
                                        row.Available = Convert.ToInt64(Quantity);
                                        row.UpdatedAt = DateTime.Now;
                                        var response = _iSharpShopify.Update<InventoryLevel>(row, stores.StoreName);

                                        await Task.Delay(2000);

                                        log.UError = LogEnums.UError.False.ToString();
                                        log.UObjType = "UpdateInventoryLevel";
                                        log.UDateTime = DateTime.Now;
                                        log.URequest = JsonConvert.SerializeObject(row);
                                        log.UResponse = JsonConvert.SerializeObject(response);
                                        _ilog.Log(log);
                                    }
                                }
                            }

                        }
                       
                        
                    }
                    catch (Exception ex)
                    {
                        log.UError = LogEnums.UError.True.ToString();
                        log.UObjType = "UpdateInventoryLevel";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = JsonConvert.SerializeObject(ex);
                        _ilog.Log(log);
                        ExceptionsController.Log(ex, JsonConvert.SerializeObject(stores));
                        //throw;
                    }
                }
                
            }
        }
        public void ALTUpdateItemLevel(string CompanyDB)
        {
            LogRow log = new LogRow();

            var Databases = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().Where(x => x.CompanyDb == CompanyDB).FirstOrDefault();

            var _stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>();

            var CreateTablequery = DBHelper.DoNonQuery(DBHelper.GetQuery("Query_75_GetStockStatus_Create", Databases.CompanyDb), Databases.CompanyDb);

            var warehouses = DBHelper.GetSerenDBConnection().List<ShopifyLocationDetailRow>();
            var StockObjectTable = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_75_GetStockStatus", Databases.CompanyDb), string.Join(",", warehouses.Select(x => $"'{x.SapWarhouseCode}'").Distinct())), Databases.CompanyDb);
             
            
            
            var StockObject = _iB1ServiceLayer.FromTabletoObject<StockObject>(StockObjectTable);
            foreach (var r in StockObject)
            {
                try
                {
                    if (r.SAPStoreName != null && r.SAPStoreName == "Both")
                    {
                        var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == Databases.Id.ToString());
                        var AllStoreSync = new System.Collections.Generic.List<AllStoreLevelSyncObj>();
                        var ItemCode = r.ItemCode;
                        var Warehouse = r.Warehouse;
                        foreach (var q in stores)
                        {
                            try
                            {
                                log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
                                log.ShopifyId = q.StoreName;
                                log.ShopifyPayload = "";




                                var row = new InventoryLevel();
                                var _Item1 = _iSharpShopify?.GetAllItems(q?.StoreName)?.SelectMany(x => x?.Variants);
                                if (_Item1 != null)
                                {
                                    var _Item = _Item1?.Where(x => x?.SKU == ItemCode);

                                    if (_Item != null)
                                    {
                                        var Item = _Item.FirstOrDefault();
                                        if (Item != null)
                                        {
                                            row.InventoryItemId = Item.InventoryItemId;

                                            var locationid = DBHelper.GetSerenDBConnection().List<ShopifyLocationDetailRow>().Where(x => x.SapWarhouseCode == Warehouse && x.ShopifySettingsId == q.Id).FirstOrDefault() ?? null;
                                            if (locationid != null)
                                            {
                                                row.LocationId = Convert.ToInt64(locationid.ShopifyLocationCode);
                                                var Quantity = Convert.ToDouble(r.OnHandQuantity);
                                                row.Available = Convert.ToInt64(Quantity);

                                                row.UpdatedAt = DateTime.Now;
                                                //var response1 = _iSharpShopify.Update<InventoryItem>(new InventoryItem() { Id = row.InventoryItemId ,Tracked=true,SKU= ItemCode }, q.StoreName);

                                                var response = _iSharpShopify.Update<InventoryLevel>(row, q.StoreName);
                                                //ExceptionsController.Log(new Exception(ItemCode+" "+q.StoreName),JsonConvert.SerializeObject(response));
                                                if (response != null)
                                                {
                                                    AllStoreSync.Add(new AllStoreLevelSyncObj { StoreName = q.StoreName, Synced = "Y", Quantity = Quantity.ToString() });


                                                }
                                                Task.Delay(2000);

                                                log.UError = LogEnums.UError.False.ToString();
                                                log.UObjType = "UpdateInventoryLevel";
                                                log.UDateTime = DateTime.Now;
                                                log.URequest = JsonConvert.SerializeObject(row);
                                                log.UResponse = JsonConvert.SerializeObject(response);
                                                _ilog.Log(log);
                                            }
                                        }
                                    }
                                }


                            }
                            catch (Exception ex)
                            {
                                log.UError = LogEnums.UError.True.ToString();
                                log.UObjType = "UpdateInventoryLevel";
                                log.UDateTime = DateTime.Now;
                                log.UResponse = JsonConvert.SerializeObject(ex);
                                _ilog.Log(log);
                                ExceptionsController.Log(ex, JsonConvert.SerializeObject(stores));
                                //throw;
                            }
                        }
                        ExceptionsController.Log(new Exception("Log Count"), JsonConvert.SerializeObject(AllStoreSync) +" "+ stores.ToList().Count.ToString());
                        if (AllStoreSync.Count == stores.ToList().Count)
                        {
                            try
                            {
                                DBHelper.DoQuery(@$"MERGE INTO Query_75_GetStockStatus AS target USING (SELECT '{ItemCode}' AS ItemCode, '{Warehouse}' AS WhsCode) AS source ON target.ItemCode = source.ItemCode AND target.WhsCode = source.WhsCode WHEN MATCHED THEN UPDATE SET target.OnHand = '{AllStoreSync.FirstOrDefault().Quantity}', target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, WhsCode, OnHand, Synced) VALUES ('{ItemCode}', '{Warehouse}', '{AllStoreSync.FirstOrDefault().Quantity}', 'Y');", Databases.CompanyDb);
                               // ExceptionsController.Log(new Exception("Query"), @$"MERGE INTO Query_75_GetStockStatus AS target USING (SELECT '{ItemCode}' AS ItemCode, '{Warehouse}' AS WhsCode) AS source ON target.ItemCode = source.ItemCode AND target.WhsCode = source.WhsCode WHEN MATCHED THEN UPDATE SET target.OnHand = '{AllStoreSync.FirstOrDefault().Quantity}', target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, WhsCode, OnHand, Synced) VALUES ('{ItemCode}', '{Warehouse}', '{AllStoreSync.FirstOrDefault().Quantity}', 'Y');");

                            }
                            catch (Exception ex)
                            {
                                ExceptionsController.Log(ex, @$"MERGE INTO Query_75_GetStockStatus AS target USING (SELECT '{ItemCode}' AS ItemCode, '{Warehouse}' AS WhsCode) AS source ON target.ItemCode = source.ItemCode AND target.WhsCode = source.WhsCode WHEN MATCHED THEN UPDATE SET target.OnHand = '{AllStoreSync.FirstOrDefault().Quantity}', target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, WhsCode, OnHand, Synced) VALUES ('{ItemCode}', '{Warehouse}', '{AllStoreSync.FirstOrDefault().Quantity}', 'Y');");
                                //throw;
                            }
                        }
                    }
                    else if (r.SAPStoreName != null && r.SAPStoreName == "Enza")
                    {
                        var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == Databases.Id.ToString() && x.SAPStoreName == "Enza").FirstOrDefault();
                        try
                        {
                            log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
                            log.ShopifyId = stores.StoreName;
                            log.ShopifyPayload = "";


                            var ItemCode = r.ItemCode;
                            var Warehouse = r.Warehouse;

                            var row = new InventoryLevel();
                            var _Item1 = _iSharpShopify?.GetAllItems(stores?.StoreName)?.SelectMany(x => x?.Variants);
                            if (_Item1 != null)
                            {
                                var _Item = _Item1.Where(x => x.SKU == ItemCode);
                                if (_Item.Count() > 0)
                                {
                                    var Item = _Item.FirstOrDefault();
                                    if (Item != null)
                                    {
                                        row.InventoryItemId = Item.InventoryItemId;

                                        var locationid = DBHelper.GetSerenDBConnection().List<ShopifyLocationDetailRow>().Where(x => x.SapWarhouseCode == Warehouse && x.ShopifySettingsId == stores.Id).FirstOrDefault() ?? null;
                                        if (locationid != null)
                                        {
                                            row.LocationId = Convert.ToInt64(locationid.ShopifyLocationCode);
                                            var Quantity = Convert.ToDouble(r.OnHandQuantity);
                                            row.Available = Convert.ToInt64(Quantity);
                                            row.UpdatedAt = DateTime.Now;
                                            var response = _iSharpShopify.Update<InventoryLevel>(row, stores.StoreName);
                                            if (response != null)
                                            {
                                                try
                                                {
                                                    DBHelper.DoQuery(@$"MERGE INTO Query_75_GetStockStatus AS target USING (SELECT '{ItemCode}' AS ItemCode, '{Warehouse}' AS WhsCode) AS source ON target.ItemCode = source.ItemCode AND target.WhsCode = source.WhsCode WHEN MATCHED THEN UPDATE SET target.OnHand = '{Quantity}', target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, WhsCode, OnHand, Synced) VALUES ('{ItemCode}', '{Warehouse}', '{Quantity}', 'Y');", Databases.CompanyDb);

                                                }
                                                catch (Exception ex)
                                                {

                                                    ExceptionsController.Log(ex, @$"MERGE INTO Query_75_GetStockStatus AS target USING (SELECT '{ItemCode}' AS ItemCode, '{Warehouse}' AS WhsCode) AS source ON target.ItemCode = source.ItemCode AND target.WhsCode = source.WhsCode WHEN MATCHED THEN UPDATE SET target.OnHand = '{Quantity}', target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, WhsCode, OnHand, Synced) VALUES ('{ItemCode}', '{Warehouse}', '{Quantity}', 'Y');");
                                                }

                                            }

                                            Task.Delay(2000);

                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateInventoryLevel";
                                            log.UDateTime = DateTime.Now;
                                            log.URequest = JsonConvert.SerializeObject(row);
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }
                                    }
                                }
                            }


                        }
                        catch (Exception ex)
                        {
                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "UpdateInventoryLevel";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex, JsonConvert.SerializeObject(stores));
                            //throw;
                        }
                    }
                    else if (r.SAPStoreName != null && r.SAPStoreName == "Yatas")
                    {
                        var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == Databases.Id.ToString() && x.SAPStoreName == "Yatas").FirstOrDefault();
                        try
                        {
                            log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
                            log.ShopifyId = stores.StoreName;
                            log.ShopifyPayload = "";


                            var ItemCode = r.ItemCode;
                            var Warehouse = r.Warehouse;

                            var row = new InventoryLevel();
                            var _Item1 = _iSharpShopify?.GetAllItems(stores?.StoreName)?.SelectMany(x => x?.Variants);
                            if (_Item1 != null)
                            {
                                var _Item = _Item1.Where(x => x.SKU == ItemCode);
                                if (_Item.Count() > 0)
                                {
                                    var Item = _Item.FirstOrDefault();
                                    if (Item != null)
                                    {
                                        row.InventoryItemId = Item.InventoryItemId;

                                        var locationid = DBHelper.GetSerenDBConnection().List<ShopifyLocationDetailRow>().Where(x => x.SapWarhouseCode == Warehouse && x.ShopifySettingsId == stores.Id).FirstOrDefault() ?? null;
                                        if (locationid != null)
                                        {
                                            row.LocationId = Convert.ToInt64(locationid.ShopifyLocationCode);
                                            var Quantity = Convert.ToDouble(r.OnHandQuantity);
                                            row.Available = Convert.ToInt64(Quantity);
                                            row.UpdatedAt = DateTime.Now;
                                            var response = _iSharpShopify.Update<InventoryLevel>(row, stores.StoreName);
                                            if (response != null)
                                            {
                                                try
                                                {
                                                    DBHelper.DoQuery(@$"MERGE INTO Query_75_GetStockStatus AS target USING (SELECT '{ItemCode}' AS ItemCode, '{Warehouse}' AS WhsCode) AS source ON target.ItemCode = source.ItemCode AND target.WhsCode = source.WhsCode WHEN MATCHED THEN UPDATE SET target.OnHand = '{Quantity}', target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, WhsCode, OnHand, Synced) VALUES ('{ItemCode}', '{Warehouse}', '{Quantity}', 'Y');", Databases.CompanyDb);

                                                }
                                                catch (Exception ex)
                                                {

                                                    ExceptionsController.Log(ex, @$"MERGE INTO Query_75_GetStockStatus AS target USING (SELECT '{ItemCode}' AS ItemCode, '{Warehouse}' AS WhsCode) AS source ON target.ItemCode = source.ItemCode AND target.WhsCode = source.WhsCode WHEN MATCHED THEN UPDATE SET target.OnHand = '{Quantity}', target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, WhsCode, OnHand, Synced) VALUES ('{ItemCode}', '{Warehouse}', '{Quantity}', 'Y');");
                                                }

                                            }
                                            Task.Delay(2000);

                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateInventoryLevel";
                                            log.UDateTime = DateTime.Now;
                                            log.URequest = JsonConvert.SerializeObject(row);
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }
                                    }
                                }

                            }


                        }
                        catch (Exception ex)
                        {
                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "UpdateInventoryLevel";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex, JsonConvert.SerializeObject(stores));
                            //throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExceptionsController.Log(ex);
                    //throw;
                }

            }
        }
        
       
        public void SAPToShopifyIterationStock()
        {
            try
            {
               
                var SAPDatabases = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().ToList();
                foreach(var r in SAPDatabases)
                {
                    try
                    {
                        ALTUpdateItemLevel(r.CompanyDb);

                    }
                    catch (Exception ex)
                    {
                        Administration.Endpoints.ExceptionsController.Log(ex);
                    }
                }
                


            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }
        
        void ISAPtoShopifyController.SAPToShopifyIterationStockFunc()
        {

            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(SAPToShopifyStockIterationStockTimerWorker);
            t.Interval = 10000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        }
        protected void SAPToShopifyStockIterationStockTimerWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Stop();

            try
            {

                SAPToShopifyIterationStock();
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


        #endregion

       



        #region ItemPrices

        [HttpPost, IgnoreAntiforgeryToken]
        public async void UpdateItemsPrices(string CompanyDB)
        {
            var CompanyDb = CompanyDB;

            var DatabaseRow = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().Where(x => x.CompanyDb == CompanyDb).FirstOrDefault();

            var StockObjectTable = DBHelper.GetTableFromQuery($@"Select CASE WHEN A0.U_Enza = 'Y' AND A0.U_Yatas = 'Y' THEN 'Both' WHEN A0.U_Enza = 'Y' AND (A0.U_Yatas='N' OR A0.U_Yatas IS NULL) THEN 'Enza' WHEN (A0.U_Enza = 'N' OR A0.U_Enza IS NULL) AND A0.U_Yatas = 'Y' THEN 'Yatas' ELSE 'None'End as Result_Column, A0.ItemCode From OITM A0 Where A0.U_ItemStat='Y' and (A0.U_Yatas='Y' OR A0.U_Enza='Y')", CompanyDB);

            var ItemObjs = _iB1ServiceLayer.FromTabletoObject<ItemsPriceObject>(StockObjectTable);
            //ExceptionsController.Log(new Exception("Price Obj"), JsonConvert.SerializeObject(ItemObjs));
            LogRow log = new LogRow();
            log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
            log.ShopifyPayload = "";
            foreach (var ItemObj in ItemObjs)
            {
                if (ItemObj.Result_Column == "Both")
                {
                    var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString());
                    foreach (var r in stores)
                    {
                        var StoreName = r.StoreName;
                        log.ShopifyId = StoreName;
                        try
                        {
                            //check if item Exists in Shopify
                            //Check if Item is header or not
                            var _Itemslst = _iSharpShopify.GetAllItems(StoreName);
                            var _Items = _Itemslst?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                            if (_Items != null)
                            {
                                var Items = _Items.FirstOrDefault();
                                //ExceptionsController.Log(new Exception("Item Obj"), JsonConvert.SerializeObject(Items));

                                var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                            join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                                var PriceList = "";
                                if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                {
                                    PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                }
                                if (Items != null)
                                {
                                    var Varients = new System.Collections.Generic.List<ProductVariant>();
                                    var _ChildItemRow = _iSharpShopify?.GetAllItems(StoreName)?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                                    //ExceptionsController.Log(new Exception("Item Price Query"), JsonConvert.SerializeObject(_ChildItemRow));

                                    if (_ChildItemRow != null)
                                    {
                                        var ChildItemRow = _ChildItemRow.FirstOrDefault();
                                        var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemObj.ItemCode, PriceList), CompanyDb);
                                        //ExceptionsController.Log(new Exception("Item Price Query"), String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemObj.ItemCode, PriceList));

                                        var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                        var varient = new ProductVariant()
                                        {
                                            Id = ChildItemRow.Id,
                                            ProductId = ChildItemRow.ProductId,

                                            Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                            CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                        };

                                        var response = _iSharpShopify.Update<ProductVariant>(varient, StoreName);
                                        await Task.Delay(2000);

                                        if (response != null)
                                        {
                                            log.ShopifyId = StoreName;
                                            log.URequest = JsonConvert.SerializeObject(varient);
                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateVarient";
                                            log.UDateTime = DateTime.Now;
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }
                                    }



                                }
                                else
                                {
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.ShopifyId = StoreName;

                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "UpdateProductOrVarient";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex);
                            //throw;
                        }
                    }
                }
                else if (ItemObj.Result_Column == "Enza")
                {
                    var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString() && x.SAPStoreName == "Enza");
                    var StoreName = stores.FirstOrDefault().StoreName;
                    log.ShopifyId = StoreName;
                    try
                    {
                        //check if item Exists in Shopify
                        //Check if Item is header or not
                        var _Itemslst = _iSharpShopify.GetAllItems(StoreName);
                        var _Items = _Itemslst?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                        if (_Items != null)
                        {
                            var Items = _Items.FirstOrDefault();
                            var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                            var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                        join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                        select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                            var PriceList = "";
                            if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                            {
                                PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                            }
                            if (Items != null)
                            {
                                var Varients = new System.Collections.Generic.List<ProductVariant>();
                                var _ChildItemRow = _iSharpShopify?.GetAllItems(StoreName)?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                                if (_ChildItemRow != null)
                                {
                                    var ChildItemRow = _ChildItemRow.FirstOrDefault();
                                    var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemObj.ItemCode, PriceList), CompanyDb);
                                    var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                    var varient = new ProductVariant()
                                    {
                                        Id = ChildItemRow.Id,
                                        ProductId = ChildItemRow.ProductId,

                                        Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                        CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                    };
                                    var response = _iSharpShopify.Update<ProductVariant>(varient, StoreName);

                                    if (response != null)
                                    {
                                        log.ShopifyId = StoreName;
                                        log.URequest = JsonConvert.SerializeObject(varient);
                                        log.UError = LogEnums.UError.False.ToString();
                                        log.UObjType = "UpdateVarient";
                                        log.UDateTime = DateTime.Now;
                                        log.UResponse = JsonConvert.SerializeObject(response);
                                        _ilog.Log(log);
                                    }
                                }


                            }
                            else
                            {
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        log.ShopifyId = StoreName;

                        log.UError = LogEnums.UError.True.ToString();
                        log.UObjType = "UpdateProductOrVarient";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = JsonConvert.SerializeObject(ex);
                        _ilog.Log(log);
                        ExceptionsController.Log(ex);
                        //throw;
                    }
                }
                else if (ItemObj.Result_Column == "Yatas")
                {
                    var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString() && x.SAPStoreName == "Yatas");
                    var StoreName = stores.FirstOrDefault().StoreName;
                    log.ShopifyId = StoreName;
                    try
                    {
                        //check if item Exists in Shopify
                        //Check if Item is header or not
                        var _Itemslst = _iSharpShopify.GetAllItems(StoreName);
                        var _Items = _Itemslst?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                        if (_Items != null)
                        {
                            var Items = _Items.FirstOrDefault();
                            var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();
                            var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                        join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                        select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                            var PriceList = "";
                            if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                            {
                                PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                            }
                            if (Items != null)
                            {
                                var Varients = new System.Collections.Generic.List<ProductVariant>();
                                var _ChildItemRow = _iSharpShopify?.GetAllItems(StoreName)?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                                if (_ChildItemRow != null)
                                {
                                    var ChildItemRow = _ChildItemRow.FirstOrDefault();
                                    var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemObj.ItemCode, PriceList), CompanyDb);
                                    var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                    var varient = new ProductVariant()
                                    {
                                        Id = ChildItemRow.Id,
                                        ProductId = ChildItemRow.ProductId,

                                        Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                        CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                    };
                                    var response = _iSharpShopify.Update<ProductVariant>(varient, StoreName);
                                    if (response != null)
                                    {
                                        log.ShopifyId = StoreName;
                                        log.URequest = JsonConvert.SerializeObject(varient);
                                        log.UError = LogEnums.UError.False.ToString();
                                        log.UObjType = "UpdateVarient";
                                        log.UDateTime = DateTime.Now;
                                        log.UResponse = JsonConvert.SerializeObject(response);
                                        _ilog.Log(log);
                                    }
                                }

                            }
                            else
                            {
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.ShopifyId = StoreName;

                        log.UError = LogEnums.UError.True.ToString();
                        log.UObjType = "UpdateProductOrVarient";
                        log.UDateTime = DateTime.Now;
                        log.UResponse = JsonConvert.SerializeObject(ex);
                        _ilog.Log(log);
                        ExceptionsController.Log(ex);
                        //throw;
                    }
                }
            }
        }
        public void ALTUpdateItemsPrices(string CompanyDB)
        {
            try
            {
                var CompanyDb = CompanyDB;

                var DatabaseRow = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().Where(x => x.CompanyDb == CompanyDb).FirstOrDefault();
                var _stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString());
                var CreateTablequery = DBHelper.DoNonQuery(DBHelper.GetQuery("Query_76_GetItemPrice_Create", DatabaseRow.CompanyDb), DatabaseRow.CompanyDb);

                var _shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == _stores.FirstOrDefault().StoreName).FirstOrDefault();
                //var _ItemslstAnon = _iSharpShopify.GetAllItemsNew(_shopifysettings.StoreName);

                var _Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == _shopifysettings.Id)
                             join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                             select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                var _PriceList = "";
                if (_Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                {
                    _PriceList = _Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                }
                var StockObjectTable = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_76_GetItemPrice", CompanyDb), _PriceList), CompanyDb);

                var ItemObjs = _iB1ServiceLayer.FromTabletoObject<ItemsPriceObject>(StockObjectTable);
                LogRow log = new LogRow();
                log.UDirection = LogEnums.UDirection.SAPToShopify.ToString();
                log.ShopifyPayload = "";
                foreach (var ItemObj in ItemObjs)
                {
                    if (ItemObj.Result_Column == "Both")
                    {
                        var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString());
                        var AllStoreSync = new System.Collections.Generic.List<AllStorePriceSyncObj>();
                        foreach (var r in stores)
                        {
                            var StoreName = r.StoreName;
                            log.ShopifyId = StoreName;
                            try
                            {
                                //check if item Exists in Shopify
                                //Check if Item is header or not
                                var _Itemslst = _iSharpShopify.GetAllItems(StoreName);
                                var _Items = _Itemslst?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                                if (_Items != null)
                                {
                                    var Items = _Items.FirstOrDefault();

                                    var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                    var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                                join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                                select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                                    var PriceList = "";
                                    if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                    {
                                        PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                    }
                                    if (Items != null)
                                    {
                                        var Varients = new System.Collections.Generic.List<ProductVariant>();
                                        var _ChildItemRow = _iSharpShopify?.GetAllItems(StoreName)?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);

                                        if (_ChildItemRow != null)
                                        {
                                            var ChildItemRow = _ChildItemRow.FirstOrDefault();
                                            var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_76_GetItemPriceWithItemCode", CompanyDb), ItemObj.ItemCode, PriceList), CompanyDb);

                                            var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                            var varient = new ProductVariant()
                                            {
                                                Id = ChildItemRow.Id,
                                                ProductId = ChildItemRow.ProductId,

                                                Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                                CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                            };

                                            var response = _iSharpShopify.Update<ProductVariant>(varient, StoreName);
                                            Task.Delay(2000);

                                            if (response != null)
                                            {
                                                AllStoreSync.Add(new AllStorePriceSyncObj() { StoreName = StoreName, Synced = "Y", Price = Pricerow.FirstOrDefault().Price });

                                                log.ShopifyId = StoreName;
                                                log.URequest = JsonConvert.SerializeObject(varient);
                                                log.UError = LogEnums.UError.False.ToString();
                                                log.UObjType = "UpdateVarient";
                                                log.UDateTime = DateTime.Now;
                                                log.UResponse = JsonConvert.SerializeObject(response);
                                                _ilog.Log(log);
                                            }
                                        }



                                    }
                                    else
                                    {
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                log.ShopifyId = StoreName;

                                log.UError = LogEnums.UError.True.ToString();
                                log.UObjType = "UpdateProductOrVarient";
                                log.UDateTime = DateTime.Now;
                                log.UResponse = JsonConvert.SerializeObject(ex);
                                _ilog.Log(log);
                                ExceptionsController.Log(ex);
                                //throw;
                            }
                        }
                        if (AllStoreSync.Count() == stores.Count())
                        {
                            var InsertEntry = DBHelper.DoNonQuery(@$"MERGE INTO Query_76_GetItemPrice AS target USING (SELECT '{ItemObj.ItemCode}' AS ItemCode, '{AllStoreSync.FirstOrDefault().Price}' AS Price) AS source ON (target.ItemCode = source.ItemCode) WHEN MATCHED THEN UPDATE SET target.Price = source.Price, target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, Price, Synced) VALUES (source.ItemCode, source.Price, 'Y');", CompanyDb);

                        }
                    }
                    else if (ItemObj.Result_Column == "Enza")
                    {
                        var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString() && x.SAPStoreName == "Enza");
                        var StoreName = stores.FirstOrDefault().StoreName;
                        log.ShopifyId = StoreName;
                        try
                        {
                            //check if item Exists in Shopify
                            //Check if Item is header or not
                            var _Itemslst = _iSharpShopify.GetAllItems(StoreName);
                            var _Items = _Itemslst?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                            if (_Items != null)
                            {
                                var Items = _Items.FirstOrDefault();
                                var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();

                                var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                            join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                                var PriceList = "";
                                if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                {
                                    PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                }
                                if (Items != null)
                                {
                                    var Varients = new System.Collections.Generic.List<ProductVariant>();
                                    var _ChildItemRow = _iSharpShopify?.GetAllItems(StoreName)?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                                    if (_ChildItemRow != null)
                                    {
                                        var ChildItemRow = _ChildItemRow.FirstOrDefault();
                                        var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemObj.ItemCode, PriceList), CompanyDb);
                                        var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                        var varient = new ProductVariant()
                                        {
                                            Id = ChildItemRow.Id,
                                            ProductId = ChildItemRow.ProductId,

                                            Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                            CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                        };
                                        var response = _iSharpShopify.Update<ProductVariant>(varient, StoreName);

                                        if (response != null)
                                        {
                                            var InsertEntry = DBHelper.DoNonQuery(@$"MERGE INTO Query_76_GetItemPrice AS target USING (SELECT '{ItemObj.ItemCode}' AS ItemCode, '{Pricerow.FirstOrDefault().Price}' AS Price) AS source ON (target.ItemCode = source.ItemCode) WHEN MATCHED THEN UPDATE SET target.Price = source.Price, target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, Price, Synced) VALUES (source.ItemCode, source.Price, 'Y');", CompanyDb);

                                            log.ShopifyId = StoreName;
                                            log.URequest = JsonConvert.SerializeObject(varient);
                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateVarient";
                                            log.UDateTime = DateTime.Now;
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }
                                    }


                                }
                                else
                                {
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            log.ShopifyId = StoreName;

                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "UpdateProductOrVarient";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex);
                            //throw;
                        }
                    }
                    else if (ItemObj.Result_Column == "Yatas")
                    {
                        var stores = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().Where(x => x.SapDatabase == DatabaseRow.Id.ToString() && x.SAPStoreName == "Yatas");
                        var StoreName = stores.FirstOrDefault().StoreName;
                        log.ShopifyId = StoreName;
                        try
                        {
                            //check if item Exists in Shopify
                            //Check if Item is header or not
                            var _Itemslst = _iSharpShopify.GetAllItems(StoreName);
                            var _Items = _Itemslst?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                            //ExceptionsController.Log(new Exception("Items"),JsonConvert.SerializeObject(_Items)+Environment.NewLine+ _Itemslst.Count());
                            if (_Items != null)
                            {
                                var Items = _Items.FirstOrDefault();
                                var shopifysettings = _dbConnection.List<ShopifySettingsRow>().Where(x => x.StoreName == StoreName).FirstOrDefault();
                                var Lines = from A0 in _dbConnection.List<ShopifySettingsDetailRow>().Where(x => x.ShopifySettingsId == shopifysettings.Id)
                                            join A1 in _dbConnection.List<ShopifySubSettingsRow>() on A0.ShopifySubSettingsId equals A1.Id
                                            select new ShopifySettingsDetailRow { Id = A1.Id, ShopifySubSettingsName = A1.Name, ShopifySubSettingsSapValue = A0.ShopifySubSettingsSapValue };
                                var PriceList = "";
                                if (Lines.Any(x => x.ShopifySubSettingsName == "PriceList"))
                                {
                                    PriceList = Lines.Where(x => x.ShopifySubSettingsName == "PriceList").FirstOrDefault().ShopifySubSettingsSapValue;
                                }
                                if (Items != null)
                                {
                                    var Varients = new System.Collections.Generic.List<ProductVariant>();
                                    var _ChildItemRow = _iSharpShopify?.GetAllItems(StoreName)?.SelectMany(x => x?.Variants)?.Where(x => x?.SKU == ItemObj?.ItemCode);
                                    if (_ChildItemRow != null)
                                    {
                                        var ChildItemRow = _ChildItemRow.FirstOrDefault();
                                        var PriceDT = DBHelper.GetTableFromQuery(String.Format(DBHelper.GetQuery("Query_73_GetItemPrice", CompanyDb), ItemObj.ItemCode, PriceList), CompanyDb);
                                        var Pricerow = _iB1ServiceLayer.FromTabletoObject<PriceObject>(PriceDT);
                                        var varient = new ProductVariant()
                                        {
                                            Id = ChildItemRow.Id,
                                            ProductId = ChildItemRow.ProductId,

                                            Price = Convert.ToDecimal(Pricerow.FirstOrDefault().Price),
                                            CompareAtPrice = Convert.ToDecimal(Pricerow.FirstOrDefault().CompareAtPrice),
                                        };
                                        var response = _iSharpShopify.Update<ProductVariant>(varient, StoreName);

                                        if (response != null)
                                        {
                                            var InsertEntry = DBHelper.DoNonQuery(@$"MERGE INTO Query_76_GetItemPrice AS target USING (SELECT '{ItemObj.ItemCode}' AS ItemCode, '{Pricerow.FirstOrDefault().Price}' AS Price) AS source ON (target.ItemCode = source.ItemCode) WHEN MATCHED THEN UPDATE SET target.Price = source.Price, target.Synced = 'Y' WHEN NOT MATCHED THEN INSERT (ItemCode, Price, Synced) VALUES (source.ItemCode, source.Price, 'Y');", CompanyDb);

                                            log.ShopifyId = StoreName;
                                            log.URequest = JsonConvert.SerializeObject(varient);
                                            log.UError = LogEnums.UError.False.ToString();
                                            log.UObjType = "UpdateVarient";
                                            log.UDateTime = DateTime.Now;
                                            log.UResponse = JsonConvert.SerializeObject(response);
                                            _ilog.Log(log);
                                        }
                                    }

                                }
                                else
                                {
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            log.ShopifyId = StoreName;

                            log.UError = LogEnums.UError.True.ToString();
                            log.UObjType = "UpdateProductOrVarient";
                            log.UDateTime = DateTime.Now;
                            log.UResponse = JsonConvert.SerializeObject(ex);
                            _ilog.Log(log);
                            ExceptionsController.Log(ex);
                            //throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
                //throw;
            }
        }

        void ISAPtoShopifyController.SAPToShopifyIterationItemPricesFunc()
        {

            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(SAPToShopifyIterationItemPricesTimerWorker);
            t.Interval = 10000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        }


        public void SAPToShopifyIterationItemPrices()
        {
            try
            {
                var SAPDatabases = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().ToList();
                foreach (var r in SAPDatabases)
                {
                    ALTUpdateItemsPrices(r.CompanyDb);
                }



            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }


        protected void SAPToShopifyIterationItemPricesTimerWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Stop();

            try
            {

                SAPToShopifyIterationItemPrices();
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

        #endregion


        #region ItemUpdate
        public void SAPToShopifyIterationItem()
        {
            try
            {
                var SAPDatabases = DBHelper.GetSerenDBConnection().List<SapDatabasesRow>().ToList();
                foreach (var r in SAPDatabases)
                {

                    var lastSync = DBHelper.GetSerenDBConnection().List<SapToShopifySyncLogRow>().ToList().LastOrDefault() ?? null;
                    DataTable getChanges = null;
                    if (lastSync != null)
                    {
                        getChanges = DBHelper.GetTableFromQuery(String.Format("exec [dbo].[GET_CHANGES] {0},4", lastSync.DocEntry), r.CompanyDb);

                    }
                    else
                    {
                        getChanges = DBHelper.GetTableFromQuery(String.Format("exec [dbo].[GET_CHANGES] {0},4", 0), r.CompanyDb);


                    }
                    var Changes = _iB1ServiceLayer.FromTabletoObject<GetChangesObject>(getChanges);
                    if (Changes.Count() != 0)
                    {

                        foreach (var s in Changes)
                        {
                            if (s.U_TrType == "A")
                            {
                                try
                                {
                                    CreateItem(s, r.CompanyDb);

                                }
                                catch (Exception ex)
                                {
                                    Administration.Endpoints.ExceptionsController.Log(ex);
                                    //throw;
                                }
                            }
                            else if (s.U_TrType == "U")
                            {
                                try
                                {
                                    UpdateItem(s, r.CompanyDb);

                                }
                                catch (Exception ex)
                                {
                                    Administration.Endpoints.ExceptionsController.Log(ex);
                                }
                            }
                            else if (s.U_TrType == "D")
                            {
                                try
                                {
                                    UpdateItem(s, r.CompanyDb);

                                }
                                catch (Exception ex)
                                {
                                    Administration.Endpoints.ExceptionsController.Log(ex);
                                }
                            }
                        }

                    }


                    // UpdateItemsPrices(r.CompanyDb);


                }



            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }


        void ISAPtoShopifyController.SAPToShopifyIterationItemFunc()
        {

            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(SAPToShopifyIterationItemTimerWorker);
            t.Interval = 10000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();
        }

        protected void SAPToShopifyIterationItemTimerWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Stop();

            try
            {

                SAPToShopifyIterationItem();
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


        #endregion



        #region GetItems
        public void GetItems(string StoreName)
        {
            _iSharpShopify.ALTGetAllItems(StoreName);
        }
        public void SAPToShopifyGetItemsFunc()
        {
            System.Timers.Timer t = new System.Timers.Timer();
            t.Elapsed += new System.Timers.ElapsedEventHandler(SAPToShopifyIterationGetItemsTimerWorker);
            t.Interval = 300000;
            t.Enabled = true;
            t.AutoReset = true;
            t.Start();

        }
        public void SAPToShopifyGetItemsFunc2()
        {
            SAPToShopifyIterationGetItems();

        }
        public void SAPToShopifyIterationGetItems()
        {
            try
            {
                var settings = DBHelper.GetSerenDBConnection().List<ShopifySettingsRow>().ToList();
                foreach (var r in settings)
                {
                    GetItems(r.StoreName);
                }



            }
            catch (Exception ex)
            {
                ex.Log();
            }
        }
        protected void SAPToShopifyIterationGetItemsTimerWorker(object sender, System.Timers.ElapsedEventArgs e)
        {
            ((System.Timers.Timer)sender).Stop();

            try
            {

                SAPToShopifyIterationGetItems();
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
        #endregion

        private void CreateLog(GetChangesObject _object, string StoreName)
        {
            Serenity.Data.SqlInsert insert = new SqlInsert("SAPToShopifySyncLog");
            insert.SetTo("DocEntry", @$"'{_object.DocEntry}'");
            insert.SetTo("SyncStatus", @$"'Y'");
            insert.SetTo("TargetStoreId", @$"'{StoreName}'");
            insert.SetTo("SourceObjType", @$"'{_object.U_ObjType}'");
            insert.SetTo("SyncTime", @$"'{DateTime.Now}'");
            insert.Execute(_dbConnection);
        }

    }
    public class AllStoreLevelSyncObj
    {
        public string StoreName { get; set; }
        public string Quantity { get; set; }
        public string Synced { get; set; }
    }

    public class AllStorePriceSyncObj
    {
        public string StoreName { get; set; }
        public string Price { get; set; }
        public string Synced { get; set; }
    }
    public class SaleOrderObject
    {
        public String Type { get; set; }
        public Orders.DocumentRow Row { get; set; }
    }
    public class DownPaymentObject
    {
        public String Type { get; set; }
        public DownPayment.DocumentRow Row { get; set; }
    }

    public class GetChangesObject
    {
        public String DocEntry { get; set; }
        public String U_ObjType { get; set; }
        public String U_Key { get; set; }
        public String U_KeyName { get; set; }
        public String U_HTBL { get; set; }
        public DateTime U_DateTime { get; set; }
        public String U_TrType { get; set; }

    }
    public class PriceObject
    {
        public String Price { get; set; }
        public String CompareAtPrice { get; set; }
    }
    public class ItemsPriceObject
    {
        public String ItemCode { get; set; }
        public String Price { get; set; }
        public String CompareAtPrice { get; set; }
        public String Result_Column { get; set; }
    }
    public class StockObject
    {
        public String SAPStoreName { get; set; }
        public String ItemCode { get; set; }
        public String Warehouse { get; set; }
        public String OnHandQuantity { get; set; }

        
    }
}
