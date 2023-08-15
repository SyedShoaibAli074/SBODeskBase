using System.Collections.Generic;

namespace HelperWebSL.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BPAccountReceivablePaybleCollection
    {
        public string AccountType { get; set; }
        public string AccountCode { get; set; }
        public string BPCode { get; set; }
    }

    public class BPAddress
    {
        public string AddressName { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string FederalTaxID { get; set; }
        public object TaxCode { get; set; }
        public string BuildingFloorRoom { get; set; }
        public string AddressType { get; set; }
        public object AddressName2 { get; set; }
        public object AddressName3 { get; set; }
        public object TypeOfAddress { get; set; }
        public object StreetNo { get; set; }
        public string BPCode { get; set; }
        public int RowNum { get; set; }
        public object GlobalLocationNumber { get; set; }
        public object Nationality { get; set; }
        public object TaxOffice { get; set; }
        public object GSTIN { get; set; }
        public object GstType { get; set; }
        public string CreateDate { get; set; }
        public string CreateTime { get; set; }
        public object MYFType { get; set; }
        public string TaasEnabled { get; set; }
    }

    public class BPBankAccount
    {
        public int LogInstance { get; set; }
        public object UserNo4 { get; set; }
        public string BPCode { get; set; }
        public object County { get; set; }
        public object State { get; set; }
        public object UserNo2 { get; set; }
        public object IBAN { get; set; }
        public object ZipCode { get; set; }
        public string City { get; set; }
        public object Block { get; set; }
        public string Branch { get; set; }
        public string Country { get; set; }
        public object Street { get; set; }
        public object ControlKey { get; set; }
        public object UserNo3 { get; set; }
        public string BankCode { get; set; }
        public string AccountNo { get; set; }
        public object UserNo1 { get; set; }
        public int InternalKey { get; set; }
        public string BuildingFloorRoom { get; set; }
        public object BIK { get; set; }
        public object AccountName { get; set; }
        public object CorrespondentAccount { get; set; }
        public object Phone { get; set; }
        public object Fax { get; set; }
        public string CustomerIdNumber { get; set; }
        public object ISRBillerID { get; set; }
        public int ISRType { get; set; }
        public object BICSwiftCode { get; set; }
        public object ABARoutingNumber { get; set; }
        public object MandateID { get; set; }
        public object SignatureDate { get; set; }
        public object MandateExpDate { get; set; }
        public object SEPASeqType { get; set; }
    }

    public class BPIntrastatExtension
    {
        public string CardCode { get; set; }
        public object TransportMode { get; set; }
        public object Incoterms { get; set; }
        public object NatureOfTransactions { get; set; }
        public object StatisticalProcedure { get; set; }
        public object CustomsProcedure { get; set; }
        public object PortOfEntryOrExit { get; set; }
        public object DomesticOrForeignID { get; set; }
        public string IntrastatRelevant { get; set; }
    }

    public class BPPaymentMethod
    {
        public string PaymentMethodCode { get; set; }
        public int RowNumber { get; set; }
        public string BPCode { get; set; }
    }

    public class ContactEmployee
    {
        public string CardCode { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Phone1 { get; set; }
        public object Phone2 { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string E_Mail { get; set; }
        public object Pager { get; set; }
        public object Remarks1 { get; set; }
        public object Remarks2 { get; set; }
        public object Password { get; set; }
        public int InternalCode { get; set; }
        public object PlaceOfBirth { get; set; }
        public object DateOfBirth { get; set; }
        public string Gender { get; set; }
        public object Profession { get; set; }
        public string Title { get; set; }
        public object CityOfBirth { get; set; }
        public string Active { get; set; }
        public string FirstName { get; set; }
        public object MiddleName { get; set; }
        public string LastName { get; set; }
        public object EmailGroupCode { get; set; }
        public string BlockSendingMarketingContent { get; set; }
        public string CreateDate { get; set; }
        public string CreateTime { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateTime { get; set; }
        public object ConnectedAddressName { get; set; }
        public object ConnectedAddressType { get; set; }
        public List<object> ContactEmployeeBlockSendingMarketingContents { get; set; }
    }

    public class BusinessPartners
    {
        //public Int64Field InternalCode;
        public int Series { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string CardForeignName { get; set; }
        public string CardType { get; set; }
        public decimal CurrentAccountBalance { get; set; }
        public decimal OpenDeliveryNotesBalance { get; set; }
        public decimal OpenOrdersBalance { get; set; }
        public string GroupCode { get; set; }
        public string Currency { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Cellular { get; set; }
        public int SalesPersonCode { get; set; }
        public int PriceListNum { get; set; }
        public string MailAddress { get; set; }
        public string Fax { get; set; }
        public string FederalTaxID { get; set; }
        public string Website { get; set; }
        public string FatherCard { get; set; }

        //  public StringField FormFieldName;
        // public RowListField<ContactEmployeesRow> ContactEmployees;
    }


}