namespace SAPWebPortal.IncomingPayment {
    export interface PaymentCreditCardForm {
        CreditCard: Serenity.IntegerEditor;
        CreditAcct: Serenity.StringEditor;
        CreditCardNumber: Serenity.StringEditor;
        CardValidUntil: Serenity.DateEditor;
        VoucherNum: Serenity.StringEditor;
        OwnerIdNum: Serenity.StringEditor;
        OwnerPhone: Serenity.StringEditor;
        PaymentMethodCode: Serenity.IntegerEditor;
        NumOfPayments: Serenity.IntegerEditor;
        FirstPaymentDue: Serenity.DateEditor;
        FirstPaymentSum: Serenity.DecimalEditor;
        AdditionalPaymentSum: Serenity.DecimalEditor;
        CreditSum: Serenity.DecimalEditor;
        CreditCur: Serenity.StringEditor;
        CreditRate: Serenity.DecimalEditor;
        ConfirmationNum: Serenity.StringEditor;
        NumOfCreditPayments: Serenity.IntegerEditor;
        CreditType: Serenity.StringEditor;
        SplitPayments: Serenity.StringEditor;
    }

    export class PaymentCreditCardForm extends Serenity.PrefixedContext {
        static formKey = 'IncomingPayment.PaymentCreditCard';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!PaymentCreditCardForm.init)  {
                PaymentCreditCardForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.DateEditor;
                var w3 = s.DecimalEditor;

                Q.initFormType(PaymentCreditCardForm, [
                    'CreditCard', w0,
                    'CreditAcct', w1,
                    'CreditCardNumber', w1,
                    'CardValidUntil', w2,
                    'VoucherNum', w1,
                    'OwnerIdNum', w1,
                    'OwnerPhone', w1,
                    'PaymentMethodCode', w0,
                    'NumOfPayments', w0,
                    'FirstPaymentDue', w2,
                    'FirstPaymentSum', w3,
                    'AdditionalPaymentSum', w3,
                    'CreditSum', w3,
                    'CreditCur', w1,
                    'CreditRate', w3,
                    'ConfirmationNum', w1,
                    'NumOfCreditPayments', w0,
                    'CreditType', w1,
                    'SplitPayments', w1
                ]);
            }
        }
    }
}
