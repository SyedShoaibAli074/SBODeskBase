namespace SAPWebPortal.Default {
    export interface ReportsForm {
        RptName: Serenity.StringEditor;
        RptByteArray: Serenity.ImageUploadEditor;
        DB_Name: Membership.CompanyDatabaseValuesEditor;
        CreateDate: Serenity.DateEditor;
        UpdateDate: Serenity.DateEditor;
    }

    export class ReportsForm extends Serenity.PrefixedContext {
        static formKey = 'Default.Reports';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ReportsForm.init)  {
                ReportsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.ImageUploadEditor;
                var w2 = Membership.CompanyDatabaseValuesEditor;
                var w3 = s.DateEditor;

                Q.initFormType(ReportsForm, [
                    'RptName', w0,
                    'RptByteArray', w1,
                    'DB_Name', w2,
                    'CreateDate', w3,
                    'UpdateDate', w3
                ]);
            }
        }
    }
}
