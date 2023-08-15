using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.InventoryTransferRequest.Columns
{
    [ColumnsScript("InventoryTransferRequest.StockTransfer")]
    [BasedOnRow(typeof(StockTransferRow), CheckNames = true)]
    public class StockTransferColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 DocEntry { get; set; }
        public Int32 DocNum { get; set; }
        public Int32 Series { get; set; }
        [EditLink]
        public String Printed { get; set; }
        public DateTimeOffset DocDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public String CardCode { get; set; }
        public String CardName { get; set; }
        public String Address { get; set; }
        public String Reference1 { get; set; }
        public String Reference2 { get; set; }
        public String Comments { get; set; }
        public String JournalMemo { get; set; }
        public Int32 PriceList { get; set; }
        public Int32 SalesPersonCode { get; set; }
        public String FromWarehouse { get; set; }
        public String ToWarehouse { get; set; }  
        public DateTimeOffset TaxDate { get; set; }
        public Int32 ContactPerson { get; set; }
        public String FolioPrefixString { get; set; }
        public Int32 FolioNumber { get; set; }
        public String DocObjectCode { get; set; } 
        public String DocumentStatus { get; set; }
    }
}