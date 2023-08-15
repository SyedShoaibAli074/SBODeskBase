namespace SAPWebPortal.Default {
    export interface LogForm {
        UDateTime: Serenity.DateEditor;
        UDirection: Modules.DropDownEnums.DirectionEditor;
        UError: Modules.DropDownEnums.ErrorEditor;
        URequest: Serenity.TextAreaEditor;
        UResponse: Serenity.TextAreaEditor;
        ShopifyPayload: Serenity.TextAreaEditor;
        UObjType: Serenity.StringEditor;
        ShopifyId: Serenity.StringEditor;
    }

    export class LogForm extends Serenity.PrefixedContext {
        static formKey = 'Default.Log';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!LogForm.init)  {
                LogForm.init = true;

                var s = Serenity;
                var w0 = s.DateEditor;
                var w1 = Modules.DropDownEnums.DirectionEditor;
                var w2 = Modules.DropDownEnums.ErrorEditor;
                var w3 = s.TextAreaEditor;
                var w4 = s.StringEditor;

                Q.initFormType(LogForm, [
                    'UDateTime', w0,
                    'UDirection', w1,
                    'UError', w2,
                    'URequest', w3,
                    'UResponse', w3,
                    'ShopifyPayload', w3,
                    'UObjType', w4,
                    'ShopifyId', w4
                ]);
            }
        }
    }
}
