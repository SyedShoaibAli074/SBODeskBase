using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Forms
{
    [FormScript("Administration.UserFormAuthorizations")]
    [BasedOnRow(typeof(UserFormAuthorizationsRow), CheckNames = true)]
    public class UserFormAuthorizationsForm
    {
        [HalfWidth]
        public int UserId { get; set; }
        [HalfWidth]
        public int ModuleName { get; set; }
        [HalfWidth]
        public string CompanyDb { get; set; }
        [HalfWidth]
        public string FormName { get; set; }
        [HalfWidth]
        public string FormTitle { get; set; }
        [HalfWidth]
        public string FormDescription { get; set; }
        [UserFormAuthorizationsDetailsEditor]
        public System.Collections.Generic.List<UserFormAuthorizationsDetailsRow> DetailList { get; set; }
    }
}