namespace SAPWebPortal.Administration {
    export interface LogRow {
        Id?: number;
        UDateTime?: string;
        UDirection?: string;
        UError?: string;
        UXml?: string;
        UResponse?: string;
        UObjType?: string;
        UVersion?: string;
        UKey?: string;
        UDocNum?: string;
        Updated?: number;
    }

    export namespace LogRow {
        export const idProperty = 'Id';
        export const nameProperty = 'UDirection';
        export const localTextPrefix = 'Administration.Log';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            UDateTime = "UDateTime",
            UDirection = "UDirection",
            UError = "UError",
            UXml = "UXml",
            UResponse = "UResponse",
            UObjType = "UObjType",
            UVersion = "UVersion",
            UKey = "UKey",
            UDocNum = "UDocNum",
            Updated = "Updated"
        }
    }
}
