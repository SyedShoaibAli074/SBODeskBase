namespace SAPWebPortal.Default {
    export interface ShopifySubSettingsForm {
        Name: Serenity.StringEditor;
        Description: Serenity.StringEditor;
    }

    export class ShopifySubSettingsForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ShopifySubSettings';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ShopifySubSettingsForm.init)  {
                ShopifySubSettingsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(ShopifySubSettingsForm, [
                    'Name', w0,
                    'Description', w0
                ]);
            }
        }
    }
}
