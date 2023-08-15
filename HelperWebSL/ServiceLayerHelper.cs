using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelperWebSL
{
    internal class ServiceLayerHelper
    {
        static HttpClient client;
        internal static    string serviceLayerURL = "";
        
        public ServiceLayerHelper()
        {
            client = new HttpClient();
        }
        public bool login()
        {
            return true;
        }


    }
}
