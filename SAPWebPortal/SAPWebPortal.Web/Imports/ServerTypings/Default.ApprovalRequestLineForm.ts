namespace SAPWebPortal.Default {
    export interface ApprovalRequestLineForm {
        UserID: Serenity.IntegerEditor;
        StageCode: Serenity.IntegerEditor;
        Status: Modules.DropDownEnums.ApprovalLineStatusEditor;
        DBName: Serenity.StringEditor;
        CreationDate: Serenity.DateTimeEditor;
        UpdateDate: Serenity.DateTimeEditor;
        Remarks: Serenity.TextAreaEditor;
    }

    export class ApprovalRequestLineForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ApprovalRequestLine';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ApprovalRequestLineForm.init)  {
                ApprovalRequestLineForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = Modules.DropDownEnums.ApprovalLineStatusEditor;
                var w2 = s.StringEditor;
                var w3 = s.DateTimeEditor;
                var w4 = s.TextAreaEditor;

                Q.initFormType(ApprovalRequestLineForm, [
                    'UserID', w0,
                    'StageCode', w0,
                    'Status', w1,
                    'DBName', w2,
                    'CreationDate', w3,
                    'UpdateDate', w3,
                    'Remarks', w4
                ]);
            }
        }
    }
}
