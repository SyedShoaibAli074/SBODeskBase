using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.InventoryTransferRequest.Forms
{
    [FormScript("InventoryTransferRequest.StockTransfer")]
    [BasedOnRow(typeof(StockTransferRow), CheckNames = true)]
    public class StockTransferForm
    {
        [HalfWidth]
        public Int32 Series { get; set; }
        [HalfWidth]
        public String Printed { get; set; }
        [HalfWidth]
        public DateTimeOffset DocDate { get; set; }
        [HalfWidth]
        public DateTimeOffset DueDate { get; set; }
        [HalfWidth]
        public String CardCode { get; set; }
        [HalfWidth]
        public String CardName { get; set; }
        [HalfWidth]
        public String Address { get; set; }
        [HalfWidth]
        public String Reference1 { get; set; }
        [HalfWidth]
        public String Reference2 { get; set; }
        [HalfWidth]
        public String Comments { get; set; }
        [HalfWidth]
        public String JournalMemo { get; set; }
        [HalfWidth]
        public Int32 PriceList { get; set; }
        [HalfWidth]
        public Int32 SalesPersonCode { get; set; }
        [HalfWidth]
        public String FromWarehouse { get; set; }
        [HalfWidth]
        public String ToWarehouse { get; set; }
        [HalfWidth]
        public String DBName { get; set; }

      [StockTransferLineEditor]
        public System.Collections.Generic.List<StockTransferLineRow> StockTransferLines { get; set; }
    }
}