 
using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SAPWebPortal.Web.Modules.Common.Attributes
{
    public class SelectDefaultValueEditorAttribute : CustomEditorAttribute
    {
        public string Query { get; set; }
        public List<string> CascadeSourceFields { get; set; }
        public SelectDefaultValueEditorAttribute(String Query = "", [CallerMemberName] string propertyName = null) : base("SAPWebPortal.Default.SelectCodeNameValueEditor")
        { 
            this.Query = Query;
            CascadeSourceFields = new List<string>();
            SetOption("Default_Query", Query);
            SetOption("Default_propertyNameSAP", propertyName);
            Regex regex = new Regex("'@.*'");
            MatchCollection matches = regex.Matches(Query);
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    CascadeSourceFields.Add(match.Value.Replace("@", "").Replace("'", ""));
                }
            }
            SetOption("Default_CascadeSourceFields", CascadeSourceFields.ToArray());

        }
    }
}
