namespace SAPWebPortal.IncomingPayment {
    export interface PaymentCheckForm {
        DueDate: Serenity.DateEditor;
        CheckNumber: Serenity.IntegerEditor;
        BankCode: Serenity.StringEditor;
        Branch: Serenity.StringEditor;
        AccounttNum: Serenity.StringEditor;
        Details: Serenity.StringEditor;
        Trnsfrable: Serenity.StringEditor;
        CheckSum: Serenity.DecimalEditor;
        Currency: Serenity.StringEditor;
        CountryCode: Serenity.StringEditor;
        CheckAbsEntry: Serenity.IntegerEditor;
        CheckAccount: Serenity.StringEditor;
        ManualCheck: Serenity.StringEditor;
        FiscalId: Serenity.StringEditor;
        OriginallyIssuedBy: Serenity.StringEditor;
        Endorse: Serenity.StringEditor;
        EndorsableCheckNo: Serenity.IntegerEditor;
    }

    export class PaymentCheckForm extends Serenity.PrefixedContext {
        static formKey = 'IncomingPayment.PaymentCheck';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PaymentCheckForm.init)  {
                PaymentCheckForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = s.IntegerEditor;
                var w2 = s.StringEditor;
                var w3 = s.DecimalEditor;

                Q.initFormType(PaymentCheckForm, [
                    'DueDate', w0,
                    'CheckNumber', w1,
                    'BankCode', w2,
                    'Branch', w2,
                    'AccounttNum', w2,
                    'Details', w2,
                    'Trnsfrable', w2,
                    'CheckSum', w3,
                    'Currency', w2,
                    'CountryCode', w2,
                    'CheckAbsEntry', w1,
                    'CheckAccount', w2,
                    'ManualCheck', w2,
                    'FiscalId', w2,
                    'OriginallyIssuedBy', w2,
                    'Endorse', w2,
                    'EndorsableCheckNo', w1
                ]);
            }
        }
    }
}
