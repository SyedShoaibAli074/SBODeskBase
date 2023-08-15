namespace SAPWebPortal.Default {
    export interface ShopifySettingsDetailRow {
        Id?: number;
        ShopifySettingsId?: number;
        ShopifySubSettingsId?: number;
        ShopifySubSettingsSapValue?: string;
        ShopifySettingsSapDatabase?: string;
        ShopifySettingsToken?: string;
        ShopifySettingsApiKey?: string;
        ShopifySettingsApiKeySecret?: string;
        ShopifySettingsCreateDate?: string;
        ShopifySettingsCreatedBy?: string;
        ShopifySubSettingsName?: string;
        ShopifySubSettingsDescription?: string;
    }

    export namespace ShopifySettingsDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'ShopifySubSettingsSapValue';
        export const localTextPrefix = 'Default.ShopifySettingsDetail';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            ShopifySettingsId = "ShopifySettingsId",
            ShopifySubSettingsId = "ShopifySubSettingsId",
            ShopifySubSettingsSapValue = "ShopifySubSettingsSapValue",
            ShopifySettingsSapDatabase = "ShopifySettingsSapDatabase",
            ShopifySettingsToken = "ShopifySettingsToken",
            ShopifySettingsApiKey = "ShopifySettingsApiKey",
            ShopifySettingsApiKeySecret = "ShopifySettingsApiKeySecret",
            ShopifySettingsCreateDate = "ShopifySettingsCreateDate",
            ShopifySettingsCreatedBy = "ShopifySettingsCreatedBy",
            ShopifySubSettingsName = "ShopifySubSettingsName",
            ShopifySubSettingsDescription = "ShopifySubSettingsDescription"
        }
    }
}
