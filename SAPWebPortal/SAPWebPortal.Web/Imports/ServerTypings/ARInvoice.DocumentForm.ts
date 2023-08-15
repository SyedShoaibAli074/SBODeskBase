namespace SAPWebPortal.ARInvoice {
    export interface DocumentForm {
        DocEntry: Serenity.IntegerEditor;
        DocNum: Serenity.IntegerEditor;
        DocType: Serenity.StringEditor;
        DBName: Serenity.StringEditor;
        DocDate: Serenity.DateEditor;
        DocDueDate: Serenity.DateEditor;
        CardCode: Serenity.StringEditor;
        CardName: Serenity.StringEditor;
        Address: Serenity.StringEditor;
        NumAtCard: Serenity.StringEditor;
        DocTotal: Serenity.DecimalEditor;
    }

    export class DocumentForm extends Serenity.PrefixedContext {
        static formKey = 'ARInvoice.Document';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!DocumentForm.init)  {
                DocumentForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = s.DateEditor;
                var w3 = s.DecimalEditor;

                Q.initFormType(DocumentForm, [
                    'DocEntry', w0,
                    'DocNum', w0,
                    'DocType', w1,
                    'DBName', w1,
                    'DocDate', w2,
                    'DocDueDate', w2,
                    'CardCode', w1,
                    'CardName', w1,
                    'Address', w1,
                    'NumAtCard', w1,
                    'DocTotal', w3
                ]);
            }
        }
    }
}
