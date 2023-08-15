namespace SAPWebPortal.Default {
    export interface OipbatchRow {
        Id?: number;
        UUserid?: number;
        UUserCode?: string;
        UBatchType?: string;
        UDocDate?: string;
        UCashAcct?: string;
        UTrsfrAcct?: string;
        UTDocNum?: number;
        UCashierId?: string;
        UStatus?: string;
        UDocTotal?: number;
        DetailList?: Ipbatch1Row[];
    }

    export namespace OipbatchRow {
        export const idProperty = 'Id';
        export const nameProperty = 'UUserCode';
        export const localTextPrefix = 'Default.Oipbatch';
        export const deletePermission = 'Administration:General';
        export const insertPermission = 'Administration:General';
        export const readPermission = 'Administration:General';
        export const updatePermission = 'Administration:General';

        export declare const enum Fields {
            Id = "Id",
            UUserid = "UUserid",
            UUserCode = "UUserCode",
            UBatchType = "UBatchType",
            UDocDate = "UDocDate",
            UCashAcct = "UCashAcct",
            UTrsfrAcct = "UTrsfrAcct",
            UTDocNum = "UTDocNum",
            UCashierId = "UCashierId",
            UStatus = "UStatus",
            UDocTotal = "UDocTotal",
            DetailList = "DetailList"
        }
    }
}
