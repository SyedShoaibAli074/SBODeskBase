namespace SAPWebPortal.IncomingPayment {
    export interface PaymentRow {
        PaymentType?: string;
        CardCode?: string;
        CardName?: string;
        DBName?: string;
        Series?: number;
        DocNum?: number;
        DocType?: string;
        PayToCode?: string;
        ContactPersonCode?: number;
        ProjectCode?: string;
        DocDate?: string;
        DueDate?: string;
        CounterReference?: string;
        Address?: string;
        U_Sector?: string;
        CashAccount?: string;
        DocCurrency?: string;
        CashSum?: number;
        CheckAccount?: string;
        TransferAccount?: string;
        TransferSum?: number;
        TransferDate?: string;
        TransferReference?: string;
        TransactionCode?: string;
        LocalCurrency?: string;
        DocRate?: number;
        Remarks?: string;
        JournalRemarks?: string;
        U_UserSign?: number;
        U_UserCode?: string;
        TaxDate?: string;
        DocEntry?: number;
        PaymentInvoices?: PaymentInvoiceRow[];
        PaymentChecks?: PaymentCheckRow[];
        PaymentCreditCards?: PaymentCreditCardRow[];
        PaymentAccounts?: PaymentAccountRow[];
    }

    export namespace PaymentRow {
        export const idProperty = 'DocNum';
        export const localTextPrefix = 'IncomingPayment.Payment';
        export const deletePermission = 'IncomingPayment';
        export const insertPermission = 'IncomingPayment';
        export const readPermission = 'IncomingPayment';
        export const updatePermission = 'IncomingPayment';

        export declare const enum Fields {
            PaymentType = "PaymentType",
            CardCode = "CardCode",
            CardName = "CardName",
            DBName = "DBName",
            Series = "Series",
            DocNum = "DocNum",
            DocType = "DocType",
            PayToCode = "PayToCode",
            ContactPersonCode = "ContactPersonCode",
            ProjectCode = "ProjectCode",
            DocDate = "DocDate",
            DueDate = "DueDate",
            CounterReference = "CounterReference",
            Address = "Address",
            U_Sector = "U_Sector",
            CashAccount = "CashAccount",
            DocCurrency = "DocCurrency",
            CashSum = "CashSum",
            CheckAccount = "CheckAccount",
            TransferAccount = "TransferAccount",
            TransferSum = "TransferSum",
            TransferDate = "TransferDate",
            TransferReference = "TransferReference",
            TransactionCode = "TransactionCode",
            LocalCurrency = "LocalCurrency",
            DocRate = "DocRate",
            Remarks = "Remarks",
            JournalRemarks = "JournalRemarks",
            U_UserSign = "U_UserSign",
            U_UserCode = "U_UserCode",
            TaxDate = "TaxDate",
            DocEntry = "DocEntry",
            PaymentInvoices = "PaymentInvoices",
            PaymentChecks = "PaymentChecks",
            PaymentCreditCards = "PaymentCreditCards",
            PaymentAccounts = "PaymentAccounts"
        }
    }
}
