using Serenity.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SAPWebPortal.Web.Modules.Common.Attributes
{
    public class SeriesValuesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "SAPWebPortal.Default.SeriesValuesEditor";
        public SeriesValuesEditorAttribute( [CallerMemberName] string propertyName = null) :base(Key)
        { 

        }
    }
}
