namespace SAPWebPortal.Default {
    export interface UserDetail2Form {
        UserDId: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        UserCode: Serenity.StringEditor;
        UserName: Serenity.StringEditor;
        DbName: Serenity.StringEditor;
        SalesPersonCode: SalesPersonValuesEditor;
        SalesPersonName: Serenity.StringEditor;
        Active: Serenity.BooleanEditor;
    }

    export class UserDetail2Form extends Serenity.PrefixedContext {
        static formKey = 'Default.UserDetail2';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!UserDetail2Form.init)  {
                UserDetail2Form.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = SalesPersonValuesEditor;
                var w3 = s.BooleanEditor;

                Q.initFormType(UserDetail2Form, [
                    'UserDId', w0,
                    'UserId', w0,
                    'UserCode', w1,
                    'UserName', w1,
                    'DbName', w1,
                    'SalesPersonCode', w2,
                    'SalesPersonName', w1,
                    'Active', w3
                ]);
            }
        }
    }
}
