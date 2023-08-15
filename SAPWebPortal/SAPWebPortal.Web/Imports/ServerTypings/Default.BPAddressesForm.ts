namespace SAPWebPortal.Default {
    export interface BPAddressesForm {
        DBName: Serenity.StringEditor;
        AddressType: BPAddressTypeEditor;
        AddressName: Serenity.StringEditor;
        Street: Serenity.StringEditor;
        Block: Serenity.StringEditor;
        ZipCode: Serenity.StringEditor;
        City: Serenity.StringEditor;
        County: Serenity.StringEditor;
        Country: SelectCodeNameValueEditor;
        State: SelectCodeNameValueEditor;
    }

    export class BPAddressesForm extends Serenity.PrefixedContext {
        static formKey = 'Default.BPAddresses';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!BPAddressesForm.init)  {
                BPAddressesForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = BPAddressTypeEditor;
                var w2 = SelectCodeNameValueEditor;

                Q.initFormType(BPAddressesForm, [
                    'DBName', w0,
                    'AddressType', w1,
                    'AddressName', w0,
                    'Street', w0,
                    'Block', w0,
                    'ZipCode', w0,
                    'City', w0,
                    'County', w0,
                    'Country', w2,
                    'State', w2
                ]);
            }
        }
    }
}
