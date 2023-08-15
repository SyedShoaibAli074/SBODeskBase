namespace SAPWebPortal.IncomingPayment {
    export interface PaymentInvoiceRow {
        LineNum?: number;
        DocEntry?: number;
        SumApplied?: number;
        AppliedFc?: number;
        AppliedSys?: number;
        DocRate?: number;
        DocLine?: number;
        InvoiceType?: string;
        DiscountPercent?: number;
        PaidSum?: number;
        InstallmentId?: number;
        WitholdingTaxApplied?: number;
        WitholdingTaxAppliedFc?: number;
        WitholdingTaxAppliedSc?: number;
        LinkDate?: string;
        DistributionRule?: string;
        DistributionRule2?: string;
        DistributionRule3?: string;
        DistributionRule4?: string;
        DistributionRule5?: string;
        TotalDiscount?: number;
        TotalDiscountFc?: number;
        TotalDiscountSc?: number;
        UOcrCode6?: string;
        UOcrCode7?: string;
        UOcrCode8?: string;
        UOcrCode9?: string;
        UOcrCode10?: string;
        UOcrCode11?: string;
    }

    export namespace PaymentInvoiceRow {
        export const idProperty = 'LineNum';
        export const localTextPrefix = 'IncomingPayment.PaymentInvoice';
        export const deletePermission = 'IncomingPayment';
        export const insertPermission = 'IncomingPayment';
        export const readPermission = 'IncomingPayment';
        export const updatePermission = 'IncomingPayment';

        export declare const enum Fields {
            LineNum = "LineNum",
            DocEntry = "DocEntry",
            SumApplied = "SumApplied",
            AppliedFc = "AppliedFc",
            AppliedSys = "AppliedSys",
            DocRate = "DocRate",
            DocLine = "DocLine",
            InvoiceType = "InvoiceType",
            DiscountPercent = "DiscountPercent",
            PaidSum = "PaidSum",
            InstallmentId = "InstallmentId",
            WitholdingTaxApplied = "WitholdingTaxApplied",
            WitholdingTaxAppliedFc = "WitholdingTaxAppliedFc",
            WitholdingTaxAppliedSc = "WitholdingTaxAppliedSc",
            LinkDate = "LinkDate",
            DistributionRule = "DistributionRule",
            DistributionRule2 = "DistributionRule2",
            DistributionRule3 = "DistributionRule3",
            DistributionRule4 = "DistributionRule4",
            DistributionRule5 = "DistributionRule5",
            TotalDiscount = "TotalDiscount",
            TotalDiscountFc = "TotalDiscountFc",
            TotalDiscountSc = "TotalDiscountSc",
            UOcrCode6 = "UOcrCode6",
            UOcrCode7 = "UOcrCode7",
            UOcrCode8 = "UOcrCode8",
            UOcrCode9 = "UOcrCode9",
            UOcrCode10 = "UOcrCode10",
            UOcrCode11 = "UOcrCode11"
        }
    }
}
