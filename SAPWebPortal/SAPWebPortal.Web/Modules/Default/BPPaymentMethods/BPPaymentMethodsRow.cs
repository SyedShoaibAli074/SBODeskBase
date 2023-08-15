using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default")/*, ServiceLayer("OrdersLine")*/]
    [DisplayName("Payment Methods"), InstanceName("Payment Methods")]
    [ReadPermission("Administration:DefaultGeneral")]
    [ModifyPermission("Administration:DefaultGeneral")]
    [NotMapped]
    public sealed class BPPaymentMethodsRow : Row<BPPaymentMethodsRow.RowFields>, IIdRow, INameRow
    {
        [DisplayName("ID"), Identity, IdProperty, NotMapped, NameProperty]
        public Int32? DetailID
        {
            get => fields.DetailID[this];
            set => fields.DetailID[this] = value;
        }
        [DisplayName("Card Code"), Size(10),Visible(false), QuickSearch]
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
        [DisplayName("Payment Method Code"), Size(255), NotMapped, SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT DISTINCT T0.""PayMethCod"", T0.""Descript"" FROM ""OPYM"" T0")]
        public string PaymentMethodCode
        {
            get => fields.PaymentMethodCode[this];
            set => fields.PaymentMethodCode[this] = value;
        }
      
        public BPPaymentMethodsRow()
            : base()
        {
        }

        public BPPaymentMethodsRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field DetailID;
            public StringField BPCode;
            public StringField DBName;
            public StringField PaymentMethodCode;
          
        }
    }
}
