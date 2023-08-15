using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.ContactEmployees")]
    [BasedOnRow(typeof(ContactEmployeesRow), CheckNames = true)]
    public class ContactEmployeesForm
    {
        public string CardCode { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public string E_Mail { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailGroupCode { get; set; }
        public string Active { get; set; }
    }
}