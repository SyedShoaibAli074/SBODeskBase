using SAPWebPortal.Default;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Orders
{
    [ConnectionKey("Default"), Module("Default")/*, TableName("[dbo].[CRD1]")*/]
    [DisplayName("Addresses"), InstanceName("Addresses")]
    [ReadPermission("AddressExtension")]
    [ModifyPermission("AddressExtension")]
    public sealed class AddressExtensionRow : Row<AddressExtensionRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("ID"), Identity, IdProperty, NotMapped, NameProperty]
        public Int32? DetailID
        {
            get => fields.DetailID[this];
            set => fields.DetailID[this] = value;
        }


        [DisplayName("DocEntry"),Visible(false), Size(10), QuickSearch]
        public string DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }
        
        [DisplayName("ShipToStreet"), Size(255), NotMapped]
        public string ShipToStreet
        {
            get => fields.ShipToStreet[this];
            set => fields.ShipToStreet[this] = value;
        }
        [DisplayName("ShipToBlock"), Size(255), NotMapped]
        public string ShipToBlock
        {
            get => fields.ShipToBlock[this];
            set => fields.ShipToBlock[this] = value;
        }
        [DisplayName("ShipToBuilding"), Size(255), NotMapped]
        public string ShipToBuilding
        {
            get => fields.ShipToBuilding[this];
            set => fields.ShipToBuilding[this] = value;
        }
        [DisplayName("ShipToCity"), Size(255), NotMapped]
        public string ShipToCity
        {
            get => fields.ShipToCity[this];
            set => fields.ShipToCity[this] = value;
        }
        [DisplayName("ShipToZipCode"), Size(255), NotMapped]
        public string ShipToZipCode
        {
            get => fields.ShipToZipCode[this];
            set => fields.ShipToZipCode[this] = value;
        }
        [DisplayName("ShipToCounty"), Size(255), NotMapped]
        public string ShipToCounty
        {
            get => fields.ShipToCounty[this];
            set => fields.ShipToCounty[this] = value;
        }
        
        [DisplayName("ShipToCountry"), Size(255), NotMapped ,SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT DISTINCT T0.""Code"", T0.""Name"" FROM ""OCRY"" T0")]
        public string ShipToCountry
        {
            get => fields.ShipToCountry[this];
            set => fields.ShipToCountry[this] = value;
        }
        [DisplayName("ShipToAddressType"), Size(255), NotMapped ,BPAddressTypeEditor]
        public string ShipToAddressType
        {
            get => fields.ShipToAddressType[this];
            set => fields.ShipToAddressType[this] = value;
        }
        [DisplayName("BillToStreet"), Size(255), NotMapped]
        public string BillToStreet
        {
            get => fields.BillToStreet[this];
            set => fields.BillToStreet[this] = value;
        }
        [DisplayName("BillToStreetNo"), Size(255), NotMapped]
        public string BillToStreetNo
        {
            get => fields.BillToStreetNo[this];
            set => fields.BillToStreetNo[this] = value;
        }
        [DisplayName("ShipToStreetNo"), Size(255), NotMapped]
        public string ShipToStreetNo
        {
            get => fields.ShipToStreetNo[this];
            set => fields.ShipToStreetNo[this] = value;
        }
        [DisplayName("BillToBlock"), Size(255), NotMapped]
        public string BillToBlock
        {
            get => fields.BillToBlock[this];
            set => fields.BillToBlock[this] = value;
        }
        [DisplayName("BillToBuilding"), Size(255), NotMapped]
        public string BillToBuilding
        {
            get => fields.BillToBuilding[this];
            set => fields.BillToBuilding[this] = value;
        }
        [DisplayName("BillToCity"), Size(255), NotMapped]
        public string BillToCity
        {
            get => fields.BillToCity[this];
            set => fields.BillToCity[this] = value;
        }

       
        [DisplayName("BillToZipCode"), Size(255), NotMapped]
        public string BillToZipCode
        {
            get => fields.BillToZipCode[this];
            set => fields.BillToZipCode[this] = value;
        }
        [DisplayName("BillToCounty"), Size(255), NotMapped]
        public string BillToCounty
        {
            get => fields.BillToCounty[this];
            set => fields.BillToCounty[this] = value;
        }
        [DisplayName("BillToState"), Size(255), NotMapped]
        public string BillToState
        {
            get => fields.BillToState[this];
            set => fields.BillToState[this] = value;
        }
        [DisplayName("BillToCountry"), Size(255), NotMapped]
        public string BillToCountry
        {
            get => fields.BillToCountry[this];
            set => fields.BillToCountry[this] = value;
        }
        [DisplayName("BillToAddressType"), Size(255), NotMapped]
        public string BillToAddressType
        {
            get => fields.BillToAddressType[this];
            set => fields.BillToAddressType[this] = value;
        }
        [DisplayName("ShipToGlobalLocationNumber"), Size(255), NotMapped]
        public string ShipToGlobalLocationNumber
        {
            get => fields.ShipToGlobalLocationNumber[this];
            set => fields.ShipToGlobalLocationNumber[this] = value;
        }
        [DisplayName("BillToGlobalLocationNumber"), Size(255), NotMapped]
        public string BillToGlobalLocationNumber
        {
            get => fields.BillToGlobalLocationNumber[this];
            set => fields.BillToGlobalLocationNumber[this] = value;
        }
        [DisplayName("ShipToAddress2"), Size(255), NotMapped]
        public string ShipToAddress2
        {
            get => fields.ShipToAddress2[this];
            set => fields.ShipToAddress2[this] = value;
        }
        [DisplayName("ShipToAddress3"), Size(255), NotMapped]
        public string ShipToAddress3
        {
            get => fields.ShipToAddress3[this];
            set => fields.ShipToAddress3[this] = value;
        }
        [DisplayName("BillToAddress2"), Size(255), NotMapped]
        public string BillToAddress2
        {
            get => fields.BillToAddress2[this];
            set => fields.BillToAddress2[this] = value;
        }
        [DisplayName("BillToAddress3"), Size(255), NotMapped]
        public string BillToAddress3
        {
            get => fields.BillToAddress3[this];
            set => fields.BillToAddress3[this] = value;
        }
        [DisplayName("ShipToState"), Size(255), NotMapped]
        public string ShipToState
        {
            get => fields.ShipToState[this];
            set => fields.ShipToState[this] = value;
        }
        public AddressExtensionRow()
            : base()
        {
        }

        public AddressExtensionRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field DetailID;
            public StringField DocEntry ;
            public StringField ShipToStreet ;
            public StringField ShipToStreetNo ;
            public StringField ShipToBlock ;
            public StringField ShipToBuilding ;
            public StringField ShipToCity ;
            public StringField ShipToZipCode ;
            public StringField ShipToCounty ;
            public StringField ShipToState ;
            public StringField ShipToCountry ;
            public StringField ShipToAddressType ;
            public StringField BillToStreet ;
            public StringField BillToStreetNo ;
            public StringField BillToBlock ;
            public StringField BillToBuilding ;
            public StringField BillToCity ;
            public StringField BillToZipCode ;
            public StringField BillToCounty ;
            public StringField BillToState ;
            public StringField BillToCountry ;
            public StringField BillToAddressType ;
            public StringField ShipToGlobalLocationNumber ;
            public StringField BillToGlobalLocationNumber ;
            public StringField ShipToAddress2 ;
            public StringField ShipToAddress3 ;
            public StringField BillToAddress2 ;
            public StringField BillToAddress3 ;
        }
        
    }
}
