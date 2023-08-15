namespace SAPWebPortal.VatGroups {
    export interface VatGroupForm {
        Name: Serenity.StringEditor;
        Inactive: Modules.DropDownEnums.YesOrNoEditor;
    }

    export class VatGroupForm extends Serenity.PrefixedContext {
        static formKey = 'VatGroups.VatGroup';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!VatGroupForm.init)  {
                VatGroupForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = Modules.DropDownEnums.YesOrNoEditor;

                Q.initFormType(VatGroupForm, [
                    'Name', w0,
                    'Inactive', w1
                ]);
            }
        }
    }
}
