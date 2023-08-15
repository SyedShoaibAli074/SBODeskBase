using Serenity;
using Serenity.ComponentModel;
using Serenity.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using SAPWebPortal.Modules.DropDownEnums;

namespace SAPWebPortal.Default.Forms
{
    [FormScript("Default.BusinessPartner")]
    [BasedOnRow(typeof(BusinessPartnerRow), CheckNames = true)]
    public class BusinessPartnerForm
    {
        [HalfWidth]
        public Int32 Series { get; set; }
        [HalfWidth]
        public string CardCode { get; set; }
        [HalfWidth,Hidden]
        public string DBName { get; set; }
        [HalfWidth, CardTypeEditor]
        public string CardType { get; set; }
        [HalfWidth]
        public string CardName { get; set; }
        [HalfWidth]
        public string GroupCode { get; set; }
        [HalfWidth]
        public string CardForeignName { get; set; }
        [MediumThirdLargeQuarterWidth]
        public decimal CurrentAccountBalance { get; set; }
        [MediumThirdLargeQuarterWidth]
        public decimal OpenDeliveryNotesBalance { get; set; }

        [MediumThirdLargeQuarterWidth]
        public decimal OpenOrdersBalance { get; set; }
        [HalfWidth]
        public string Currency { get; set; }
        [HalfWidth]
        public string FederalTaxID { get; set; }

        [Tab("General")]
        [HalfWidth]
        public string Phone1 { get; set; }
        [HalfWidth]
        public string Phone2 { get; set; }
        [HalfWidth]
        public string MailAddress { get; set; }
        [HalfWidth]
        public string Website { get; set; }
        [HalfWidth]
        public string Fax { get; set; }
        [HalfWidth]
        public string Cellular { get; set; }
        [HalfWidth]
        public Int32 SalesPersonCode { get; set; }
        [Tab("Address")]
        public System.Collections.Generic.List<BPAddressesRow> BPAddresses { get; set; }
        //[HalfWidth]
        [Tab("Payment Terms")]
        public System.Collections.Generic.List<BPPaymentMethodsRow> BPPaymentMethods { get; set; }
        [HalfWidth]
        public Int32 PriceListNum { get; set; }

        [Tab("Attachments")]
        public StringField FatherCard;
        // public System.Collections.Generic.List<ContactEmployeesRow> ContactEmployees { get; set; }

    }
}