using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.BPAddresses")]
    [BasedOnRow(typeof(BPAddressesRow), CheckNames = true)]
    public class BPAddressesForm
    {
        
        //public string BPCode { get; set; }
        public string DBName { get; set; }
        public string AddressType { get; set; }
        public string AddressName { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        //[HalfWidth]

        //public string BuildingFloorRoom { get; set; }
       
        //[HalfWidth]

        //public string AddressName2 { get; set; }
        //[HalfWidth]

        //public string AddressName3 { get; set; }
        //[HalfWidth]

        //public string TypeOfAddress { get; set; }
        //[HalfWidth]

        //public string StreetNo { get; set; }
        //[HalfWidth]

        //public string GlobalLocationNumber { get; set; }
        //[HalfWidth]

        //public string Nationality { get; set; }
        //[HalfWidth]

        //public string TaxOffice { get; set; }
        //[HalfWidth]

        //public string GSTIN { get; set; }
        //[HalfWidth]

        //public string GstType { get; set; }


    }
}