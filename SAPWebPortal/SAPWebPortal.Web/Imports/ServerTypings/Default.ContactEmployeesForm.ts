namespace SAPWebPortal.Default {
    export interface ContactEmployeesForm {
        CardCode: Serenity.StringEditor;
        Name: Serenity.StringEditor;
        Position: Serenity.StringEditor;
        Address: Serenity.StringEditor;
        Phone1: Serenity.StringEditor;
        E_Mail: Serenity.StringEditor;
        FirstName: Serenity.StringEditor;
        MiddleName: Serenity.StringEditor;
        LastName: Serenity.StringEditor;
        EmailGroupCode: Serenity.StringEditor;
        Active: Serenity.StringEditor;
    }

    export class ContactEmployeesForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ContactEmployees';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ContactEmployeesForm.init)  {
                ContactEmployeesForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;

                Q.initFormType(ContactEmployeesForm, [
                    'CardCode', w0,
                    'Name', w0,
                    'Position', w0,
                    'Address', w0,
                    'Phone1', w0,
                    'E_Mail', w0,
                    'FirstName', w0,
                    'MiddleName', w0,
                    'LastName', w0,
                    'EmailGroupCode', w0,
                    'Active', w0
                ]);
            }
        }
    }
}
