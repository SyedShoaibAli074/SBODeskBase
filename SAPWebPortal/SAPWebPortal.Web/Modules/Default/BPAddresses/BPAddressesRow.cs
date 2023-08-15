using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default")/*, TableName("[dbo].[CRD1]")*/]
    [DisplayName("Addresses"), InstanceName("Addresses")]
    [ReadPermission("BPAddresses")]
    [ModifyPermission("BPAddresses")]
    public sealed class BPAddressesRow : Row<BPAddressesRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("ID"), Identity, IdProperty, NotMapped, NameProperty]
        public Int32? DetailID
        {
            get => fields.DetailID[this];
            set => fields.DetailID[this] = value;
        }
        [DisplayName("Card Code"),Visible(false), Size(10), QuickSearch]
        public string BPCode
        {
            get => fields.BPCode[this];
            set => fields.BPCode[this] = value;
        }
        [DisplayName("DBName"),NotMapped]
        public string DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        }
        [DisplayName("Address"), Size(255), NotMapped]
        public string AddressName
        {
            get => fields.AddressName[this];
            set => fields.AddressName[this] = value;
        }
        [DisplayName("Street"), Size(255), NotMapped]
        public string Street
        {
            get => fields.Street[this];
            set => fields.Street[this] = value;
        }
        [DisplayName("Block"), Size(255), NotMapped]
        public string Block
        {
            get => fields.Block[this];
            set => fields.Block[this] = value;
        }
        [DisplayName("ZipCode"), Size(255), NotMapped]
        public string ZipCode
        {
            get => fields.ZipCode[this];
            set => fields.ZipCode[this] = value;
        }
        [DisplayName("City"), Size(255), NotMapped]
        public string City
        {
            get => fields.City[this];
            set => fields.City[this] = value;
        }
        [DisplayName("County"), Size(255), NotMapped]
        public string County
        {
            get => fields.County[this];
            set => fields.County[this] = value;
        }
        [DisplayName("Country"), Size(255), NotMapped ,SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT DISTINCT T0.""Code"", T0.""Name"" FROM ""OCRY"" T0")]
        public string Country
        {
            get => fields.Country[this];
            set => fields.Country[this] = value;
        }
        [DisplayName("State"), Size(255), NotMapped, SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT DISTINCT T0.""Code"", T0.""Name"" FROM ""OCST"" T0 WHERE T0.""Country"" ='@Country'") ]
        public string State
        {
            get => fields.State[this];
            set => fields.State[this] = value;
        }
        [DisplayName("Building Floor Room"), Size(255), NotMapped]
        public string BuildingFloorRoom
        {
            get => fields.BuildingFloorRoom[this];
            set => fields.BuildingFloorRoom[this] = value;
        }
        [DisplayName("Address Type"), Size(255), NotMapped,NotNull, BPAddressTypeEditor]
        public string AddressType
        {
            get => fields.AddressType[this];
            set => fields.AddressType[this] = value;
        }
        [DisplayName("Address Name2"), Size(255), NotMapped]
        public string AddressName2
        {
            get => fields.AddressName2[this];
            set => fields.AddressName2[this] = value;
        }
        [DisplayName("Address Name3"), Size(255), NotMapped]
        public string AddressName3
        {
            get => fields.AddressName3[this];
            set => fields.AddressName3[this] = value;
        }
        [DisplayName("Type Of Address"), Size(255), NotMapped]
        public string TypeOfAddress
        {
            get => fields.TypeOfAddress[this];
            set => fields.TypeOfAddress[this] = value;
        }

        [DisplayName("Street No"), Size(255), NotMapped]
        public string StreetNo
        {
            get => fields.StreetNo[this];
            set => fields.StreetNo[this] = value;
        }
        [DisplayName("Global Location Number"), Size(255), NotMapped]
        public string GlobalLocationNumber
        {
            get => fields.GlobalLocationNumber[this];
            set => fields.GlobalLocationNumber[this] = value;
        }
        [DisplayName("Nationality"), Size(255), NotMapped]
        public string Nationality
        {
            get => fields.Nationality[this];
            set => fields.Nationality[this] = value;
        }
        [DisplayName("Tax Office"), Size(255), NotMapped]
        public string TaxOffice
        {
            get => fields.TaxOffice[this];
            set => fields.TaxOffice[this] = value;
        }
        [DisplayName("GST IN"), Size(255), NotMapped]
        public string GSTIN
        {
            get => fields.GSTIN[this];
            set => fields.GSTIN[this] = value;
        }
        [DisplayName("GST Type"), Size(255), NotMapped]
        public string GstType
        {
            get => fields.GstType[this];
            set => fields.GstType[this] = value;
        }
        public BPAddressesRow()
            : base()
        {
        }

        public BPAddressesRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField AddressName;
            public Int32Field DetailID;
            public StringField Street;
            public StringField Block;
            public StringField ZipCode;
            public StringField City;
            public StringField County;
            public StringField Country;
            public StringField State;
            public StringField BuildingFloorRoom;
            public StringField AddressType;
            public StringField AddressName2;
            public StringField AddressName3;
            public StringField TypeOfAddress;
            public StringField StreetNo;
            public StringField BPCode;
            public StringField GlobalLocationNumber;
            public StringField Nationality;
            public StringField TaxOffice;
            public StringField GSTIN;
            public StringField GstType;
            public StringField DBName;
        }
        
    }
}
