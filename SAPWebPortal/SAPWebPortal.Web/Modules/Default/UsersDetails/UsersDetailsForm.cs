using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.UsersDetails")]
    [BasedOnRow(typeof(UsersDetailsRow), CheckNames = true)]
    public class UsersDetailsForm
    {
        [Visible(false)]
        public int U1Id { get; set; }
        public string ParameterName { get; set; }
        public string ParameterQuery { get; set; }
        [DisplayName("Database Name"), ReadOnly(true)]
        public String DbName { get; set; }
    }
}