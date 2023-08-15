using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.BusinessPartner")]
    [BasedOnRow(typeof(BusinessPartnerRow), CheckNames = true)]
    public class BusinessPartnerColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public long InternalCode { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string CardForeignName { get; set; }
        public string CardType { get; set; }
        public decimal? CurrentAccountBalance{ get; set; }
    }

}