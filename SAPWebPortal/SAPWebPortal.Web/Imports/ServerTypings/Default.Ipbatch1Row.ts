namespace SAPWebPortal.Default {
    export interface Ipbatch1Row {
        Id?: number;
        UCardCode?: string;
        UDocSum?: string;
        UBDocNum?: string;
        UBDocEntry?: string;
        UCardName?: string;
        UBatchId?: number;
    }

    export namespace Ipbatch1Row {
        export const idProperty = 'Id';
        export const nameProperty = 'UCardCode';
        export const localTextPrefix = 'Default.Ipbatch1';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            UCardCode = "UCardCode",
            UDocSum = "UDocSum",
            UBDocNum = "UBDocNum",
            UBDocEntry = "UBDocEntry",
            UCardName = "UCardName",
            UBatchId = "UBatchId"
        }
    }
}
