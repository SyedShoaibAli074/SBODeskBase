namespace SAPWebPortal.InventoryTransferRequest {
    export interface StockTransferForm {
        Series: Serenity.IntegerEditor;
        Printed: Serenity.StringEditor;
        DocDate: Serenity.StringEditor;
        DueDate: Serenity.StringEditor;
        CardCode: Serenity.StringEditor;
        CardName: Serenity.StringEditor;
        Address: Serenity.StringEditor;
        Reference1: Serenity.StringEditor;
        Reference2: Serenity.StringEditor;
        Comments: Serenity.StringEditor;
        JournalMemo: Serenity.StringEditor;
        PriceList: Serenity.IntegerEditor;
        SalesPersonCode: Serenity.IntegerEditor;
        FromWarehouse: Serenity.StringEditor;
        ToWarehouse: Serenity.StringEditor;
        DBName: Serenity.StringEditor;
        StockTransferLines: StockTransferLineEditor;
    }

    export class StockTransferForm extends Serenity.PrefixedContext {
        static formKey = 'InventoryTransferRequest.StockTransfer';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!StockTransferForm.init)  {
                StockTransferForm.init = true;

                var s = Serenity;
                var w0 = s.IntegerEditor;
                var w1 = s.StringEditor;
                var w2 = StockTransferLineEditor;

                Q.initFormType(StockTransferForm, [
                    'Series', w0,
                    'Printed', w1,
                    'DocDate', w1,
                    'DueDate', w1,
                    'CardCode', w1,
                    'CardName', w1,
                    'Address', w1,
                    'Reference1', w1,
                    'Reference2', w1,
                    'Comments', w1,
                    'JournalMemo', w1,
                    'PriceList', w0,
                    'SalesPersonCode', w0,
                    'FromWarehouse', w1,
                    'ToWarehouse', w1,
                    'DBName', w1,
                    'StockTransferLines', w2
                ]);
            }
        }
    }
}
