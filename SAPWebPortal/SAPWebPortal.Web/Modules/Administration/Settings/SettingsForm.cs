using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Forms
{
    [FormScript("Administration.Settings")]
    [BasedOnRow(typeof(SettingsRow), CheckNames = true)]
    public class SettingsForm
    {
        public int UserId { get; set; }
        public int ModuleName { get; set; }
        public string ListDataSource { get; set; }
        public string PostByMethod { get; set; }
        public bool IsHana { get; set; }
    }
}