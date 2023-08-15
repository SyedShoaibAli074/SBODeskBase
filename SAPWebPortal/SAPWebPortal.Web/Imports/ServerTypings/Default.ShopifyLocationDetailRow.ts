namespace SAPWebPortal.Default {
    export interface ShopifyLocationDetailRow {
        Id?: number;
        ShopifySettingsId?: number;
        SapWarhouseCode?: string;
        ShopifyLocationCode?: string;
        ShopifySettingsSapDatabase?: string;
        ShopifySettingsToken?: string;
        ShopifySettingsApiKey?: string;
        ShopifySettingsApiKeySecret?: string;
        ShopifySettingsCreateDate?: string;
        ShopifySettingsCreatedBy?: string;
        ShopifySettingsApiVersion?: string;
        ShopifySettingsStoreName?: string;
        ShopifySettingsApiBaseUrl?: string;
    }

    export namespace ShopifyLocationDetailRow {
        export const idProperty = 'Id';
        export const nameProperty = 'SapWarhouseCode';
        export const localTextPrefix = 'Default.ShopifyLocationDetail';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            ShopifySettingsId = "ShopifySettingsId",
            SapWarhouseCode = "SapWarhouseCode",
            ShopifyLocationCode = "ShopifyLocationCode",
            ShopifySettingsSapDatabase = "ShopifySettingsSapDatabase",
            ShopifySettingsToken = "ShopifySettingsToken",
            ShopifySettingsApiKey = "ShopifySettingsApiKey",
            ShopifySettingsApiKeySecret = "ShopifySettingsApiKeySecret",
            ShopifySettingsCreateDate = "ShopifySettingsCreateDate",
            ShopifySettingsCreatedBy = "ShopifySettingsCreatedBy",
            ShopifySettingsApiVersion = "ShopifySettingsApiVersion",
            ShopifySettingsStoreName = "ShopifySettingsStoreName",
            ShopifySettingsApiBaseUrl = "ShopifySettingsApiBaseUrl"
        }
    }
}
