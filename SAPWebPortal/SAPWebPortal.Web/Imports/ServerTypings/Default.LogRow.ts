namespace SAPWebPortal.Default {
    export interface LogRow {
        Id?: number;
        UDateTime?: string;
        UDirection?: string;
        UError?: string;
        ShopifyPayload?: string;
        UXml?: string;
        URequest?: string;
        UResponse?: string;
        UObjType?: string;
        UVersion?: number[];
        UKey?: string;
        UDocNum?: string;
        ShopifyId?: string;
        DocIds?: string;
        Updated?: number;
    }

    export namespace LogRow {
        export const idProperty = 'Id';
        export const nameProperty = 'UDirection';
        export const localTextPrefix = 'Default.Log';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            UDateTime = "UDateTime",
            UDirection = "UDirection",
            UError = "UError",
            ShopifyPayload = "ShopifyPayload",
            UXml = "UXml",
            URequest = "URequest",
            UResponse = "UResponse",
            UObjType = "UObjType",
            UVersion = "UVersion",
            UKey = "UKey",
            UDocNum = "UDocNum",
            ShopifyId = "ShopifyId",
            DocIds = "DocIds",
            Updated = "Updated"
        }
    }
}
