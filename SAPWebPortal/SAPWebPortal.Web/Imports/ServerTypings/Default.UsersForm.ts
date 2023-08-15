namespace SAPWebPortal.Default {
    export interface UsersForm {
        UserId: Serenity.LookupEditor;
        Username: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        Email: Serenity.StringEditor;
        Source: Serenity.StringEditor;
        PasswordHash: Serenity.StringEditor;
        PasswordSalt: Serenity.StringEditor;
        WarehouseCode: Serenity.StringEditor;
        LastDirectoryUpdate: Serenity.DateEditor;
        UserImage: Serenity.StringEditor;
        InsertDate: Serenity.DateEditor;
        InsertUserId: Serenity.IntegerEditor;
        UpdateDate: Serenity.DateEditor;
        UpdateUserId: Serenity.IntegerEditor;
        IsActive: Serenity.IntegerEditor;
        DetailList: Report_UsersEditor;
    }

    export class UsersForm extends Serenity.PrefixedContext {
        static formKey = 'Default.Users';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!UsersForm.init)  {
                UsersForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = s.DateEditor;
                var w3 = s.IntegerEditor;
                var w4 = Report_UsersEditor;

                Q.initFormType(UsersForm, [
                    'UserId', w0,
                    'Username', w1,
                    'DisplayName', w1,
                    'Email', w1,
                    'Source', w1,
                    'PasswordHash', w1,
                    'PasswordSalt', w1,
                    'WarehouseCode', w1,
                    'LastDirectoryUpdate', w2,
                    'UserImage', w1,
                    'InsertDate', w2,
                    'InsertUserId', w3,
                    'UpdateDate', w2,
                    'UpdateUserId', w3,
                    'IsActive', w3,
                    'DetailList', w4
                ]);
            }
        }
    }
}
