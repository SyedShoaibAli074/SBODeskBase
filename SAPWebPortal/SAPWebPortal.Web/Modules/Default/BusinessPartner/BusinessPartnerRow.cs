using ABiT_CHTPortalCore.Lab;
using Newtonsoft.Json.Converters;
using SAPWebPortal.Common.PermissionsKeys;
using SAPWebPortal.Modules.DropDownEnums;
using SAPWebPortal.Web.Modules.Common.Attributes;
using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System;
using System.ComponentModel;
using System.IO;
using System.Text.Json.Serialization;

namespace SAPWebPortal.Default
{
    [ConnectionKey("Default"), Module("Default")/*, TableName("[dbo].[BusinessPartner]")*/]
    [DisplayName("Business Partner"), InstanceName("Business Partner")]
    [InsertPermission(MasterDataPermissionKeys.BusinessPartners.Insert)]
    [ModifyPermission(MasterDataPermissionKeys.BusinessPartners.Modify)]
    [DeletePermission(MasterDataPermissionKeys.BusinessPartners.Delete)]
    [ReadPermission(MasterDataPermissionKeys.BusinessPartners.View)]
    [ServiceLayer("BusinessPartners")]
    [LookupScript("Default.BusinessPartner")]
    [NotMapped]
    public sealed class BusinessPartnerRow : Row<BusinessPartnerRow.RowFields>, IIdRow, INameRow
    {
        //[DisplayName("Internal Number"), Identity, IdProperty,NotMapped,SAPInternalNumber]
        //public long? InternalCode
        //{
        //    get => fields.InternalCode[this];
        //    set => fields.InternalCode[this] = value;
        //}

        //[SortOrder(1), DisplayName("Card Code"), Size(255), NotNull, QuickSearch, NotMapped, SAPPrimaryKey, Identity, IdProperty]

        [DisplayName("DBName"), Size(255), NotMapped,RemoveFromEntity]
        public string DBName
        {
            get => fields.DBName[this];
            set => fields.DBName[this] = value;
        }
        [DisplayName("U_source"), Size(255), NotMapped]
        public string U_source
        {
            get => fields.U_source[this];
            set => fields.U_source[this] = value;
        }
        [DisplayName("DownPaymentClearAct"), Size(255), NotMapped]
        public string DownPaymentClearAct
        {
            get => fields.DownPaymentClearAct[this];
            set => fields.DownPaymentClearAct[this] = value;
        }
        [DisplayName("DownPaymentInterimAccount"), Size(255), NotMapped]
        public string DownPaymentInterimAccount
        {
            get => fields.DownPaymentInterimAccount[this];
            set => fields.DownPaymentInterimAccount[this] = value;
        }

        [SortOrder(1), DisplayName("BP Code"), Size(255), NotNull, QuickSearch, NotMapped, SAPPrimaryKey, IdProperty,SAPDBFieldName("CardCode")]
        public string CardCode
        {
            get => fields.CardCode[this];
            set => fields.CardCode[this] = value;
        }

        [DisplayName("BP Name"), Size(255), NotMapped, QuickSearch, NameProperty,SAPDBFieldName("CardName")]
        public string CardName
        {
            get => fields.CardName[this];
            set => fields.CardName[this] = value;
        }
        //todo:@kamran add card type enum SAPB1.BoCardTypes 

        [DisplayName("Type"), Size(255), NotMapped, CardTypeEditor,DefaultValue("cCustomer"), QuickSearch, SAPDBFieldName("CardType")]
        public string CardType
        {
            get => fields.CardType[this];
            set => fields.CardType[this] = value;
        }
        [DisplayName("Foreign Name"), Size(255), NotMapped,SAPDBFieldName("CardFName")]
        public string CardForeignName
        {
            get => fields.CardForeignName[this];
            set => fields.CardForeignName[this] = value;
        }//select "Series", "SeriesName","DfltSeries","IsManual" from  nnm1 inner join onnm on nnm1."ObjectCode" = onnm."ObjectCode" and NNM1."DocSubType" = onnm."DocSubType" where nnm1."Locked" = 'N' and nnm1."ObjectCode" = '{0}'
        [DisplayName("Series"), Size(255), NotMapped , SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"select ""Series"", ""SeriesName"",""DfltSeries"",""IsManual"" from  nnm1 inner join onnm on nnm1.""ObjectCode"" = onnm.""ObjectCode"" and NNM1.""DocSubType"" = onnm.""DocSubType"" where nnm1.""Locked"" = 'N' and nnm1.""ObjectCode"" = '2' and nnm1.""DocSubType""='@CardType'")]
         public Int32? Series
        {
           
            get => fields.Series[this];
            set => fields.Series[this] = value;
        }

        [DisplayName("Account Balance"), Size(255), NotMapped, ReadOnly(true), SAPDBFieldName("Balance")]
        public decimal? CurrentAccountBalance
        {
            get => fields.CurrentAccountBalance[this];
            set => fields.CurrentAccountBalance[this] = value;
        }
        [DisplayName("Deliveries"), Size(255), NotMapped, ReadOnly(true)]
        public decimal? OpenDeliveryNotesBalance
        {
            get => fields.CurrentAccountBalance[this];
            set => fields.CurrentAccountBalance[this] = value;
        }
        [DisplayName("Orders"), Size(255), NotMapped,ReadOnly(true)]
        public decimal? OpenOrdersBalance
        {
            get => fields.CurrentAccountBalance[this];
            set => fields.CurrentAccountBalance[this] = value;
        }
        [DisplayName("Group"), Size(255), NotMapped, SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"select ""GroupCode"",""GroupName"" from OCRG where ""GroupType""='@CardType' " )]
        public String GroupCode
        {
            get => fields.GroupCode[this];
            set => fields.GroupCode[this] = value;
        }
        [DisplayName("Currency"), Size(255), NotMapped, SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""CurrCode"", CONCAT(CONCAT(""CurrCode"", ' - '),""CurrName"") AS ""CurrName"" FROM OCRN")]
        public String Currency
        {
            get => fields.Currency[this];
            set => fields.Currency[this] = value;
        }
        [DisplayName("Notes"), Size(255), NotMapped]
        public String Notes
        {
            get => fields.Notes[this];
            set => fields.Notes[this] = value;
        }
        [DisplayName("EmailAddress"), Size(255), NotMapped]
        public String EmailAddress
        {
            get => fields.EmailAddress[this];
            set => fields.EmailAddress[this] = value;
        }
        [DisplayName("TotalSpent"), Size(255), NotMapped]
        public String U_TotalSpent
        {
            get => fields.U_TotalSpent[this];
            set => fields.U_TotalSpent[this] = value;
        }
        [DisplayName("TotalOrders"), Size(255), NotMapped]
        public String U_TotalOrders
        {
            get => fields.U_TotalOrders[this];
            set => fields.U_TotalOrders[this] = value;
        }
        [DisplayName("ContactPerson"), Size(255), NotMapped]
        public String ContactPerson
        {
            get => fields.ContactPerson[this];
            set => fields.ContactPerson[this] = value;
        }
        [DisplayName("Addresses"), MasterDetailRelation(foreignKey: "BPCode"),BPAddressesEditor, NotMapped]
        public System.Collections.Generic.List<BPAddressesRow> BPAddresses
        {
            get => fields.BPAddresses[this];
            set => fields.BPAddresses[this] = value;
        }
        [DisplayName("Payment Methods"), MasterDetailRelation(foreignKey: "BPCode"), NotMapped, BPPaymentMethodsEditor]
        public System.Collections.Generic.List<BPPaymentMethodsRow> BPPaymentMethods
        {
            get => fields.BPPaymentMethods[this];
            set => fields.BPPaymentMethods[this] = value;
        }
        [DisplayName("Phone 1"),  Size(255), NotMapped]
        public String Phone1
        {
            get => fields.Phone1[this];
            set => fields.Phone1[this] = value;
        }
        [DisplayName("Phone 2"), Size(255), NotMapped]
        public String Phone2
        {
            get => fields.Phone2[this];
            set => fields.Phone2[this] = value;
        }
        [DisplayName("E-Mail Address"),  Size(255), NotMapped]
        public String MailAddress
        {
            get => fields.MailAddress[this];
            set => fields.MailAddress[this] = value;
        }
        [DisplayName("Fax"),  Size(255), NotMapped]
        public String Fax
        {
            get => fields.Fax[this];
            set => fields.Fax[this] = value;
        }
        [DisplayName("Federal Tax ID"),  Size(255), NotMapped]
        public String FederalTaxID
        {
            get => fields.FederalTaxID[this];
            set => fields.FederalTaxID[this] = value;
        }
        [DisplayName("Website"),  Size(255), NotMapped]
        public String Website
        {
            get => fields.Website[this];
            set => fields.Website[this] = value;
        } 
        [DisplayName("Cellular "),  Size(255),NotMapped]
        public String Cellular
        {
            get => fields.Cellular[this];
            set => fields.Cellular[this] = value;
        }
        [DisplayName("FatherCard"), Visible(false), Size(255), NotMapped]
        public String FatherCard
        {
            get => fields.FatherCard[this];
            set => fields.FatherCard[this] = value;
        }
        [DisplayName("Sales Employee"), NotNull, SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""SlpCode"", ""SlpName"" FROM OSLP WHERE ""Active"" ='Y'")]
        [NotMapped]
        public Int32? SalesPersonCode
        {
            get => fields.SalesPersonCode[this];
            set => fields.SalesPersonCode[this] = value;
        }
        [DisplayName("Price List"), NotNull, SAPWebPortal.Web.Modules.Common.Attributes.SelectCodeNameValueEditor(@$"SELECT ""ListNum"" ,CONCAT(CONCAT(""ListNum"",' - '),""ListName"") AS ""ListName"" FROM OPLN T0 WHERE ""ValidFor"" ='Y'")]
        [NotMapped]
        public Int32? PriceListNum
        {
            get => fields.PriceListNum[this];
            set => fields.PriceListNum[this] = value;
        }
        //[DisplayName("FatherCard"), Visible(false), Size(255), NotMapped]

        //public String FormFieldName
        //{
        //    get => fields.FormFieldName[this];
        //    set => fields.FormFieldName[this] = value;
        //}
        //[DisplayName("Contact Employees"), MasterDetailRelation(foreignKey: "CardCode"), NotMapped, ContactEmployeesEditor]
        //public System.Collections.Generic.List<ContactEmployeesRow> ContactEmployees
        //{
        //    get => fields.ContactEmployees[this];
        //    set => fields.ContactEmployees[this] = value;
        //}
        public BusinessPartnerRow()
            : base()
        {
            SAPB1.BusinessPartner partner = new SAPB1.BusinessPartner(); 
        }

        public BusinessPartnerRow(RowFields fields)
            : base(fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            //public Int64Field InternalCode;
            public Int32Field Series;
            public StringField CardCode;
            public StringField CardName;
            public StringField CardForeignName;
            public StringField CardType;
            public DecimalField CurrentAccountBalance;
            public DecimalField OpenDeliveryNotesBalance;
            public DecimalField OpenOrdersBalance;
            public StringField GroupCode;
            public StringField Currency;
            public RowListField<BPAddressesRow> BPAddresses;
            public RowListField<BPPaymentMethodsRow> BPPaymentMethods;
            public StringField Phone1;
            public StringField Phone2; 
            public StringField Cellular;
            public Int32Field SalesPersonCode;  
            public Int32Field PriceListNum;
            public StringField MailAddress;
            public StringField Fax;
            public StringField DownPaymentInterimAccount;
            public StringField DownPaymentClearAct;
            public StringField U_source;
            public StringField FederalTaxID;
            public StringField Website;
            public StringField FatherCard;
            public StringField DBName;
            public StringField ContactPerson;
            public StringField Notes;

            public StringField EmailAddress;
            public StringField U_TotalSpent;
            public StringField U_TotalOrders;

          //  public StringField FormFieldName;
            // public RowListField<ContactEmployeesRow> ContactEmployees;
        }
    }
}
