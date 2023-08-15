using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Forms
{
    [FormScript("Administration.UserFormAuthorizationsDetails")]
    [BasedOnRow(typeof(UserFormAuthorizationsDetailsRow), CheckNames = true)]
    public class UserFormAuthorizationsDetailsForm
    {
       
        [HalfWidth]
        public string FieldName { get; set; }
        [HalfWidth]
        public string FieldDescription { get; set; }
        [HalfWidth]
        public string DataType { get; set; }
        [HalfWidth]
        public string DefaultValue { get; set; }
        [HalfWidth]
        public string DataSize { get; set; }
        [HalfWidth]
        public bool Readonly { get; set; }
        [HalfWidth]
        public bool Required { get; set; }
        [HalfWidth]
        public bool Visible { get; set; }
        [HalfWidth]
        public string HtmlClass { get; set; }
        [HalfWidth]
        public string HtmlStyle { get; set; }
        [HalfWidth]
        public string HtmlAttributes { get; set; }
    }
}