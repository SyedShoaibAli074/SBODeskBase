namespace SAPWebPortal.Default {
    export interface BusinessPartnerForm {
        Series: SelectCodeNameValueEditor;
        CardCode: Serenity.StringEditor;
        DBName: Serenity.StringEditor;
        CardType: Modules.DropDownEnums.CardTypeEditor;
        CardName: Serenity.StringEditor;
        GroupCode: SelectCodeNameValueEditor;
        CardForeignName: Serenity.StringEditor;
        CurrentAccountBalance: Serenity.DecimalEditor;
        OpenDeliveryNotesBalance: Serenity.DecimalEditor;
        OpenOrdersBalance: Serenity.DecimalEditor;
        Currency: SelectCodeNameValueEditor;
        FederalTaxID: Serenity.StringEditor;
        Phone1: Serenity.StringEditor;
        Phone2: Serenity.StringEditor;
        MailAddress: Serenity.StringEditor;
        Website: Serenity.StringEditor;
        Fax: Serenity.StringEditor;
        Cellular: Serenity.StringEditor;
        SalesPersonCode: SelectCodeNameValueEditor;
        BPAddresses: BPAddressesEditor;
        BPPaymentMethods: BPPaymentMethodsEditor;
        PriceListNum: SelectCodeNameValueEditor;
    }

    export class BusinessPartnerForm extends Serenity.PrefixedContext {
        static formKey = 'Default.BusinessPartner';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!BusinessPartnerForm.init)  {
                BusinessPartnerForm.init = true;

                var s = Serenity;
                var w0 = SelectCodeNameValueEditor;
                var w1 = s.StringEditor;
                var w2 = Modules.DropDownEnums.CardTypeEditor;
                var w3 = s.DecimalEditor;
                var w4 = BPAddressesEditor;
                var w5 = BPPaymentMethodsEditor;

                Q.initFormType(BusinessPartnerForm, [
                    'Series', w0,
                    'CardCode', w1,
                    'DBName', w1,
                    'CardType', w2,
                    'CardName', w1,
                    'GroupCode', w0,
                    'CardForeignName', w1,
                    'CurrentAccountBalance', w3,
                    'OpenDeliveryNotesBalance', w3,
                    'OpenOrdersBalance', w3,
                    'Currency', w0,
                    'FederalTaxID', w1,
                    'Phone1', w1,
                    'Phone2', w1,
                    'MailAddress', w1,
                    'Website', w1,
                    'Fax', w1,
                    'Cellular', w1,
                    'SalesPersonCode', w0,
                    'BPAddresses', w4,
                    'BPPaymentMethods', w5,
                    'PriceListNum', w0
                ]);
            }
        }
    }
}
