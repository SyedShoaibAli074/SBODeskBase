using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.UserDetail1")]
    [BasedOnRow(typeof(UserDetail1Row), CheckNames = true)]
    public class UserDetail1Form
    {
        public int UserDId { get; set; }
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string DbName { get; set; }
        public string CardCode { get; set; }
        [Visible(false)]
        public string CardName { get; set; }
        public string Active { get; set; }
    }
}