namespace SAPWebPortal.Administration {
    export interface LogForm {
        UDateTime: Serenity.DateEditor;
        UDirection: Serenity.StringEditor;
        UError: Serenity.StringEditor;
        UXml: Serenity.TextAreaEditor;
        UResponse: Serenity.TextAreaEditor;
    }

    export class LogForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.Log';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!LogForm.init)  {
                LogForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = s.StringEditor;
                var w2 = s.TextAreaEditor;

                Q.initFormType(LogForm, [
                    'UDateTime', w0,
                    'UDirection', w1,
                    'UError', w1,
                    'UXml', w2,
                    'UResponse', w2
                ]);
            }
        }
    }
}
