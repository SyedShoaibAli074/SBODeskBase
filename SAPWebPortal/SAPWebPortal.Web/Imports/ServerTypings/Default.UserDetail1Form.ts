namespace SAPWebPortal.Default {
    export interface UserDetail1Form {
        UserDId: Serenity.IntegerEditor;
        UserId: Serenity.IntegerEditor;
        UserCode: Serenity.StringEditor;
        UserName: Serenity.StringEditor;
        DbName: Serenity.StringEditor;
        CardCode: CardCodeValuesEditor;
        CardName: Serenity.StringEditor;
        Active: Serenity.BooleanEditor;
    }

    export class UserDetail1Form extends Serenity.PrefixedContext {
        static formKey = 'Default.UserDetail1';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!UserDetail1Form.init)  {
                UserDetail1Form.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = CardCodeValuesEditor;
                var w3 = s.BooleanEditor;

                Q.initFormType(UserDetail1Form, [
                    'UserDId', w0,
                    'UserId', w0,
                    'UserCode', w1,
                    'UserName', w1,
                    'DbName', w1,
                    'CardCode', w2,
                    'CardName', w1,
                    'Active', w3
                ]);
            }
        }
    }
}
