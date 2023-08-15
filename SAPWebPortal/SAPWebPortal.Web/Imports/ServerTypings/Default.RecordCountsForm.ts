namespace SAPWebPortal.Default {
    export interface RecordCountsForm {
        ModuleName: Serenity.StringEditor;
        ObjectType: SAPObjectsValuesEditor;
        Company: Membership.CompanyDatabaseValuesEditor;
        Counts: Serenity.IntegerEditor;
        DateTimeStamp: Serenity.DateTimeEditor;
    }

    export class RecordCountsForm extends Serenity.PrefixedContext {
        static formKey = 'Default.RecordCounts';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!RecordCountsForm.init)  {
                RecordCountsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = SAPObjectsValuesEditor;
                var w2 = Membership.CompanyDatabaseValuesEditor;
                var w3 = s.IntegerEditor;
                var w4 = s.DateTimeEditor;

                Q.initFormType(RecordCountsForm, [
                    'ModuleName', w0,
                    'ObjectType', w1,
                    'Company', w2,
                    'Counts', w3,
                    'DateTimeStamp', w4
                ]);
            }
        }
    }
}
