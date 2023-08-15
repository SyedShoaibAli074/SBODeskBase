namespace SAPWebPortal.Default {
    export interface ShopifySettingsRow {
        Id?: number;
        ApiVersion?: string;
        StoreName?: string;
        SAPStoreName?: string;
        SapDatabase?: string;
        Token?: string;
        ApiKey?: string;
        ApiKeySecret?: string;
        ApiBaseURL?: string;
        CreateDate?: string;
        CreatedBy?: string;
        ShopifySettingsDetailList?: ShopifySettingsDetailRow[];
        ShopifyLocationDetailList?: ShopifyLocationDetailRow[];
    }

    export namespace ShopifySettingsRow {
        export const idProperty = 'Id';
        export const nameProperty = 'StoreName';
        export const localTextPrefix = 'Default.ShopifySettings';
        export const lookupKey = 'Default.ShopifySettings';

        export function getLookup(): Q.Lookup<ShopifySettingsRow> {
            return Q.getLookup<ShopifySettingsRow>('Default.ShopifySettings');
        }
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            ApiVersion = "ApiVersion",
            StoreName = "StoreName",
            SAPStoreName = "SAPStoreName",
            SapDatabase = "SapDatabase",
            Token = "Token",
            ApiKey = "ApiKey",
            ApiKeySecret = "ApiKeySecret",
            ApiBaseURL = "ApiBaseURL",
            CreateDate = "CreateDate",
            CreatedBy = "CreatedBy",
            ShopifySettingsDetailList = "ShopifySettingsDetailList",
            ShopifyLocationDetailList = "ShopifyLocationDetailList"
        }
    }
}
