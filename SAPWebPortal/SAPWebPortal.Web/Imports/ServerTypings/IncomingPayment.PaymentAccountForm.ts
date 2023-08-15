namespace SAPWebPortal.IncomingPayment {
    export interface PaymentAccountForm {
        AccountCode: Serenity.StringEditor;
        SumPaid: Serenity.DecimalEditor;
        SumPaidFc: Serenity.DecimalEditor;
        Decription: Serenity.StringEditor;
        VatGroup: Serenity.StringEditor;
        AccountName: Serenity.StringEditor;
        GrossAmount: Serenity.DecimalEditor;
        ProfitCenter: Serenity.StringEditor;
        ProjectCode: Serenity.StringEditor;
        VatAmount: Serenity.DecimalEditor;
        ProfitCenter2: Serenity.StringEditor;
        ProfitCenter3: Serenity.StringEditor;
        ProfitCenter4: Serenity.StringEditor;
        ProfitCenter5: Serenity.StringEditor;
        LocationCode: Serenity.IntegerEditor;
        EqualizationVatAmount: Serenity.DecimalEditor;
    }

    export class PaymentAccountForm extends Serenity.PrefixedContext {
        static formKey = 'IncomingPayment.PaymentAccount';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PaymentAccountForm.init)  {
                PaymentAccountForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DecimalEditor;
                var w2 = s.IntegerEditor;

                Q.initFormType(PaymentAccountForm, [
                    'AccountCode', w0,
                    'SumPaid', w1,
                    'SumPaidFc', w1,
                    'Decription', w0,
                    'VatGroup', w0,
                    'AccountName', w0,
                    'GrossAmount', w1,
                    'ProfitCenter', w0,
                    'ProjectCode', w0,
                    'VatAmount', w1,
                    'ProfitCenter2', w0,
                    'ProfitCenter3', w0,
                    'ProfitCenter4', w0,
                    'ProfitCenter5', w0,
                    'LocationCode', w2,
                    'EqualizationVatAmount', w1
                ]);
            }
        }
    }
}
