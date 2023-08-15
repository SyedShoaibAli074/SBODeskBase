using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.InventoryTransferRequest
{
    [ConnectionKey("Default"), Module("InventoryTransferRequest"), ServiceLayer("InventoryTransferRequests")]
    [DisplayName("Stock Transfer"), InstanceName("Stock Transfer")]
    [ReadPermission("InventoryTransferRequest")]
    [ModifyPermission("InventoryTransferRequest")]
    [NotMapped]
    public sealed class StockTransferRow : Row<StockTransferRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Doc Entry"), NotNull, IdProperty]
        [NotMapped]
        [SAPDBFieldName("DocEntry")]
        [SAPPrimaryKey]
        public Int32? DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }

        [DisplayName("Series")]
        [NotMapped]
        [SAPDBFieldName("Series")]
        public Int32? Series

        {
            get => fields.Series[this];
            set => fields.Series[this] = value;
        }

        [DisplayName("Printed"), QuickSearch, NameProperty]
        [NotMapped]
        [SAPDBFieldName("Printed")]
        public String? Printed
        {
            get => fields.Printed[this];
            set => fields.Printed[this] = value;
        }

        [DisplayName("Doc Date")]
        [NotMapped]
        [SAPDBFieldName("DocDate")]
        public DateTimeOffset? DocDate
        {
            get => fields.DocDate[this];
            set => fields.DocDate[this] = value;
        }

        [DisplayName("Due Date")]
        [NotMapped]
        [SAPDBFieldName("DocDueDate")]
        public DateTimeOffset? DueDate
        {
            get => fields.DueDate[this];
            set => fields.DueDate[this] = value;
        }

        [DisplayName("Card Code")]
        [NotMapped]
        public String? CardCode
        {
            get => fields.CardCode[this];
            set => fields.CardCode[this] = value;
        }

        [DisplayName("Card Name")]
        [NotMapped]
        public String? CardName
        {
            get => fields.CardName[this];
            set => fields.CardName[this] = value;
        }

        [DisplayName("Address")]
        [NotMapped]
        public String? Address
        {
            get => fields.Address[this];
            set => fields.Address[this] = value;
        }

        [DisplayName("Reference1")]
        [NotMapped]
        public String? Reference1
        {
            get => fields.Reference1[this];
            set => fields.Reference1[this] = value;
        }

        [DisplayName("Reference2")]
        [NotMapped]
        public String? Reference2
        {
            get => fields.Reference2[this];
            set => fields.Reference2[this] = value;
        }

        [DisplayName("Comments")]
        [NotMapped]
        public String? Comments
        {
            get => fields.Comments[this];
            set => fields.Comments[this] = value;
        }

        [DisplayName("Journal Memo")]
        [NotMapped]
        public String? JournalMemo
        {
            get => fields.JournalMemo[this];
            set => fields.JournalMemo[this] = value;
        }

        [DisplayName("Price List")]
        [NotMapped]
        public Int32? PriceList
        {
            get => fields.PriceList[this];
            set => fields.PriceList[this] = value;
        }

        [DisplayName("Sales Person Code")]
        [NotMapped]
        public Int32? SalesPersonCode
        {
            get => fields.SalesPersonCode[this];
            set => fields.SalesPersonCode[this] = value;
        }

        [DisplayName("From Warehouse")]
        [NotMapped]
        [SAPDBFieldName("Filler")]
        public String? FromWarehouse
        {
            get => fields.FromWarehouse[this];
            set => fields.FromWarehouse[this] = value;
        }

        [DisplayName("To Warehouse")]
        [NotMapped]
        [SAPDBFieldName("ToWhsCode")]
        public String? ToWarehouse
        {
            get => fields.ToWarehouse[this];
            set => fields.ToWarehouse[this] = value;
        }

        [DisplayName("Creation Date")]
        [NotMapped]
        public DateTimeOffset? CreationDate
        {
            get => fields.CreationDate[this];
            set => fields.CreationDate[this] = value;
        }

        [DisplayName("Update Date")]
        [NotMapped]
        public DateTimeOffset? UpdateDate
        {
            get => fields.UpdateDate[this];
            set => fields.UpdateDate[this] = value;
        }

        [DisplayName("Financial Period")]
        [NotMapped]
        public Int32? FinancialPeriod
        {
            get => fields.FinancialPeriod[this];
            set => fields.FinancialPeriod[this] = value;
        }

        [DisplayName("Trans Num")]
        [NotMapped]
        public Int32? TransNum
        {
            get => fields.TransNum[this];
            set => fields.TransNum[this] = value;
        }

        [DisplayName("Doc Num")]
        [NotMapped]
        [SAPDBFieldName("DocNum")]
        public Int32? DocNum
        {
            get => fields.DocNum[this];
            set => fields.DocNum[this] = value;
        }

        [DisplayName("Tax Date")]
        [NotMapped]
        public DateTimeOffset? TaxDate
        {
            get => fields.TaxDate[this];
            set => fields.TaxDate[this] = value;
        }

        [DisplayName("Contact Person")]
        [NotMapped]
        public Int32? ContactPerson
        {
            get => fields.ContactPerson[this];
            set => fields.ContactPerson[this] = value;
        }

        [DisplayName("Folio Prefix String")]
        [NotMapped]
        public String? FolioPrefixString
        {
            get => fields.FolioPrefixString[this];
            set => fields.FolioPrefixString[this] = value;
        }

        [DisplayName("Folio Number")]
        [NotMapped]
        public Int32? FolioNumber
        {
            get => fields.FolioNumber[this];
            set => fields.FolioNumber[this] = value;
        }

        [DisplayName("Doc Object Code")]
        [NotMapped]
        public String? DocObjectCode
        {
            get => fields.DocObjectCode[this];
            set => fields.DocObjectCode[this] = value;
        }


        [DisplayName("Bplid"), Column("BPLID")]
        [NotMapped]
        public Int32? Bplid
        {
            get => fields.Bplid[this];
            set => fields.Bplid[this] = value;
        }

        [DisplayName("Bpl Name"), Column("BPLName")]
        [NotMapped]
        public String? BplName
        {
            get => fields.BplName[this];
            set => fields.BplName[this] = value;
        }

        [DisplayName("Vat Reg Num"), Column("VATRegNum")]
        [NotMapped]
        public String? VatRegNum
        {
            get => fields.VatRegNum[this];
            set => fields.VatRegNum[this] = value;
        }

        [DisplayName("Authorization Code")]
        [NotMapped]
        public String? AuthorizationCode
        {
            get => fields.AuthorizationCode[this];
            set => fields.AuthorizationCode[this] = value;
        }

        [DisplayName("Start Delivery Date")]
        [NotMapped]
        public DateTimeOffset? StartDeliveryDate
        {
            get => fields.StartDeliveryDate[this];
            set => fields.StartDeliveryDate[this] = value;
        }


        [DisplayName("End Delivery Date")]
        [NotMapped]
        public DateTimeOffset? EndDeliveryDate
        {
            get => fields.EndDeliveryDate[this];
            set => fields.EndDeliveryDate[this] = value;
        }


        [DisplayName("Vehicle Plate")]
        [NotMapped]
        public String? VehiclePlate
        {
            get => fields.VehiclePlate[this];
            set => fields.VehiclePlate[this] = value;
        }

        [DisplayName("At Document Type"), Column("ATDocumentType")]
        [NotMapped]
        public String? AtDocumentType
        {
            get => fields.AtDocumentType[this];
            set => fields.AtDocumentType[this] = value;
        }

        [DisplayName("E Doc Export Format")]
        [NotMapped]
        public Int32? EDocExportFormat
        {
            get => fields.EDocExportFormat[this];
            set => fields.EDocExportFormat[this] = value;
        }
         

        [DisplayName("Elec Comm Message")]
        [NotMapped]
        public String? ElecCommMessage
        {
            get => fields.ElecCommMessage[this];
            set => fields.ElecCommMessage[this] = value;
        }

        [DisplayName("Point Of Issue Code")]
        [NotMapped]
        public String? PointOfIssueCode
        {
            get => fields.PointOfIssueCode[this];
            set => fields.PointOfIssueCode[this] = value;
        }
         
        [DisplayName("Folio Number From")]
        [NotMapped]
        public Int32? FolioNumberFrom
        {
            get => fields.FolioNumberFrom[this];
            set => fields.FolioNumberFrom[this] = value;
        }

        [DisplayName("Folio Number To")]
        [NotMapped]
        public Int32? FolioNumberTo
        {
            get => fields.FolioNumberTo[this];
            set => fields.FolioNumberTo[this] = value;
        }

        [DisplayName("Attachment Entry")]
        [NotMapped]
        public Int32? AttachmentEntry
        {
            get => fields.AttachmentEntry[this];
            set => fields.AttachmentEntry[this] = value;
        }

        [DisplayName("Document Status")]
        [NotMapped]
        [SAPDBFieldName("DocStatus")]
        public String? DocumentStatus
        {
            get => fields.DocumentStatus[this];
            set => fields.DocumentStatus[this] = value;
        }

        [DisplayName("Ship To Code")]
        [NotMapped]
        public String? ShipToCode
        {
            get => fields.ShipToCode[this];
            set => fields.ShipToCode[this] = value;
        }

        [DisplayName("Sap Passport"), Column("SAPPassport"), NotNull]
        [NotMapped]
        public String? SapPassport
        {
            get => fields.SapPassport[this];
            set => fields.SapPassport[this] = value;
        }
        [DisplayName("Document Lines"), MasterDetailRelation(foreignKey: "DocEntry")]
         public System.Collections.Generic.List<StockTransferLineRow> StockTransferLines
        {
            get => fields.StockTransferLines[this];
            set => fields.StockTransferLines[this] = value;
        }
        //DBName
        [DisplayName("DBName"), NotNull, RemoveFromEntity]
        [NotMapped]
        public String? DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        }

        public StockTransferRow()
            : base()
        {
        }

        public StockTransferRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field DocEntry;
            public Int32Field Series;
            public StringField Printed;
            public DateTimeOffsetField DocDate;
            public DateTimeOffsetField DueDate;
            public StringField CardCode;
            public StringField CardName;
            public StringField Address;
            public StringField Reference1;
            public StringField Reference2;
            public StringField Comments;
            public StringField JournalMemo;
            public Int32Field PriceList;
            public Int32Field SalesPersonCode;
            public StringField FromWarehouse;
            public StringField ToWarehouse;
            public DateTimeOffsetField CreationDate;
            public DateTimeOffsetField UpdateDate;
            public Int32Field FinancialPeriod;
            public Int32Field TransNum;
            public Int32Field DocNum;
            public DateTimeOffsetField TaxDate;
            public Int32Field ContactPerson;
            public StringField FolioPrefixString;
            public Int32Field FolioNumber;
            public StringField DocObjectCode; 
            public Int32Field Bplid;
            public StringField BplName;
            public StringField VatRegNum;
            public StringField AuthorizationCode;
            public DateTimeOffsetField StartDeliveryDate; 
            public DateTimeOffsetField EndDeliveryDate; 
            public StringField VehiclePlate;
            public StringField AtDocumentType;
            public Int32Field EDocExportFormat; 
            public StringField ElecCommMessage;
            public StringField PointOfIssueCode; 
            public Int32Field FolioNumberFrom;
            public Int32Field FolioNumberTo;
            public Int32Field AttachmentEntry;
            public StringField DocumentStatus;
            public StringField ShipToCode;
            public StringField SapPassport;
            public StringField DBName;
            public RowListField<StockTransferLineRow> StockTransferLines;
        }
    }
}
