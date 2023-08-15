using B1SLayer;
using Newtonsoft.Json;
using NUglify.Helpers;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Numeric;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using SAPbobsCOM;
using SAPbouiCOM;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Default;
using Serenity.Data;
using ShopifySharp;
using ShopifySharp.Entities;
using ShopifySharp.Filters;
using ShopifySharp.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MVC.Views;
using Product = ShopifySharp.Product;

namespace SAPWebPortal.Web.DependencyInjections
{
    public interface ISharpShopify
    {
        public System.Collections.Generic.List<Product> GetAllItems(string storeName);
        public Order GetOrder(string storeName, string OrderId);
        public void ALTGetAllItems(string storeName);
        public System.Collections.Generic.List<Product> GetAllItemsNew(string storeName);
        public T Update<T>(T product, string storeName);
        public T Create<T>(T product, string storeName);
        public Webhook RegisterWebhook(ShopifyWebkookSettingsRow row, string storeName);
        public Webhook UpdateWebhook(long WebhookId, ShopifyWebkookSettingsRow row, string storeName);
        public void DeleteWebhook(long webhookid, string storeName);
    }
    public class SharpShopify : ISharpShopify
    {
        private ISqlConnections sqlConnections = null;
        private ProductService _Service = null;
        private OrderService _OService = null;
        private InventoryLevelService _ILService = null;
        private ProductVariantService _PVService = null;
        private InventoryItemService _IIService = null;
        private WebhookService _WBService = null;
        
        public SharpShopify(ISqlConnections sqlConnections)
        {

            this.sqlConnections = sqlConnections;
           
        }
        private void CreateService(string storeName)
        {
            try
            {
                if (!String.IsNullOrEmpty(storeName))
                {
                    using (var con = this.sqlConnections.NewFor<SapDatabasesRow>())
                    {
                        con.Open();
                        var shopifycreds = con.List<ShopifySettingsRow>().First(x => x.StoreName == storeName);
                        var creds = con.List<SapDatabasesRow>().First(x => x.Id == Convert.ToInt32(shopifycreds.SapDatabase));
                        this._Service = new ProductService(shopifycreds.ApiBaseURL, shopifycreds.Token);
                        this._OService = new OrderService(shopifycreds.ApiBaseURL, shopifycreds.Token);
                        this._ILService = new InventoryLevelService(shopifycreds.ApiBaseURL, shopifycreds.Token);
                        this._WBService = new WebhookService(shopifycreds.ApiBaseURL, shopifycreds.Token);
                        this._PVService = new ProductVariantService(shopifycreds.ApiBaseURL, shopifycreds.Token);
                        this._IIService = new InventoryItemService(shopifycreds.ApiBaseURL, shopifycreds.Token);


                    }
                }
                

            }
            catch (Exception ex)
            {
                ExceptionsController.Log(ex);
                //throw;
            }
        }
        private void DestroyService()
        {
            _Service = null;
            _ILService = null;
            _PVService = null;
            _WBService = null;
            _IIService = null;
            _OService = null;
        } 
        public T Create<T>(T item, string storeName)
        {
            try
            {
                if (_Service == null || _ILService == null)
                {
                    CreateService(storeName);
                }

                if (typeof(Product) == item.GetType())
                {
                    var _product = item as Product;


                    return ConvertModelToT<Product, T>(_Service.CreateAsync(_product).GetAwaiter().GetResult());



                }
                else if (typeof(InventoryLevel) == item.GetType())
                {
                    var _inventoryLevel = item as InventoryLevel;

                    return ConvertModelToT<InventoryLevel, T>(_ILService.SetAsync(_inventoryLevel).GetAwaiter().GetResult());


                }
                else
                {
                    return default(T);
                }
            }
            catch(Exception ex)
            {
                return default(T);
            }
            finally
            {
                DestroyService();
            }

        }
        public class _Products
        {
            public System.Collections.Generic.List<Product> products { get; set; }
        }
        /*   public System.Collections.Generic.List<Product> GetAllItems(string storeName)
           {       
               CreateService(storeName);
               var Count= _Service.CountAsync().GetAwaiter().GetResult();
               Task.Delay(2000);
               var allProducts = new System.Collections.Generic.List<Product>();
               var productFilter = new ProductListFilter { Limit = 250};
               var page =  _Service.ListAsync(new ProductListFilter { Limit = 250}).GetAwaiter().GetResult();
               Task.Delay(2000);

               while (true)
               {
                   var products = _Service.ListAsync(page.GetNextPageFilter()).GetAwaiter().GetResult().Items.ToList();
                   Task.Delay(2000);

                   allProducts.AddRange(products);
                   if (!page.HasNextPage)
                       break;

               }
               ExceptionsController.Log(new Exception("ItemsList"),JsonConvert.SerializeObject(allProducts));
               return allProducts;

           }*/
        public class ItemsByStore
        {
            public string StoreName { get; set; }
            public System.Collections.Generic.List<Product> Items { get; set; }
        }
        public static System.Collections.Generic.List<ItemsByStore> itemsByStores = new System.Collections.Generic.List<ItemsByStore>();
        public System.Collections.Generic.List<Product> GetAllItems(string storeName)
        {

            var count= itemsByStores.Where(x => x.StoreName == storeName).Count();
            if (count > 0)
            {
                return itemsByStores.Where(x => x.StoreName == storeName).FirstOrDefault().Items;
            }
            else
            {
                CreateService(storeName);
                var Count = _Service.CountAsync().GetAwaiter().GetResult();
                Task.Delay(2000);
                var allProducts = new System.Collections.Generic.List<Product>();
                var productFilter = new ProductListFilter { Limit = 250, Status = "active" };
                var products = _Service.ListAsync(productFilter).GetAwaiter().GetResult().Items.ToList();
                Task.Delay(2000);

                allProducts.AddRange(products);
                var _count = itemsByStores.Where(x => x.StoreName == storeName).Count();
                if (_count > 0)
                {
                    var index = itemsByStores.FindIndex(x => x.StoreName == storeName);
                    if (index != -1)
                    {
                        itemsByStores.RemoveAt(index);
                    }
                }
                itemsByStores.Add(new ItemsByStore() { StoreName = storeName, Items = allProducts });
                return allProducts;

            }

        }
        public void ALTGetAllItems(string storeName)
        {
            /*CreateService(storeName);
            var Count = _Service.CountAsync().GetAwaiter().GetResult();
            Task.Delay(2000);
            var allProducts = new System.Collections.Generic.List<Product>();
            var productFilter = new ProductListFilter { Limit = 250, Status= "active" };
            var products = _Service.ListAsync(productFilter).GetAwaiter().GetResult().Items.ToList();
            Task.Delay(2000);

            allProducts.AddRange(products);
            var count =itemsByStores.Where(x => x.StoreName == storeName).Count();
            if (count > 0)
            {
                var index=itemsByStores.FindIndex(x => x.StoreName == storeName);
                if (index != -1)
                {
                    itemsByStores.RemoveAt(index);
                }
            }*/
            CreateService(storeName);
            var Count = _Service.CountAsync().GetAwaiter().GetResult();
            Task.Delay(2000);
            var allProducts = new System.Collections.Generic.List<Product>();
            var productFilter = new ProductListFilter { Limit = 250 };
            var page = _Service.ListAsync(productFilter).GetAwaiter().GetResult();
            while (true)
            {
                allProducts.AddRange(page.Items);
                Task.Delay(2000);
                if (!page.HasNextPage)
                {
                    break;
                }

                page = _Service.ListAsync(page.GetNextPageFilter()).GetAwaiter().GetResult();

            }



            itemsByStores.Add(new ItemsByStore() { StoreName=storeName,Items=allProducts});
            //ExceptionsController.Log(new Exception("Total Count"+ itemsByStores.Count()));




        }
        public System.Collections.Generic.List<Product> GetAllItemsNew(string storeName)
        {
            CreateService(storeName);
            var Count = _Service.CountAsync().GetAwaiter().GetResult();
            Task.Delay(2000);
            var allProducts = new System.Collections.Generic.List<Product>();
            var productFilter = new ProductListFilter { Limit = 250 };
            var page = _Service.ListAsync(productFilter).GetAwaiter().GetResult();
            ExceptionsController.Log(new Exception("Page"), JsonConvert.SerializeObject(page));
            while (true)
            {
                allProducts.AddRange(page.Items);
                Task.Delay(2000);
                if (!page.HasNextPage)
                {
                    break;
                }

                page = _Service.ListAsync(page.GetNextPageFilter()).GetAwaiter().GetResult();

            }



            return allProducts;

        }
        public T Update<T>(T item, string storeName)
        {
            try
            {
                if (_Service == null || _ILService == null || _PVService == null)
                {
                    CreateService(storeName);
                }

                if (typeof(Product) == item.GetType())
                {
                    var _product = item as Product;
                    var response = ConvertModelToT<Product, T>(_Service.UpdateAsync(Convert.ToInt64(_product.Id), _product).GetAwaiter().GetResult());
                    return response;


                }
                else if (typeof(InventoryLevel) == item.GetType())
                {
                    var _product = item as InventoryLevel;
                    var response = ConvertModelToT<InventoryLevel, T>(_ILService.SetAsync(_product).GetAwaiter().GetResult());
                    return response;


                }
                else if (typeof(ProductVariant) == item.GetType())
                {
                    var _varient = item as ProductVariant;
                    var response = ConvertModelToT<ProductVariant, T>(_PVService.UpdateAsync(Convert.ToInt64(_varient.Id), _varient).GetAwaiter().GetResult());

                    return response;


                }
                else if (typeof(InventoryItem) == item.GetType())
                {
                    var _varient = item as InventoryItem;
                    var response = ConvertModelToT<InventoryItem, T>(_IIService.UpdateAsync(Convert.ToInt64(_varient.Id), _varient).GetAwaiter().GetResult());

                    return response;


                }
                else
                {
                    return default(T);
                }
            }
            catch(Exception ex)
            {
                return default(T);
            }
            finally
            {
                DestroyService();
            }

        }

        public Webhook RegisterWebhook(ShopifyWebkookSettingsRow row,string storeName)
        {
            try
            {
                if (_WBService == null)
                {
                    CreateService(storeName);
                }

                if (row != null)
                {
                    Webhook webhook = new Webhook()
                    {
                        Topic = row.ShopifyWebhookTopic,
                        Address = row.WebhookUrl,
                        Format = "json"
                    };
                    var response = _WBService.CreateAsync(webhook).GetAwaiter().GetResult();
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                DestroyService();
            }
        }
        public Webhook UpdateWebhook(long WebhookId, ShopifyWebkookSettingsRow row,string storeName)
        {
            try
            {
                if (_WBService == null)
                {
                    CreateService(storeName);
                }

                if (row != null)
                {
                    Webhook webhook = new Webhook()
                    {
                        Topic = row.ShopifyWebhookTopic,
                        Address = row.WebhookUrl,
                        Format = "json"
                    };
                    var response = _WBService.UpdateAsync(WebhookId, webhook).GetAwaiter().GetResult();
                    _WBService = null;

                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                DestroyService();
            }
        }
        public void DeleteWebhook(long webhookid,string storeName)
        {
            try
            {
                if (_WBService == null)
                {
                    CreateService(storeName);
                }

                if (webhookid != 0)
                {
                    _WBService.DeleteAsync(webhookid).GetAwaiter().GetResult();
                }
            } 
            catch(Exception ex)
            {
                
            }
            finally
            {
                DestroyService();
            }
            
        }
        private T ConvertModelToT<Model, T>(Model model)
        {
            // Perform necessary conversion steps based on the requirements of type T

            T convertedModel;

            // Add your conversion logic here

            // Example: Casting the model to type T
            convertedModel = (T)Convert.ChangeType(model, typeof(T));

            return convertedModel;
        }

        public Order GetOrder(string storeName,string OrderId)
        {
            CreateService(storeName);
            var order = new Order();
            order = _OService.GetAsync(Convert.ToInt64(OrderId)).GetAwaiter().GetResult();
            return order;
        }

        public class ShopifyItemsStoreWise
        {
            public string StoreName { get; set; }
            public System.Collections.Generic.List<Product> Products { get; set; }
        }
    }
}
