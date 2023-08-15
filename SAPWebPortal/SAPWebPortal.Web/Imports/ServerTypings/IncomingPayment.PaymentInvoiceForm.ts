namespace SAPWebPortal.IncomingPayment {
    export interface PaymentInvoiceForm {
        DocEntry: Serenity.IntegerEditor;
        SumApplied: Serenity.DecimalEditor;
        AppliedFc: Serenity.DecimalEditor;
        AppliedSys: Serenity.DecimalEditor;
        DocRate: Serenity.DecimalEditor;
        DocLine: Serenity.IntegerEditor;
        InvoiceType: Serenity.StringEditor;
        DiscountPercent: Serenity.DecimalEditor;
        PaidSum: Serenity.DecimalEditor;
        InstallmentId: Serenity.IntegerEditor;
        WitholdingTaxApplied: Serenity.DecimalEditor;
        WitholdingTaxAppliedFc: Serenity.DecimalEditor;
        WitholdingTaxAppliedSc: Serenity.DecimalEditor;
        LinkDate: Serenity.DateEditor;
        DistributionRule: Serenity.StringEditor;
        DistributionRule2: Serenity.StringEditor;
        DistributionRule3: Serenity.StringEditor;
        DistributionRule4: Serenity.StringEditor;
        DistributionRule5: Serenity.StringEditor;
        TotalDiscount: Serenity.DecimalEditor;
        TotalDiscountFc: Serenity.DecimalEditor;
        TotalDiscountSc: Serenity.DecimalEditor;
        UOcrCode6: Serenity.StringEditor;
        UOcrCode7: Serenity.StringEditor;
        UOcrCode8: Serenity.StringEditor;
        UOcrCode9: Serenity.StringEditor;
        UOcrCode10: Serenity.StringEditor;
        UOcrCode11: Serenity.StringEditor;
    }

    export class PaymentInvoiceForm extends Serenity.PrefixedContext {
        static formKey = 'IncomingPayment.PaymentInvoice';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PaymentInvoiceForm.init)  {
                PaymentInvoiceForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.DecimalEditor;
                var w2 = s.StringEditor;
                var w3 = s.DateEditor;

                Q.initFormType(PaymentInvoiceForm, [
                    'DocEntry', w0,
                    'SumApplied', w1,
                    'AppliedFc', w1,
                    'AppliedSys', w1,
                    'DocRate', w1,
                    'DocLine', w0,
                    'InvoiceType', w2,
                    'DiscountPercent', w1,
                    'PaidSum', w1,
                    'InstallmentId', w0,
                    'WitholdingTaxApplied', w1,
                    'WitholdingTaxAppliedFc', w1,
                    'WitholdingTaxAppliedSc', w1,
                    'LinkDate', w3,
                    'DistributionRule', w2,
                    'DistributionRule2', w2,
                    'DistributionRule3', w2,
                    'DistributionRule4', w2,
                    'DistributionRule5', w2,
                    'TotalDiscount', w1,
                    'TotalDiscountFc', w1,
                    'TotalDiscountSc', w1,
                    'UOcrCode6', w2,
                    'UOcrCode7', w2,
                    'UOcrCode8', w2,
                    'UOcrCode9', w2,
                    'UOcrCode10', w2,
                    'UOcrCode11', w2
                ]);
            }
        }
    }
}
