using Newtonsoft.Json;
using SAPWebPortal.Default;
using SAPWebPortal.Default.Endpoints;
using Serenity;
using ShopifySharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SAPWebPortal.Web.Helpers
{
    public class ShopifyHelper
    {
        public ShopifyHelper() 
        {
        
        }

        public async void GetShopifyProducts(ShopifySettingsRow shopifySettingsRow)
        {
            string apiKey = shopifySettingsRow.ApiKey;
            string password = shopifySettingsRow.Token;
            string shopDomain = shopifySettingsRow.StoreName;

            // Create an HttpClient instance
            HttpClient client = new HttpClient();

            // Set the base address for the Shopify API
            client.BaseAddress = new Uri($"https://{shopDomain}.myshopify.com");

            // Set the authorization header
            string authorizationHeader = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{apiKey}:{password}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);

            try
            {
                // Make an API request
                HttpResponseMessage response = await client.GetAsync(@$"/admin/api/{shopifySettingsRow.ApiVersion}/products.json");

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Request failed with status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Dispose the HttpClient instance to release resources
                client.Dispose();
            }
        }
        public async void CreateShopifyItem(ShopifySettingsRow shopifySettingsRow)
        {
            string apiKey = shopifySettingsRow.ApiKey;
            string password = shopifySettingsRow.Token;
            string shopDomain = shopifySettingsRow.StoreName;

            // Create the HttpClient and set the API credentials
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:{password}"))
            );

            // Create the item payload with variants
            var itemPayload = new
            {
                product = new
                {
                    title = "Test Funny Item",
                    body_html = "<p>This is a new funny item.</p>",
                    vendor = "Saptest01",
                    product_type = "Your Product Type",
                    variants = new List<object>
                    {
                        new
                        {
                            option1 = "Size",
                            price = "10.00",
                            sku = "ITEM-SIZE",
                            inventory_quantity = 10
                        },
                        new
                        {
                            option1 = "Color",
                            price = "15.00",
                            sku = "ITEM-COLOR",
                            inventory_quantity = 5
                        }
                }
                }
            };

            // Serialize the payload to JSON
            string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(itemPayload);

            // Send the POST request to create the item
            string url = $"https://{shopifySettingsRow.StoreName}.myshopify.com/admin/api/{shopifySettingsRow.ApiVersion}/products.json";
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Check the response
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Item created successfully!");
                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine("Failed to create item. Status code: " + response.StatusCode);
            }
        }
        public async void UpdateShopifyItem(ShopifySettingsRow shopifySettingsRow, string productId)
        {
            string apiKey = shopifySettingsRow.ApiKey;
            string password = shopifySettingsRow.Token;
            string shopDomain = shopifySettingsRow.StoreName;

            // Create the HttpClient and set the API credentials
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:{password}"))
            );

            // Create the item payload with updated information
            var itemPayload = new
            {
                product = new
                {
                    id = productId,
                    title = "Updated Funny Item",
                    body_html = "<p>This Funny item has been updated.</p>",
                    vendor = "FunnyVendor",
                    product_type = "Updated Product Type"
                }
            };

            // Serialize the payload to JSON
            string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(itemPayload);

            // Send the PUT request to update the item
            string url = $"https://{shopifySettingsRow.StoreName}.myshopify.com/admin/api/{shopifySettingsRow.ApiVersion}/products/{productId}.json";
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(url, content);

            // Check the response
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Item updated successfully!");
                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine("Failed to update item. Status code: " + response.StatusCode);
            }
        }

        public async void RegisterWebhook(ShopifySettingsRow shopifySettingsRow,string webookEndpoint)
        {
            string shopifyStore = shopifySettingsRow.StoreName;
            string apiKey = shopifySettingsRow.ApiKey;
            string password = shopifySettingsRow.Token;
            string webhookEndpoint = webookEndpoint;

            // Create the HttpClient and set the API credentials
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:{password}"))
            );

            // Create the webhook payload
            var webhookPayload = new
            {
                webhook = new
                {
                    topic = "orders/updated",
                    address = "https://orderreturn.free.beeceptor.com",
                    format = "json"
                }
            };

            // Serialize the payload to JSON
            string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(webhookPayload);

            // Send the POST request to register the webhook
            string url = $"https://{shopifyStore}.myshopify.com/admin/api/{shopifySettingsRow.ApiVersion}/webhooks.json";
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            // Check the response
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Webhook registered successfully!");
                Console.WriteLine(responseContent);
            }
            else
            {
                Console.WriteLine("Failed to register webhook. Status code: " + response.StatusCode);
            }
        }
    }
    public class CustomerIntegration
    {
        public void CreateCustomer(string json)
        {
            
            BusinessPartnerController controller = new BusinessPartnerController();
            

        }
        public void UpdateCustomer(string json)
        {
            var obj = JsonConvert.DeserializeObject<Customer>(json);

        }

    }
}
