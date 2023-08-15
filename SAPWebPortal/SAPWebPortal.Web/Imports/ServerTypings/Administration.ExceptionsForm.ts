namespace SAPWebPortal.Administration {
    export interface ExceptionsForm {
        Guid: Serenity.StringEditor;
        ApplicationName: Serenity.StringEditor;
        CreationDate: Serenity.DateEditor;
        Source: Serenity.StringEditor;
        DuplicateCount: Serenity.IntegerEditor;
        Message: Serenity.TextAreaEditor;
        Detail: Serenity.TextAreaEditor;
    }

    export class ExceptionsForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.Exceptions';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ExceptionsForm.init)  {
                ExceptionsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.DateEditor;
                var w2 = s.IntegerEditor;
                var w3 = s.TextAreaEditor;

                Q.initFormType(ExceptionsForm, [
                    'Guid', w0,
                    'ApplicationName', w0,
                    'CreationDate', w1,
                    'Source', w0,
                    'DuplicateCount', w2,
                    'Message', w3,
                    'Detail', w3
                ]);
            }
        }
    }
}
