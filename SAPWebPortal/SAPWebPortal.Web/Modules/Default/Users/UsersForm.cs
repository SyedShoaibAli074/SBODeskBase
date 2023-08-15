using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.Users")]
    [BasedOnRow(typeof(UsersRow), CheckNames = true)]
    public class UsersForm
    {
        [Visible(false)]
        public int UserId { get; set; }
        [Visible(false)]
        public String Username { get; set; }
        [DisplayName("User Name"), ReadOnly(true)]
        public String DisplayName { get; set; }
        [Visible(false)]
        public String Email { get; set; }
        [Visible(false)]
        public String Source { get; set; }
        [Visible(false)]
        public String PasswordHash { get; set; }
        [Visible(false)]
        public String PasswordSalt { get; set; }
        [Visible(false)]
        public String WarehouseCode { get; set; }
        [Visible(false)]
        public DateTime LastDirectoryUpdate { get; set; }
        [Visible(false)]
        public String UserImage { get; set; }
        [Visible(false)]
        public DateTime InsertDate { get; set; }
        [Visible(false)]
        public Int32 InsertUserId { get; set; }
        [Visible(false)]
        public DateTime UpdateDate { get; set; }
        [Visible(false)]
        public Int32 UpdateUserId { get; set; }
        [Visible(false)]
        public Int16 IsActive { get; set; }
        [Category("Add Reports")]
        [Report_UsersEditor]
        public System.Collections.Generic.List<Report_UsersRow> DetailList { get; set; }
    }
}