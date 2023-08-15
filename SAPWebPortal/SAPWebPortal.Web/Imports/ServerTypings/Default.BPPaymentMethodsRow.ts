namespace SAPWebPortal.Default {
    export interface BPPaymentMethodsRow {
        DetailID?: number;
        BPCode?: string;
        DBName?: string;
        PaymentMethodCode?: string;
    }

    export namespace BPPaymentMethodsRow {
        export const idProperty = 'DetailID';
        export const nameProperty = 'DetailID';
        export const localTextPrefix = 'Default.BPPaymentMethods';
        export const deletePermission = 'Administration:DefaultGeneral';
        export const insertPermission = 'Administration:DefaultGeneral';
        export const readPermission = 'Administration:DefaultGeneral';
        export const updatePermission = 'Administration:DefaultGeneral';

        export declare const enum Fields {
            DetailID = "DetailID",
            BPCode = "BPCode",
            DBName = "DBName",
            PaymentMethodCode = "PaymentMethodCode"
        }
    }
}
