namespace SAPWebPortal.Administration {
    export interface UserForm {
        Username: Serenity.StringEditor;
        DBName: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        UserImage: Serenity.ImageUploadEditor;
        Password: Serenity.PasswordEditor;
        PasswordConfirm: Serenity.PasswordEditor;
        WarehouseCode: Default.SelectCodeNameValueEditor;
        Source: SourceValuesEditor;
        DetailList: Serenity.StringEditor;
        DetailList1: Serenity.StringEditor;
        CompanyDatabase: Serenity.StringEditor;
    }

    export class UserForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.User';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!UserForm.init)  {
                UserForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.EmailEditor;
                var w2 = s.ImageUploadEditor;
                var w3 = s.PasswordEditor;
                var w4 = Default.SelectCodeNameValueEditor;
                var w5 = SourceValuesEditor;

                Q.initFormType(UserForm, [
                    'Username', w0,
                    'DBName', w0,
                    'DisplayName', w0,
                    'Email', w1,
                    'UserImage', w2,
                    'Password', w3,
                    'PasswordConfirm', w3,
                    'WarehouseCode', w4,
                    'Source', w5,
                    'DetailList', w0,
                    'DetailList1', w0,
                    'CompanyDatabase', w0
                ]);
            }
        }
    }
}
