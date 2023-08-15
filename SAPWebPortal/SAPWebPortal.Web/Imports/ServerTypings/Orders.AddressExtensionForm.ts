namespace SAPWebPortal.Orders {
    export interface AddressExtensionForm {
        ShipToStreet: Serenity.StringEditor;
        ShipToStreetNo: Serenity.StringEditor;
        ShipToBlock: Serenity.StringEditor;
        ShipToBuilding: Serenity.StringEditor;
        ShipToCity: Serenity.StringEditor;
        ShipToZipCode: Serenity.StringEditor;
        ShipToCounty: Serenity.StringEditor;
        ShipToState: Serenity.StringEditor;
        ShipToCountry: Default.SelectCodeNameValueEditor;
        ShipToAddressType: Default.BPAddressTypeEditor;
        BillToStreet: Serenity.StringEditor;
        BillToStreetNo: Serenity.StringEditor;
        BillToBlock: Serenity.StringEditor;
        BillToBuilding: Serenity.StringEditor;
        BillToCity: Serenity.StringEditor;
        BillToZipCode: Serenity.StringEditor;
        BillToCounty: Serenity.StringEditor;
        BillToState: Serenity.StringEditor;
        BillToCountry: Serenity.StringEditor;
        BillToAddressType: Serenity.StringEditor;
        ShipToGlobalLocationNumber: Serenity.StringEditor;
        BillToGlobalLocationNumber: Serenity.StringEditor;
        ShipToAddress2: Serenity.StringEditor;
        ShipToAddress3: Serenity.StringEditor;
        BillToAddress2: Serenity.StringEditor;
        BillToAddress3: Serenity.StringEditor;
    }

    export class AddressExtensionForm extends Serenity.PrefixedContext {
        static formKey = 'Orders.AddressExtension';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AddressExtensionForm.init)  {
                AddressExtensionForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = Default.SelectCodeNameValueEditor;
                var w2 = Default.BPAddressTypeEditor;

                Q.initFormType(AddressExtensionForm, [
                    'ShipToStreet', w0,
                    'ShipToStreetNo', w0,
                    'ShipToBlock', w0,
                    'ShipToBuilding', w0,
                    'ShipToCity', w0,
                    'ShipToZipCode', w0,
                    'ShipToCounty', w0,
                    'ShipToState', w0,
                    'ShipToCountry', w1,
                    'ShipToAddressType', w2,
                    'BillToStreet', w0,
                    'BillToStreetNo', w0,
                    'BillToBlock', w0,
                    'BillToBuilding', w0,
                    'BillToCity', w0,
                    'BillToZipCode', w0,
                    'BillToCounty', w0,
                    'BillToState', w0,
                    'BillToCountry', w0,
                    'BillToAddressType', w0,
                    'ShipToGlobalLocationNumber', w0,
                    'BillToGlobalLocationNumber', w0,
                    'ShipToAddress2', w0,
                    'ShipToAddress3', w0,
                    'BillToAddress2', w0,
                    'BillToAddress3', w0
                ]);
            }
        }
    }
}
