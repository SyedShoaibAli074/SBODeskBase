using SAPWebPortal.ARInvoiceLine;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.ARInvoice
{
    [ConnectionKey("Default"), Module("ARInvoice"), ServiceLayer("Invoices")]
    [DisplayName("AR Invoices"), InstanceName("Document")]
    [ReadPermission("ARInvoice")]
    [ModifyPermission("ARInvoice")]
    [NotMapped]
    public sealed class DocumentRow : Row<DocumentRow.RowFields>, IIdRow
    {
        [DisplayName("Doc Entry"), NotNull, IdProperty]
        [NotMapped]
        [SAPPrimaryKey]
        [SAPDBFieldName("DocEntry"),QuickSearch()]
        public System.Int32? DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }

        [DisplayName("Doc Num"), NotNull,QuickSearch()]
        [NotMapped]
        [SAPDBFieldName("DocNum")]
        public System.Int32? DocNum
        {
            get => fields.DocNum[this];
            set => fields.DocNum[this] = value;
        }
        
        [DisplayName("Doc Type"), NotNull]
        [NotMapped]
        [SAPDBFieldName("DocType")]
        [QuickSearch]
        public String? DocType
        {
            get => fields.DocType[this];
            set => fields.DocType[this] = value;
        }
        
        [NotMapped]
        [Hidden]
        public String? DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        } 
        [DisplayName("Doc Date"), NotNull]
        [NotMapped]
        [SAPDBFieldName("DocDate")]
       
        public DateTime? DocDate
        {
            get => fields.DocDate[this];
            set => fields.DocDate[this] = value;
        }

        [DisplayName("Doc Due Date"), NotNull]
        [NotMapped]
        [SAPDBFieldName("DocDueDate")]
        public DateTime? DocDueDate
        {
            get => fields.DocDueDate[this];
            set => fields.DocDueDate[this] = value;
        }

        [DisplayName("Card Code"), NotNull]
        [NotMapped]
        [SAPDBFieldName("CardCode")]
        [QuickSearch]
        public System.String? CardCode
        {
            get => fields.CardCode[this];
            set => fields.CardCode[this] = value;
        }

        [DisplayName("Card Name"), NotNull]
        [NotMapped]
        [SAPDBFieldName("CardName")]
        [QuickSearch]
        public System.String? CardName
        {
            get => fields.CardName[this];
            set => fields.CardName[this] = value;
        }

        [DisplayName("Address"), NotNull]
        [NotMapped]
        [SAPDBFieldName("Address")]
        public System.String? Address
        {
            get => fields.Address[this];
            set => fields.Address[this] = value;
        }

        [DisplayName("Num At Card"), NotNull]
        [NotMapped]
        [SAPDBFieldName("NumAtCard")]
        [QuickSearch]
        public System.String? NumAtCard
        {
            get => fields.NumAtCard[this];
            set => fields.NumAtCard[this] = value;
        }

        [DisplayName("Doc Total"), NotNull]
        [NotMapped]
        [SAPDBFieldName("DocTotal")]
        public double? DocTotal
        {
            get => fields.DocTotal[this];
            set => fields.DocTotal[this] = value;
        }

        //PaidToDate
        [DisplayName("Paid To Date"), NotNull]
        [NotMapped]
        [SAPDBFieldName("PaidToDate")]
        public double? PaidToDate
        {
            get => fields.PaidToDate[this];
            set => fields.PaidToDate[this] = value;
        }
        [DisplayName("BPL_IDAssignedToInvoice")]
        [NotMapped]
        public string BPL_IDAssignedToInvoice
        {
            get => fields.BPL_IDAssignedToInvoice[this];
            set => fields.BPL_IDAssignedToInvoice[this] = value;
        }
        [DisplayName("Document Lines"), NotNull, MasterDetailRelation(foreignKey: "DocEntry")]
        [NotMapped]
        public System.Collections.Generic.List<DocumentLineRow> DocumentLines
        {
            get => fields.DocumentLines[this];
            set => fields.DocumentLines[this] = value;
        }
        public DocumentRow()
            : base()
        {
        }

        public DocumentRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field DocEntry;
            public Int32Field DocNum;
            public StringField DocType; 
            public StringField DBName; 
            public DateTimeField DocDate;
            public DateTimeField DocDueDate;
            public StringField CardCode;
            public StringField CardName;
            public StringField Address;
            public StringField BPL_IDAssignedToInvoice;
            public StringField NumAtCard;
            public DoubleField DocTotal;
            public DoubleField PaidToDate;
            public RowListField<DocumentLineRow> DocumentLines;


        }
    }
}
