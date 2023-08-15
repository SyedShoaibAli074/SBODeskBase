namespace SAPWebPortal.Default {
    export interface ChartOfAccountForm {
        Name: Serenity.StringEditor;
    }

    export class ChartOfAccountForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ChartOfAccount';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ChartOfAccountForm.init)  {
                ChartOfAccountForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(ChartOfAccountForm, [
                    'Name', w0
                ]);
            }
        }
    }
}
