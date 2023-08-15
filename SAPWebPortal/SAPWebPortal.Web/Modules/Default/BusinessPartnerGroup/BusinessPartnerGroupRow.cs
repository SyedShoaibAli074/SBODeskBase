using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default"), ServiceLayer("SAPB1.BusinessPartnerGroups")]
    [DisplayName("Business Partner Group"), InstanceName("Business Partner Group")]
    [ReadPermission("Administration:BusinessPartnerGroup")]
    [ModifyPermission("Administration:BusinessPartnerGroup")]
    [NotMapped]
    [LookupScript]
    public sealed class BusinessPartnerGroupRow : Row<BusinessPartnerGroupRow.RowFields>, IIdRow
    {
        [DisplayName("Code"), NotNull, IdProperty]
        [NotMapped]
        public System.Int32? Code
        {
            get => fields.Code[this];
            set => fields.Code[this] = value;
        }

        [DisplayName("Name"), NotNull,NameProperty]
        [NotMapped]
        public System.String? Name
        {
            get => fields.Name[this];
            set => fields.Name[this] = value;
        }

        [DisplayName("Type"), NotNull]
        [NotMapped]
        public String? Type
        {
            get => fields.Type[this];
            set => fields.Type[this] = value;
        }

        

        public BusinessPartnerGroupRow()
            : base()
        {
        }

        public BusinessPartnerGroupRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field Code;
            public StringField Name;
            public StringField Type;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.GLAccountAdvancedRule]Field GlAccountAdvancedRules;
            //public System.Collections.ObjectModel.Collection`1[SAPB1.BusinessPartner]Field BusinessPartners;
        }
    }
}
