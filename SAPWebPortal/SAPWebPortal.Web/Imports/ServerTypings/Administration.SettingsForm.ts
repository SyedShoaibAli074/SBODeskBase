namespace SAPWebPortal.Administration {
    export interface SettingsForm {
        UserId: Serenity.IntegerEditor;
        ModuleName: Serenity.IntegerEditor;
        ListDataSource: Serenity.StringEditor;
        PostByMethod: Serenity.StringEditor;
        IsHana: Serenity.BooleanEditor;
    }

    export class SettingsForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.Settings';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!SettingsForm.init)  {
                SettingsForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.BooleanEditor;

                Q.initFormType(SettingsForm, [
                    'UserId', w0,
                    'ModuleName', w0,
                    'ListDataSource', w1,
                    'PostByMethod', w1,
                    'IsHana', w2
                ]);
            }
        }
    }
}
