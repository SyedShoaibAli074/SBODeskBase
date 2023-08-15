namespace SAPWebPortal.Administration {
    export interface SessionsForm {
        SessionId: Serenity.StringEditor;
        UserName: Serenity.StringEditor;
    }

    export class SessionsForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.Sessions';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SessionsForm.init)  {
                SessionsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(SessionsForm, [
                    'SessionId', w0,
                    'UserName', w0
                ]);
            }
        }
    }
}
