using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Forms
{
    [FormScript("Administration.Sessions")]
    [BasedOnRow(typeof(SessionsRow), CheckNames = true)]
    public class SessionsForm
    {
        public String SessionId { get; set; }
        public String UserName { get; set; }
    }
}