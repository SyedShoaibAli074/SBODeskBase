namespace SAPWebPortal.IncomingPayment {
    export interface PaymentForm {
        DocType: DocTypeValuesEditor;
        Series: Default.SelectCodeNameValueEditor;
        DocNum: Serenity.IntegerEditor;
        CardCode: _Ext.GridItemPickerEditor;
        CardName: Serenity.StringEditor;
        DocDate: Serenity.DateEditor;
        DueDate: Serenity.DateEditor;
        TaxDate: Serenity.DateEditor;
        DocEntry: Serenity.IntegerEditor;
        Remarks: Serenity.StringEditor;
        JournalRemarks: Serenity.StringEditor;
        PaymentInvoices: PaymentInvoiceEditor;
        PaymentChecks: PaymentCheckEditor;
        PaymentCreditCards: PaymentCreditCardEditor;
        PaymentAccounts: PaymentAccountEditor;
    }

    export class PaymentForm extends Serenity.PrefixedContext {
        static formKey = 'IncomingPayment.Payment';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PaymentForm.init)  {
                PaymentForm.init = true;

                var s = Serenity;
                var w0 = DocTypeValuesEditor;
                var w1 = Default.SelectCodeNameValueEditor;
                var w2 = s.IntegerEditor;
                var w3 = _Ext.GridItemPickerEditor;
                var w4 = s.StringEditor;
                var w5 = s.DateEditor;
                var w6 = PaymentInvoiceEditor;
                var w7 = PaymentCheckEditor;
                var w8 = PaymentCreditCardEditor;
                var w9 = PaymentAccountEditor;

                Q.initFormType(PaymentForm, [
                    'DocType', w0,
                    'Series', w1,
                    'DocNum', w2,
                    'CardCode', w3,
                    'CardName', w4,
                    'DocDate', w5,
                    'DueDate', w5,
                    'TaxDate', w5,
                    'DocEntry', w2,
                    'Remarks', w4,
                    'JournalRemarks', w4,
                    'PaymentInvoices', w6,
                    'PaymentChecks', w7,
                    'PaymentCreditCards', w8,
                    'PaymentAccounts', w9
                ]);
            }
        }
    }
}
