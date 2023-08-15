namespace SAPWebPortal.Default {
    export interface OipbatchForm {
        UUserid: Serenity.IntegerEditor;
        UUserCode: Serenity.StringEditor;
        UBatchType: BatchTypeValuesEditor;
        UDocDate: Serenity.DateTimeEditor;
        UCashAcct: Serenity.StringEditor;
        UTrsfrAcct: Serenity.StringEditor;
        UTDocNum: Serenity.IntegerEditor;
        UCashierId: Serenity.StringEditor;
        UStatus: StatusValuesEditor;
        UDocTotal: Serenity.DecimalEditor;
        DetailList: Ipbatch1Editor;
    }

    export class OipbatchForm extends Serenity.PrefixedContext {
        static formKey = 'Default.Oipbatch';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!OipbatchForm.init)  {
                OipbatchForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = BatchTypeValuesEditor;
                var w3 = s.DateTimeEditor;
                var w4 = StatusValuesEditor;
                var w5 = s.DecimalEditor;
                var w6 = Ipbatch1Editor;

                Q.initFormType(OipbatchForm, [
                    'UUserid', w0,
                    'UUserCode', w1,
                    'UBatchType', w2,
                    'UDocDate', w3,
                    'UCashAcct', w1,
                    'UTrsfrAcct', w1,
                    'UTDocNum', w0,
                    'UCashierId', w1,
                    'UStatus', w4,
                    'UDocTotal', w5,
                    'DetailList', w6
                ]);
            }
        }
    }
}
