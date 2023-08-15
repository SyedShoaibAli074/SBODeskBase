namespace SAPWebPortal.IncomingPayment {
    export interface PaymentCheckRow {
        LineNum?: number;
        DueDate?: string;
        CheckNumber?: number;
        BankCode?: string;
        Branch?: string;
        AccounttNum?: string;
        Details?: string;
        Trnsfrable?: string;
        CheckSum?: number;
        Currency?: string;
        CountryCode?: string;
        CheckAbsEntry?: number;
        CheckAccount?: string;
        ManualCheck?: string;
        FiscalId?: string;
        OriginallyIssuedBy?: string;
        Endorse?: string;
        EndorsableCheckNo?: number;
        U_UserCode?: string;
    }

    export namespace PaymentCheckRow {
        export const idProperty = 'LineNum';
        export const localTextPrefix = 'IncomingPayment.PaymentCheck';
        export const deletePermission = 'IncomingPayment';
        export const insertPermission = 'IncomingPayment';
        export const readPermission = 'IncomingPayment';
        export const updatePermission = 'IncomingPayment';

        export declare const enum Fields {
            LineNum = "LineNum",
            DueDate = "DueDate",
            CheckNumber = "CheckNumber",
            BankCode = "BankCode",
            Branch = "Branch",
            AccounttNum = "AccounttNum",
            Details = "Details",
            Trnsfrable = "Trnsfrable",
            CheckSum = "CheckSum",
            Currency = "Currency",
            CountryCode = "CountryCode",
            CheckAbsEntry = "CheckAbsEntry",
            CheckAccount = "CheckAccount",
            ManualCheck = "ManualCheck",
            FiscalId = "FiscalId",
            OriginallyIssuedBy = "OriginallyIssuedBy",
            Endorse = "Endorse",
            EndorsableCheckNo = "EndorsableCheckNo",
            U_UserCode = "U_UserCode"
        }
    }
}
