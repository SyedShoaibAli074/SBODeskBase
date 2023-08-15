namespace SAPWebPortal.Default {
    export interface ShopifyWebkookSettingsRow {
        Id?: number;
        ShopifyWebhookTopic?: string;
        WebhookUrl?: string;
        ShopifyStore?: string;
        WebhookId?: string;
        CreateDate?: string;
        CreatedBy?: string;
    }

    export namespace ShopifyWebkookSettingsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ShopifyWebhookTopic';
        export const localTextPrefix = 'Default.ShopifyWebkookSettings';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            ShopifyWebhookTopic = "ShopifyWebhookTopic",
            WebhookUrl = "WebhookUrl",
            ShopifyStore = "ShopifyStore",
            WebhookId = "WebhookId",
            CreateDate = "CreateDate",
            CreatedBy = "CreatedBy"
        }
    }
}
