using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAPWebPortal.Web.Modules.Common.Attributes
{
    public class SelectCodeNameValueEditorAttribute : CustomEditorAttribute
    {
       public  string Query { get;set; }
        public List<string> CascadeSourceFields { get; set; }
        public SelectCodeNameValueEditorAttribute(String Query = "",[CallerMemberName] string propertyName = null) :base("SAPWebPortal.Default.SelectCodeNameValueEditor")
        {
            if (propertyName == "CardCode")
            {
            }
                this.Query = Query;
                CascadeSourceFields = new List<string>();
                SetOption("Query", Query);
                SetOption("propertyNameSAP", propertyName);
                Regex regex = new Regex("'@.*'");
                MatchCollection matches = regex.Matches(Query);
                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        CascadeSourceFields.Add(match.Value.Replace("@", "").Replace("'", ""));
                    }
                }
                SetOption("CascadeSourceFields", CascadeSourceFields.ToArray());
            
        }
    }
}
