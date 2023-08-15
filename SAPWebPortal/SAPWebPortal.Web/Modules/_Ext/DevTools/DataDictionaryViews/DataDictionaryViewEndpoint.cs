using SAPWebPortal.Web.Modules.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Web.Helpers;
using SAPWebPortal.Web.Modules.Common.Helpers;
using Serenity;
using Serenity.Data;
using Serenity.Reporting;
using Serenity.Services;
using Serenity.Web;
using System;
using System.Data;
using System.Globalization;
using AspNetCoreHero.ToastNotification.Abstractions;
using NToastNotify;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SAPWebPortal.Drafts.Endpoints
{
    [Route("Services/DevTools/DataDictionaryView/[action]")]
    public class DataDictionaryViewController : ServiceEndpoint
    {
        // private readonly INotyfService _Notify;
        private readonly IToastNotification _ToastNotification;
        public DataDictionaryViewController(IToastNotification ToastNotification, INotyfService Notify)
        {
            _ToastNotification = ToastNotification;
            //_Notify = Notify;
        }
        [HttpGet, IgnoreAntiforgeryToken]
        public JArray GetSessions()
        {
            DataTable result = null;
            var query = "Select UserName,Company,DateTimeStamp from [Sessions] where UserName <> 'admin' ";
            using (var sereneconnection = DBHelper.GetSerenDBConnection())
            {
                if (sereneconnection.State != ConnectionState.Open)
                    sereneconnection.Open();
                result = DBHelper.GetTableFromQuery(query,sereneconnection);
                //if connection is not close then close
                if (sereneconnection.State != ConnectionState.Closed)
                    sereneconnection.Close();
            } 
            return JArray.FromObject(result);
             
        }
        //get Data Dictionaries from all controllers implementing IDataDictionary
        [HttpGet, IgnoreAntiforgeryToken]
        public System.Collections.Generic.List<dynamic> GetDataDictionaries()
        {
            //get objects implementing IDataDictionary 
            var controllers = AppDomain.CurrentDomain.GetAssemblies()
                 .SelectMany(s => s.GetTypes())
                 .Where(p => typeof(IDataDictionary).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract).ToList();
            System.Collections.Generic.List<dynamic> result = new System.Collections.Generic.List<dynamic>();
            foreach (var controller in controllers)
            {
                var controllername = controller.Name;
                var controllerinstance = (IDataDictionary)Activator.CreateInstance(controller, new object[] { null, null });
                var data = controllerinstance.GetAllDataDictionary();
                foreach (var item in data)
                {
                    result.Add(new {CompanyName=  item.dbname,UserName =  item.username,ModuleName =  item.modlulename,TotalCount= item.totalcount });
                }
            } 
            return  result;
        }

    }
}