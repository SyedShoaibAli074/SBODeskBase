﻿using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using SAPWebPortal.Orders;

namespace SAPWebPortal.Orders.Columns
{
    [ColumnsScript("Orders.AddressExtension")]
    [BasedOnRow(typeof(AddressExtensionRow), CheckNames = true)]
    public class AddressExtensionColumns
    {
        [DisplayName("Db.Shared.RecordId"), AlignRight]
        public string ShipToStreet { get; set; }
        public string ShipToStreetNo { get; set; }
        public string ShipToBlock { get; set; }
        public string ShipToBuilding { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToZipCode { get; set; }
        public string ShipToCounty { get; set; }
        public string ShipToState { get; set; }
        public string ShipToCountry { get; set; }
        public string ShipToAddressType { get; set; }
        public string BillToStreet { get; set; }
        public string BillToStreetNo { get; set; }
        public string BillToBlock { get; set; }
        public string BillToBuilding { get; set; }
        public string BillToCity { get; set; }
        public string BillToZipCode { get; set; }
        public string BillToCounty { get; set; }
        public string BillToState { get; set; }
        public string BillToCountry { get; set; }
        public string BillToAddressType { get; set; }
        public string ShipToGlobalLocationNumber { get; set; }
        public string BillToGlobalLocationNumber { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToAddress3 { get; set; }
        public string BillToAddress2 { get; set; }
        public string BillToAddress3 { get; set; }
    }
}