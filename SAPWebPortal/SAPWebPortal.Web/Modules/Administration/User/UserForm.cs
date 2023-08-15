using SAPWebPortal.Default;
using Serenity.ComponentModel;
using System;
using System.ComponentModel;

namespace SAPWebPortal.Administration.Forms
{
    [FormScript("Administration.User")]
    [BasedOnRow(typeof(Entities.UserRow), CheckNames = true)]
    public class UserForm
    {
        public String Username { get; set; }
        [Hidden]
        public String DBName { get; set; }
        public String DisplayName { get; set; }
        [EmailEditor]
        public String Email { get; set; }
        public String UserImage { get; set; }
        [PasswordEditor, Required(true)]
        public String Password { get; set; }
        [PasswordEditor, OneWay, Required(true)]
        public String PasswordConfirm { get; set; } 
        public String WarehouseCode { get; set; }
        [SourceValuesEditor]
        public string Source { get; set; }

       /* [Tab("Customers Autherization")]
        [AutherizedCustomersEditor]*/
        public System.Collections.Generic.List<UserDetail1Row> DetailList { get; set; }   
        /*[Tab("SalesPerson Autherization")]
        [AutherizedSalesPersonEditor]*/
        public System.Collections.Generic.List<UserDetail2Row> DetailList1 { get; set; }
        //disable the field
        [ReadOnly(true)]
        public string CompanyDatabase { get; set; }
    }
}