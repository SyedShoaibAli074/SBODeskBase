namespace SAPWebPortal.Administration {
    export interface UserFormAuthorizationsDetailsForm {
        FieldName: Serenity.StringEditor;
        FieldDescription: Serenity.StringEditor;
        DataType: Serenity.StringEditor;
        DefaultValue: Serenity.StringEditor;
        DataSize: Serenity.StringEditor;
        Readonly: Serenity.BooleanEditor;
        Required: Serenity.BooleanEditor;
        Visible: Serenity.BooleanEditor;
        HtmlClass: Serenity.StringEditor;
        HtmlStyle: Serenity.StringEditor;
        HtmlAttributes: Serenity.StringEditor;
    }

    export class UserFormAuthorizationsDetailsForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.UserFormAuthorizationsDetails';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!UserFormAuthorizationsDetailsForm.init)  {
                UserFormAuthorizationsDetailsForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.BooleanEditor;

                Q.initFormType(UserFormAuthorizationsDetailsForm, [
                    'FieldName', w0,
                    'FieldDescription', w0,
                    'DataType', w0,
                    'DefaultValue', w0,
                    'DataSize', w0,
                    'Readonly', w1,
                    'Required', w1,
                    'Visible', w1,
                    'HtmlClass', w0,
                    'HtmlStyle', w0,
                    'HtmlAttributes', w0
                ]);
            }
        }
    }
}
