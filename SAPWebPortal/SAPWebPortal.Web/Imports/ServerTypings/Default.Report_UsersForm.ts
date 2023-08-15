namespace SAPWebPortal.Default {
    export interface Report_UsersForm {
        UserId: Serenity.LookupEditor;
        RptName: Serenity.StringEditor;
        DB_Name: Membership.CompanyDatabaseValuesEditor;
        Rodcid: Serenity.LookupEditor;
    }

    export class Report_UsersForm extends Serenity.PrefixedContext {
        static formKey = 'Default.Report_Users';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!Report_UsersForm.init)  {
                Report_UsersForm.init = true;

                var s = Serenity;
                var w0 = s.LookupEditor;
                var w1 = s.StringEditor;
                var w2 = Membership.CompanyDatabaseValuesEditor;

                Q.initFormType(Report_UsersForm, [
                    'UserId', w0,
                    'RptName', w1,
                    'DB_Name', w2,
                    'Rodcid', w0
                ]);
            }
        }
    }
}
