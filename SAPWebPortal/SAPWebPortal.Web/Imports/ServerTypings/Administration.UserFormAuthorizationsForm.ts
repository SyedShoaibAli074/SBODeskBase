namespace SAPWebPortal.Administration {
    export interface UserFormAuthorizationsForm {
        UserId: Serenity.IntegerEditor;
        ModuleName: Serenity.IntegerEditor;
        CompanyDb: Serenity.StringEditor;
        FormName: Serenity.StringEditor;
        FormTitle: Serenity.StringEditor;
        FormDescription: Serenity.StringEditor;
        DetailList: UserFormAuthorizationsDetailsEditor;
    }

    export class UserFormAuthorizationsForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.UserFormAuthorizations';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!UserFormAuthorizationsForm.init)  {
                UserFormAuthorizationsForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = UserFormAuthorizationsDetailsEditor;

                Q.initFormType(UserFormAuthorizationsForm, [
                    'UserId', w0,
                    'ModuleName', w0,
                    'CompanyDb', w1,
                    'FormName', w1,
                    'FormTitle', w1,
                    'FormDescription', w1,
                    'DetailList', w2
                ]);
            }
        }
    }
}
