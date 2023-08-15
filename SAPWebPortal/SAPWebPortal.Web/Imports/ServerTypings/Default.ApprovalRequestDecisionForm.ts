namespace SAPWebPortal.Default {
    export interface ApprovalRequestDecisionForm {
        Status: Serenity.EnumEditor;
        Remarks: Serenity.TextAreaEditor;
    }

    export class ApprovalRequestDecisionForm extends Serenity.PrefixedContext {
        static formKey = 'Default.ApprovalRequestDecision';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!ApprovalRequestDecisionForm.init)  {
                ApprovalRequestDecisionForm.init = true;

                var s = Serenity;
                var w0 = s.EnumEditor;
                var w1 = s.TextAreaEditor;

                Q.initFormType(ApprovalRequestDecisionForm, [
                    'Status', w0,
                    'Remarks', w1
                ]);
            }
        }
    }
}
