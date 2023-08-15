namespace SAPWebPortal.Default {
    export interface ShopifySettingsForm {
        StoreName: Serenity.StringEditor;
        SAPStoreName: Serenity.StringEditor;
        ApiVersion: Serenity.StringEditor;
        SapDatabase: Serenity.LookupEditor;
        Token: Serenity.StringEditor;
        ApiKey: Serenity.StringEditor;
        ApiKeySecret: Serenity.StringEditor;
        ApiBaseURL: Serenity.StringEditor;
        CreateDate: Serenity.DateEditor;
        CreatedBy: Serenity.LookupEditor;
        ShopifySettingsDetailList: ShopifySettingsDetailEditor;
        ShopifyLocationDetailList: ShopifyLocationDetailEditor;
    }

    export class ShopifySettingsForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ShopifySettings';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ShopifySettingsForm.init)  {
                ShopifySettingsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;
                var w2 = s.DateEditor;
                var w3 = ShopifySettingsDetailEditor;
                var w4 = ShopifyLocationDetailEditor;

                Q.initFormType(ShopifySettingsForm, [
                    'StoreName', w0,
                    'SAPStoreName', w0,
                    'ApiVersion', w0,
                    'SapDatabase', w1,
                    'Token', w0,
                    'ApiKey', w0,
                    'ApiKeySecret', w0,
                    'ApiBaseURL', w0,
                    'CreateDate', w2,
                    'CreatedBy', w1,
                    'ShopifySettingsDetailList', w3,
                    'ShopifyLocationDetailList', w4
                ]);
            }
        }
    }
}
