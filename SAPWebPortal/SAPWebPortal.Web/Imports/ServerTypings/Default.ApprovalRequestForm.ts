namespace SAPWebPortal.Default {
    export interface ApprovalRequestForm {
        ApprovalTemplatesID: SelectCodeNameValueEditor;
        ObjectType: Modules.DropDownEnums.ApprovalDocsEditor;
        DBName: Serenity.StringEditor;
        IsDraft: Modules.DropDownEnums.IsYOrNEditor;
        ObjectEntry: Serenity.IntegerEditor;
        Status: Modules.DropDownEnums.ApprovalStatusEditor;
        CurrentStage: Serenity.IntegerEditor;
        OriginatorID: SelectCodeNameValueEditor;
        CreationDate: Serenity.DateEditor;
        DraftEntry: _Ext.GridItemPickerEditor;
        ApprovalRequestLines: ApprovalRequestLineEditor;
        ApprovalRequestDecisions: ApprovalRequestDecisionEditor;
        Remarks: Serenity.TextAreaEditor;
    }

    export class ApprovalRequestForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ApprovalRequest';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ApprovalRequestForm.init)  {
                ApprovalRequestForm.init = true;

                var s = Serenity;
                var w0 = SelectCodeNameValueEditor;
                var w1 = Modules.DropDownEnums.ApprovalDocsEditor;
                var w2 = s.StringEditor;
                var w3 = Modules.DropDownEnums.IsYOrNEditor;
                var w4 = s.IntegerEditor;
                var w5 = Modules.DropDownEnums.ApprovalStatusEditor;
                var w6 = s.DateEditor;
                var w7 = _Ext.GridItemPickerEditor;
                var w8 = ApprovalRequestLineEditor;
                var w9 = ApprovalRequestDecisionEditor;
                var w10 = s.TextAreaEditor;

                Q.initFormType(ApprovalRequestForm, [
                    'ApprovalTemplatesID', w0,
                    'ObjectType', w1,
                    'DBName', w2,
                    'IsDraft', w3,
                    'ObjectEntry', w4,
                    'Status', w5,
                    'CurrentStage', w4,
                    'OriginatorID', w0,
                    'CreationDate', w6,
                    'DraftEntry', w7,
                    'ApprovalRequestLines', w8,
                    'ApprovalRequestDecisions', w9,
                    'Remarks', w10
                ]);
            }
        }
    }
}
