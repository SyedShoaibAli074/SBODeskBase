using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Columns
{
    [ColumnsScript("Default.BPAddresses")]
    [BasedOnRow(typeof(BPAddressesRow), CheckNames = true)]
    public class BPAddressesColumns
    {
        [ DisplayName("Db.Shared.RecordId"), AlignRight]
        public string BPCode { get; set; }
        public string AddressType { get; set; }
        public string AddressName { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        //public string BuildingFloorRoom { get; set; }
        //public string AddressName2 { get; set; }
        //public string AddressName3 { get; set; }
        //public string TypeOfAddress { get; set; }
        //public string StreetNo { get; set; }
        //public string GlobalLocationNumber { get; set; }
        //public string Nationality { get; set; }
        //public string TaxOffice { get; set; }
        //public string GSTIN { get; set; }
        //public string GstType { get; set; }
    }
}