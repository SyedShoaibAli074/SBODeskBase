namespace SAPWebPortal.Default {
    export interface ShopifyWebkookSettingsForm {
        WebhookId: Serenity.StringEditor;
        ShopifyWebhookTopic: Serenity.StringEditor;
        ShopifyStore: Serenity.LookupEditor;
        WebhookUrl: Serenity.TextAreaEditor;
        CreateDate: Serenity.DateEditor;
        CreatedBy: Serenity.LookupEditor;
    }

    export class ShopifyWebkookSettingsForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ShopifyWebkookSettings';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ShopifyWebkookSettingsForm.init)  {
                ShopifyWebkookSettingsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.LookupEditor;
                var w2 = s.TextAreaEditor;
                var w3 = s.DateEditor;

                Q.initFormType(ShopifyWebkookSettingsForm, [
                    'WebhookId', w0,
                    'ShopifyWebhookTopic', w0,
                    'ShopifyStore', w1,
                    'WebhookUrl', w2,
                    'CreateDate', w3,
                    'CreatedBy', w1
                ]);
            }
        }
    }
}
