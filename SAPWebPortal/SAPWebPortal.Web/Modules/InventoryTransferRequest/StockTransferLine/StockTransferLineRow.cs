using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.InventoryTransferRequest
{
    [ConnectionKey("Default"), Module("InventoryTransferRequest"), ServiceLayer("StockTransferLines")]
    [DisplayName("Stock Transfer Line"), InstanceName("Stock Transfer Line")]
    [ReadPermission("InventoryTransferRequest")]
    
    [ModifyPermission("InventoryTransferRequest")]
    [NotMapped]
    public sealed class StockTransferLineRow : Row<StockTransferLineRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("Line Num"), IdProperty]
        [NotMapped]
        [SAPDBFieldName("LineNum")]
        public Int32? LineNum
        {
            get => fields.LineNum[this];
            set => fields.LineNum[this] = value;
        }

        [DisplayName("Doc Entry")]
        [NotMapped]
        [SAPDBFieldName("DocEntry")]
        public Int32? DocEntry
        {
            get => fields.DocEntry[this];
            set => fields.DocEntry[this] = value;
        }

        [DisplayName("Item Code"), QuickSearch, NameProperty]
        [NotMapped]
        [SAPDBFieldName("ItemCode")]
        public String? ItemCode
        {
            get => fields.ItemCode[this];
            set => fields.ItemCode[this] = value;
        }

        [DisplayName("Item Description")]
        [NotMapped]
        public String? ItemDescription
        {
            get => fields.ItemDescription[this];
            set => fields.ItemDescription[this] = value;
        }

        [DisplayName("Quantity")]
        [NotMapped]
        [SAPDBFieldName("Quantity")]
        public Double? Quantity
        {
            get => fields.Quantity[this];
            set => fields.Quantity[this] = value;
        }

        [DisplayName("Price")]
        [NotMapped]
        [SAPDBFieldName("Price")]
        public Double? Price
        {
            get => fields.Price[this];
            set => fields.Price[this] = value;
        }

        [DisplayName("Currency")]
        [NotMapped]
        public String? Currency
        {
            get => fields.Currency[this];
            set => fields.Currency[this] = value;
        }

        [DisplayName("Rate")]
        [NotMapped]
        public Double? Rate
        {
            get => fields.Rate[this];
            set => fields.Rate[this] = value;
        }

        [DisplayName("Discount Percent")]
        [NotMapped]
        public Double? DiscountPercent
        {
            get => fields.DiscountPercent[this];
            set => fields.DiscountPercent[this] = value;
        }

        [DisplayName("Vendor Num")]
        [NotMapped]
        public String? VendorNum
        {
            get => fields.VendorNum[this];
            set => fields.VendorNum[this] = value;
        }

        [DisplayName("Serial Number")]
        [NotMapped]
        public String? SerialNumber
        {
            get => fields.SerialNumber[this];
            set => fields.SerialNumber[this] = value;
        }

        [DisplayName("To Warehouse Code")]
        [NotMapped]
        [SAPDBFieldName("WhsCode")]

        public String? WarehouseCode
        {
            get => fields.WarehouseCode[this];
            set => fields.WarehouseCode[this] = value;
        }

        [DisplayName("From Warehouse Code")]
        [NotMapped]
        [SAPDBFieldName("FromWhsCod")]
        public String? FromWarehouseCode
        {
            get => fields.FromWarehouseCode[this];
            set => fields.FromWarehouseCode[this] = value;
        }

        [DisplayName("Project Code")]
        [NotMapped]
        [SAPDBFieldName("Project")]
        public String? ProjectCode
        {
            get => fields.ProjectCode[this];
            set => fields.ProjectCode[this] = value;
        }

        [DisplayName("Factor")]
        [NotMapped]
        public Double? Factor
        {
            get => fields.Factor[this];
            set => fields.Factor[this] = value;
        }

        [DisplayName("Factor2")]
        [NotMapped]
        public Double? Factor2
        {
            get => fields.Factor2[this];
            set => fields.Factor2[this] = value;
        }

        [DisplayName("Factor3")]
        [NotMapped]
        public Double? Factor3
        {
            get => fields.Factor3[this];
            set => fields.Factor3[this] = value;
        }

        [DisplayName("Factor4")]
        [NotMapped]
        public Double? Factor4
        {
            get => fields.Factor4[this];
            set => fields.Factor4[this] = value;
        }

        [DisplayName("Distribution Rule")]
        [NotMapped]
        public String? DistributionRule
        {
            get => fields.DistributionRule[this];
            set => fields.DistributionRule[this] = value;
        }

        [DisplayName("Distribution Rule2")]
        [NotMapped]
        public String? DistributionRule2
        {
            get => fields.DistributionRule2[this];
            set => fields.DistributionRule2[this] = value;
        }

        [DisplayName("Distribution Rule3")]
        [NotMapped]
        public String? DistributionRule3
        {
            get => fields.DistributionRule3[this];
            set => fields.DistributionRule3[this] = value;
        }

        [DisplayName("Distribution Rule4")]
        [NotMapped]
        public String? DistributionRule4
        {
            get => fields.DistributionRule4[this];
            set => fields.DistributionRule4[this] = value;
        }

        [DisplayName("Distribution Rule5")]
        [NotMapped]
        public String? DistributionRule5
        {
            get => fields.DistributionRule5[this];
            set => fields.DistributionRule5[this] = value;
        }

        [DisplayName("Use Base Units")]
        [NotMapped]
        public String? UseBaseUnits
        {
            get => fields.UseBaseUnits[this];
            set => fields.UseBaseUnits[this] = value;
        }

        [DisplayName("Measure Unit")]
        [NotMapped]
        public String? MeasureUnit
        {
            get => fields.MeasureUnit[this];
            set => fields.MeasureUnit[this] = value;
        }

        [DisplayName("Units Of Measurment")]
        [NotMapped]
        public Double? UnitsOfMeasurment
        {
            get => fields.UnitsOfMeasurment[this];
            set => fields.UnitsOfMeasurment[this] = value;
        }

        [DisplayName("Base Type")]
        [NotMapped]
        public String? BaseType
        {
            get => fields.BaseType[this];
            set => fields.BaseType[this] = value;
        }

        [DisplayName("Base Line")]
        [NotMapped]
        public Int32? BaseLine
        {
            get => fields.BaseLine[this];
            set => fields.BaseLine[this] = value;
        }

        [DisplayName("Base Entry")]
        [NotMapped]
        public Int32? BaseEntry
        {
            get => fields.BaseEntry[this];
            set => fields.BaseEntry[this] = value;
        }

        [DisplayName("Unit Price")]
        [NotMapped]
        public Double? UnitPrice
        {
            get => fields.UnitPrice[this];
            set => fields.UnitPrice[this] = value;
        }

        [DisplayName("Uo M Entry")]
        [NotMapped]
        public Int32? UoMEntry
        {
            get => fields.UoMEntry[this];
            set => fields.UoMEntry[this] = value;
        }

        [DisplayName("Uo M Code")]
        [NotMapped]
        public String? UoMCode
        {
            get => fields.UoMCode[this];
            set => fields.UoMCode[this] = value;
        }

        [DisplayName("Inventory Quantity")]
        [NotMapped]
        public Double? InventoryQuantity
        {
            get => fields.InventoryQuantity[this];
            set => fields.InventoryQuantity[this] = value;
        }

        [DisplayName("Remaining Open Quantity")]
        [NotMapped]
        public Double? RemainingOpenQuantity
        {
            get => fields.RemainingOpenQuantity[this];
            set => fields.RemainingOpenQuantity[this] = value;
        }

        [DisplayName("Remaining Open Inventory Quantity")]
        [NotMapped]
        public Double? RemainingOpenInventoryQuantity
        {
            get => fields.RemainingOpenInventoryQuantity[this];
            set => fields.RemainingOpenInventoryQuantity[this] = value;
        }

        [DisplayName("Line Status")]
        [NotMapped]
        public String? LineStatus
        {
            get => fields.LineStatus[this];
            set => fields.LineStatus[this] = value;
        }
        [DisplayName("Received Quantity")]
        [NotMapped]
        [SAPDBFieldName("U_RecQty")]
        public Double? U_RecQty
        {
            get => fields.U_RecQty[this];
            set => fields.U_RecQty[this] = value;
        }



        public StockTransferLineRow()
            : base()
        {
        }

        public StockTransferLineRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field LineNum;
            public Int32Field DocEntry;
            public StringField ItemCode;
            public StringField ItemDescription;
            public DoubleField Quantity;
            public DoubleField Price;
            public StringField Currency;
            public DoubleField Rate;
            public DoubleField DiscountPercent;
            public StringField VendorNum;
            public StringField SerialNumber;
            public StringField WarehouseCode;
            public StringField FromWarehouseCode;
            public StringField ProjectCode;
            public DoubleField Factor;
            public DoubleField Factor2;
            public DoubleField Factor3;
            public DoubleField Factor4;
            public StringField DistributionRule;
            public StringField DistributionRule2;
            public StringField DistributionRule3;
            public StringField DistributionRule4;
            public StringField DistributionRule5;
            public StringField UseBaseUnits;
            public StringField MeasureUnit;
            public DoubleField UnitsOfMeasurment;
            public StringField BaseType;
            public Int32Field BaseLine;
            public Int32Field BaseEntry;
            public DoubleField UnitPrice;
            public Int32Field UoMEntry;
            public StringField UoMCode;
            public DoubleField InventoryQuantity;
            public DoubleField RemainingOpenQuantity;
            public DoubleField RemainingOpenInventoryQuantity;
            public StringField LineStatus;
            public DoubleField U_RecQty;
        }
    }
}
