namespace SAPWebPortal.Default {
    export interface ShopifySettingsDetailForm {
        ShopifySubSettingsId: Serenity.LookupEditor;
        ShopifySubSettingsSapValue: Serenity.StringEditor;
    }

    export class ShopifySettingsDetailForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ShopifySettingsDetail';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ShopifySettingsDetailForm.init)  {
                ShopifySettingsDetailForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;

                Q.initFormType(ShopifySettingsDetailForm, [
                    'ShopifySubSettingsId', w0,
                    'ShopifySubSettingsSapValue', w1
                ]);
            }
        }
    }
}
