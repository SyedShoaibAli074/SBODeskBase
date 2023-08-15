namespace SAPWebPortal.Web.Modules.DownPayment
{
    public class DocumentLineRow
    {
       /* public int? DocEntry { get; set; }

        public int? LineNum { get; set; }
*/
        public string ItemCode { get; set; }
        public string VatGroup { get; set; }

        public string ItemDescription { get; set; }

        public decimal? Quantity { get; set; }

        //public decimal? UnitsOfMeasurement { get; set; }

        public decimal? UnitPrice { get; set; }

       // public decimal? PriceAfterVat { get; set; }

        public decimal? DiscountPercent { get; set; }

       // public string WarehouseCode { get; set; }

        //public string VatGroup { get; set; }

        public string UoMCode { get; set; }

        public decimal? TaxTotal { get; set; }

       public decimal? LineTotal { get; set; }

        //public decimal? GrossTotal { get; set; }

        //public string AccountCode { get; set; }

        public int? BaseType { get; set; }

        public int? BaseEntry { get; set; }

        public int? BaseLine { get; set; }
    }
}
