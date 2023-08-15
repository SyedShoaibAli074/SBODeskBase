namespace SAPWebPortal.Default {
    export interface Ipbatch1Form {
        UCardCode: Serenity.StringEditor;
        UDocSum: Serenity.StringEditor;
        UBDocNum: Serenity.StringEditor;
        UBDocEntry: Serenity.StringEditor;
        UCardName: Serenity.StringEditor;
        UBatchId: Serenity.IntegerEditor;
    }

    export class Ipbatch1Form extends Serenity.PrefixedContext {
        static formKey = 'Default.Ipbatch1';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!Ipbatch1Form.init)  {
                Ipbatch1Form.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = s.IntegerEditor;

                Q.initFormType(Ipbatch1Form, [
                    'UCardCode', w0,
                    'UDocSum', w0,
                    'UBDocNum', w0,
                    'UBDocEntry', w0,
                    'UCardName', w0,
                    'UBatchId', w1
                ]);
            }
        }
    }
}
