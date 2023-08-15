namespace SAPWebPortal.IncomingPayment {
    export interface PaymentAccountRow {
        LineNum?: number;
        AccountCode?: string;
        SumPaid?: number;
        SumPaidFc?: number;
        Decription?: string;
        VatGroup?: string;
        AccountName?: string;
        GrossAmount?: number;
        ProfitCenter?: string;
        ProjectCode?: string;
        VatAmount?: number;
        ProfitCenter2?: string;
        ProfitCenter3?: string;
        ProfitCenter4?: string;
        ProfitCenter5?: string;
        LocationCode?: number;
        EqualizationVatAmount?: number;
    }

    export namespace PaymentAccountRow {
        export const idProperty = 'LineNum';
        export const localTextPrefix = 'IncomingPayment.PaymentAccount';
        export const deletePermission = 'IncomingPayment';
        export const insertPermission = 'IncomingPayment';
        export const readPermission = 'IncomingPayment';
        export const updatePermission = 'IncomingPayment';

        export declare const enum Fields {
            LineNum = "LineNum",
            AccountCode = "AccountCode",
            SumPaid = "SumPaid",
            SumPaidFc = "SumPaidFc",
            Decription = "Decription",
            VatGroup = "VatGroup",
            AccountName = "AccountName",
            GrossAmount = "GrossAmount",
            ProfitCenter = "ProfitCenter",
            ProjectCode = "ProjectCode",
            VatAmount = "VatAmount",
            ProfitCenter2 = "ProfitCenter2",
            ProfitCenter3 = "ProfitCenter3",
            ProfitCenter4 = "ProfitCenter4",
            ProfitCenter5 = "ProfitCenter5",
            LocationCode = "LocationCode",
            EqualizationVatAmount = "EqualizationVatAmount"
        }
    }
}
