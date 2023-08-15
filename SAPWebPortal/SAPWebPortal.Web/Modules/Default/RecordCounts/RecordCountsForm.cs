using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.RecordCounts")]
    [BasedOnRow(typeof(RecordCountsRow), CheckNames = true)]
    public class RecordCountsForm
    {
        public string ModuleName { get; set; }
        public int ObjectType { get; set; }
        public string Company { get; set; }
        [ ReadOnly(true),HalfWidth]
        public int Counts { get; set; }
        [DateTimeEditor,ReadOnly(true), HalfWidth]
        public DateTime DateTimeStamp { get; set; }
    }
}