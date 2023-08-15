using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.UserDetail2")]
    [BasedOnRow(typeof(UserDetail2Row), CheckNames = true)]
    public class UserDetail2Form
    {
        public int UserDId { get; set; }
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string DbName { get; set; }
        public string SalesPersonCode { get; set; }
        [Visible(false)]
        public string SalesPersonName { get; set; }
        public string Active { get; set; }
    }
}