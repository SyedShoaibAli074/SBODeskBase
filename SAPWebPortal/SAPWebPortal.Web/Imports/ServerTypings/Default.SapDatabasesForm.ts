namespace SAPWebPortal.Default {
    export interface SapDatabasesForm {
        ServerName: Serenity.StringEditor;
        DbServerType: DbServerTypeValuesEditor;
        LicenseServer: Serenity.StringEditor;
        CompanyDb: Serenity.StringEditor;
        DbUserName: Serenity.StringEditor;
        DbPassword: Serenity.PasswordEditor;
        UserName: Serenity.StringEditor;
        Password: Serenity.PasswordEditor;
        ODBCServer: Serenity.StringEditor;
        Alias: Serenity.StringEditor;
        ServiceLayerUrl: Serenity.StringEditor;
        ServiceLayerVersion: Serenity.StringEditor;
        DBDriver: DBDriverEditor;
        CreateUDFs: Serenity.BooleanEditor;
        IsDefault: Serenity.BooleanEditor;
    }

    export class SapDatabasesForm extends Serenity.PrefixedContext {
        static formKey = 'Default.SapDatabases';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SapDatabasesForm.init)  {
                SapDatabasesForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = DbServerTypeValuesEditor;
                var w2 = s.PasswordEditor;
                var w3 = DBDriverEditor;
                var w4 = s.BooleanEditor;

                Q.initFormType(SapDatabasesForm, [
                    'ServerName', w0,
                    'DbServerType', w1,
                    'LicenseServer', w0,
                    'CompanyDb', w0,
                    'DbUserName', w0,
                    'DbPassword', w2,
                    'UserName', w0,
                    'Password', w2,
                    'ODBCServer', w0,
                    'Alias', w0,
                    'ServiceLayerUrl', w0,
                    'ServiceLayerVersion', w0,
                    'DBDriver', w3,
                    'CreateUDFs', w4,
                    'IsDefault', w4
                ]);
            }
        }
    }
}
