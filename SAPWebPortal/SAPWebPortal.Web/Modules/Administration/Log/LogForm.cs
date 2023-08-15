using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Administration.Forms
{
    [FormScript("Administration.Log")]
    [BasedOnRow(typeof(LogRow), CheckNames = true)]
    public class LogForm
    {
        [MediumThirdLargeQuarterWidth, ReadOnly(true)]
        public DateTime UDateTime { get; set; }
        [MediumThirdLargeQuarterWidth, ReadOnly(true)]

        public String UDirection { get; set; }
        [MediumThirdLargeQuarterWidth, ReadOnly(true)]

        public String UError { get; set; }
        //[MediumThirdLargeQuarterWidth, ReadOnly(true)]
        //public String UObjType { get; set; }
        //[MediumThirdLargeQuarterWidth, ReadOnly(true)]

        //public String UVersion { get; set; }
        //[MediumThirdLargeQuarterWidth, ReadOnly(true)]

        //public String UKey { get; set; }
        //[MediumThirdLargeQuarterWidth, ReadOnly(true)]

        //public String UDocNum { get; set; }
        //[MediumThirdLargeQuarterWidth]
        //public Int16 Updated { get; set; }
        [FullWidth, TextAreaEditor, ReadOnly(true)]
        public String UXml { get; set; }
        [FullWidth, TextAreaEditor, ReadOnly(true)]

        public String UResponse { get; set; }
        //public String DocId { get; set; }
    }
}