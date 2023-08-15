using System;
using System.Collections.Generic;
namespace SAPWebPortal.Web.Models.SLModels
{
    [ServiceLayer("InventoryTransferRequests")]
    public class StockTransfer
    {
        public String DBName { get; set; }
        [SAPPrimaryKey]
        public int DocEntry { get; set; }
        public List<StockTransferLines> StockTransferLines { get; set; }


    }
    public class StockTransferLines
    {
        public int DocEntry { get; set; }
        public int LineNum { get; set; }
       
        public double U_RecQty { get; set; }
    }
}
