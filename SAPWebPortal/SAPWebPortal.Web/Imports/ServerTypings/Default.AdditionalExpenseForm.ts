namespace SAPWebPortal.Default {
    export interface AdditionalExpenseForm {
        ExpensCode: Serenity.IntegerEditor;
        Name: Serenity.StringEditor;
    }

    export class AdditionalExpenseForm extends Serenity.PrefixedContext {
        static formKey = 'Default.AdditionalExpense';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!AdditionalExpenseForm.init)  {
                AdditionalExpenseForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;

                Q.initFormType(AdditionalExpenseForm, [
                    'ExpensCode', w0,
                    'Name', w1
                ]);
            }
        }
    }
}
