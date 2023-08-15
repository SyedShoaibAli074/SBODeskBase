
using SAPWebPortal.Web.Modules.Common.Helpers;
using Newtonsoft.Json.Linq;
using SAPWebPortal.Administration.Endpoints;
using SAPWebPortal.Default.Endpoints;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAPWebPortal.Web.Modules.Common.Helpers
{
    public class CommonFunctions<T>
    {

        IRequestContext Context;
        public CommonFunctions(IRequestContext context)
        {
            this.Context = context;
        }

        public string PostAttachment(Serenity.Services.SaveRequest<T> request, string path, int UserId,bool IsNew=false)
        {
            string AttachmentEntry ="";
            path = path.Replace("/", @"\");
            path = Path.Combine(@"App_Data\upload\", path);
            var Newpath = Path.Combine(Startup.basePath, path);
            //path =  Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), path);           
            FileInfo File = new FileInfo(Newpath);
            if (File.Exists)
            {
                JObject Obj = new JObject();
                JArray jArray = new JArray();
                Obj.Add("Attachments2_Lines", jArray);
                var jdata = new JObject();
                jdata["FileExtension"] = File.Extension;
                jdata["FileName"] = File.Name;
                jdata["SourcePath"] = File.DirectoryName; 
                jdata["UserID"] = UserId;
                jArray.Add(jdata);
                var data = Obj.ToString();
                var helper = ServiceLayerRestHandler.GetInstance(Context, request.DBName);
                string response;
                string ModuleName= "Attachments2";
                bool B = false;
                if (!IsNew)
                {
                    B = helper.AddToBO(ModuleName, data, out response);
                    if (!B)
                    {
                        ExceptionsController.Log(new Exception("Module:" + ModuleName + " Error: " + response.ToString()));
                    }
                    else
                    {
                        AttachmentEntry = JObject.Parse(response)?["AbsoluteEntry"]?.ToString();
                    }
                }
                else if (IsNew)
                {
                    //:todo Update of Attachment
                    //B = helper.UpdateBO(ModuleName,, data, out response);
                    //if (!B)
                    //{
                    //    ExceptionsController.Log(new Exception("Module:" + ModuleName + " Error: " + response.ToString()));
                    //}
                    //else
                    //{
                    //    AttachmentEntry = JObject.Parse(response)?["AbsoluteEntry"]?.ToString();
                    //}
                }

            }
            return AttachmentEntry;
        }
    }
}
