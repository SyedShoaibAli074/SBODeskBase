namespace SAPWebPortal.Default {
    export interface BPPaymentMethodsForm {
        PaymentMethodCode: SelectCodeNameValueEditor;
        DBName: Serenity.StringEditor;
    }

    export class BPPaymentMethodsForm extends Serenity.PrefixedContext {
        static formKey = 'Default.BPPaymentMethods';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!BPPaymentMethodsForm.init)  {
                BPPaymentMethodsForm.init = true;

                var s = Serenity;
                var w0 = SelectCodeNameValueEditor;
                var w1 = s.StringEditor;

                Q.initFormType(BPPaymentMethodsForm, [
                    'PaymentMethodCode', w0,
                    'DBName', w1
                ]);
            }
        }
    }
}
