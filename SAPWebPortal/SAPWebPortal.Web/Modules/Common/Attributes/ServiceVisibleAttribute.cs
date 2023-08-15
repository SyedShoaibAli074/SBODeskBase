using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SAPWebPortal.Web.Modules.Common.Attributes
{
    public class ServiceVisibleAttribute : CustomEditorAttribute
    {
       public  bool Visible { get; set; }
        public ServiceVisibleAttribute(bool visible = true,[CallerMemberName] string propertyName = null) :base("ServiceVisible")
        {
            this.Visible = visible;
            SetOption("ServiceVisible", visible);
        }
    }
}
