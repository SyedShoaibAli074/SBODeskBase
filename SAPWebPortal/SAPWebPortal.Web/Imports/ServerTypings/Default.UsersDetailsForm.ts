namespace SAPWebPortal.Default {
    export interface UsersDetailsForm {
        U1Id: Serenity.IntegerEditor;
        ParameterName: Serenity.StringEditor;
        ParameterQuery: Serenity.StringEditor;
        DbName: Serenity.StringEditor;
    }

    export class UsersDetailsForm extends Serenity.PrefixedContext {
        static formKey = 'Default.UsersDetails';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!UsersDetailsForm.init)  {
                UsersDetailsForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;

                Q.initFormType(UsersDetailsForm, [
                    'U1Id', w0,
                    'ParameterName', w1,
                    'ParameterQuery', w1,
                    'DbName', w1
                ]);
            }
        }
    }
}
