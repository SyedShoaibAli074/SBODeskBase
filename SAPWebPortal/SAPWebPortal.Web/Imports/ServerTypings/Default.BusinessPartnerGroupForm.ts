namespace SAPWebPortal.Default {
    export interface BusinessPartnerGroupForm {
        Name: Serenity.StringEditor;
        Type: Serenity.EnumEditor;
    }

    export class BusinessPartnerGroupForm extends Serenity.PrefixedContext {
        static formKey = 'Default.BusinessPartnerGroup';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!BusinessPartnerGroupForm.init)  {
                BusinessPartnerGroupForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.EnumEditor;

                Q.initFormType(BusinessPartnerGroupForm, [
                    'Name', w0,
                    'Type', w1
                ]);
            }
        }
    }
}
