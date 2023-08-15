using HelpersWebSL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks; 

namespace HelpersWebSL
{
    public class serenityHelper
    {
        static HttpClient httpclient;
        public serenityHelper(string baseurl="")
        {
            if (httpclient == null)
                httpclient = new HttpClient();
            //if base url is not empity 
            if (!string.IsNullOrEmpty(baseurl))
                serenityHelper. baseurl = baseurl;
           
        }
        //destructor
        ~serenityHelper()
        {

            //call lougout from serenity
            var logout = httpclient.GetAsync(baseurl + "/Account/Signout").Result;
            httpclient.Dispose();
        }
        //public static string baseurl = "http://localhost:5005" ;
        //public static string LOGIN = "http://localhost:5005" + "/Account/Login";
        public static string baseurl = "http://192.168.10.185:9090";
        public static string LOGIN = baseurl+ "/Account/Login";
        public bool _Login(string Username, string Password, string CompanyDB,string dbname )
        {
            bool result = false;
            try
            {

                try
                {


                    var json = JsonConvert.SerializeObject(new { Username = Username, Password = Password, CompanyDatabase = CompanyDB });
                    var datum = new StringContent(JsonConvert.SerializeObject(new { Username = Username, Password = Password, CompanyDatabase = CompanyDB }), Encoding.UTF8, "application/json");

                    httpclient = new System.Net.Http.HttpClient();
                    var Request = LOGIN;

                    var response1 = httpclient.PostAsync(Request, datum).Result;

                    var response = response1.Content.ReadAsStringAsync().Result;
                    if (response == "{}"|| response=="")
                    {
                        result = true;
                        datum = new StringContent(JsonConvert.SerializeObject(new { Username = Username, Password = Password, CompanyDatabase = dbname }), Encoding.UTF8, "application/json");

                        var servicelayerurl =    httpclient.GetAsync(baseurl + "/Services/Default/SapDatabases/ServiceLayerUrl");
                        ServiceLayerHelper.serviceLayerURL = servicelayerurl.Result.Content.ReadAsStringAsync().Result;
                    }
                    dynamic d = JsonConvert.DeserializeObject(response); 

                }
                catch (Exception ex)
                {
                    //try to login from local db



                }

            }
            catch (Exception ex)
            {
                //todo: log in nlog
                
            }
            return result;

        }

        public List<BusinessPartners> GetCustomers()
        {
            var url = baseurl + "/Services/Default/BusinessPartner/GetAll";
            var response = httpclient.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(result);
            //{"Error":{"Code":"AccessDenied","Message":"Authorization has been denied for this request!"}}
            if (!String.IsNullOrEmpty( obj["Error"]?.ToString()))
            {
                throw new Exception(obj["Error"]?.ToString()+ " - "+obj["Message"]?.ToString());
            }
                var customers = JsonConvert.DeserializeObject<List<BusinessPartners>>(obj["Entities"]?.ToString()??"");
            return customers ?? new List<BusinessPartners>();
        }
        public List<Document> GetARInvoices()
        {
            var url = baseurl + "/Services/ARInvoice/Document/GetAll";
            var response = httpclient.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(result);
            var customers = JsonConvert.DeserializeObject<List<Document>>(obj["Entities"].ToString());
            return customers;
        }
        //GetIncomingPayments
        public List<IncomingPayments> GetIncomingPayments()
        {
            var url = baseurl + "/Services/IncomingPayment/Payment/GetAll";  
            var response = httpclient.GetAsync(url).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(result);
            var customers = JsonConvert.DeserializeObject<List<IncomingPayments>>(obj["Entities"].ToString());
            return customers;
        }

        internal bool CreateIncomingPayment(IncomingPaymentPosting incomingPayment)
        {
            var url= baseurl + "/Services/IncomingPayment/Payment/PostPayment";
            var datum = new StringContent(JsonConvert.SerializeObject(incomingPayment), Encoding.UTF8, "application/json");
            var response = httpclient.PostAsync(url, datum).Result;
            var result = response.Content.ReadAsStringAsync().Result; 
            return response.IsSuccessStatusCode;
        }
    }
}
