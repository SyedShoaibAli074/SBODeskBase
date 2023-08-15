namespace SAPWebPortal.DraftsExpense {
    export interface DocumentAdditionalExpenseForm {
        LineNum: Serenity.IntegerEditor;
        ExpenseCode: _Ext.GridItemPickerEditor;
        U_Amount: Serenity.DecimalEditor;
        VatGroup: _Ext.GridItemPickerEditor;
        TaxPercent: Serenity.DecimalEditor;
        TaxSum: Serenity.DecimalEditor;
        LineTotal: Serenity.DecimalEditor;
        Remarks: Serenity.TextAreaEditor;
    }

    export class DocumentAdditionalExpenseForm extends Serenity.PrefixedContext {
        static formKey = 'DraftsExpense.DocumentAdditionalExpense';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!DocumentAdditionalExpenseForm.init)  {
                DocumentAdditionalExpenseForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = _Ext.GridItemPickerEditor;
                var w2 = s.DecimalEditor;
                var w3 = s.TextAreaEditor;

                Q.initFormType(DocumentAdditionalExpenseForm, [
                    'LineNum', w0,
                    'ExpenseCode', w1,
                    'U_Amount', w2,
                    'VatGroup', w1,
                    'TaxPercent', w2,
                    'TaxSum', w2,
                    'LineTotal', w2,
                    'Remarks', w3
                ]);
            }
        }
    }
}
