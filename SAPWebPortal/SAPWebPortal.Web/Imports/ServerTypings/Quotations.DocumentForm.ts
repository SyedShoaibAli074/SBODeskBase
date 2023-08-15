namespace SAPWebPortal.Quotations {
    export interface DocumentForm {
        Series: Default.SelectCodeNameValueEditor;
        DBName: Serenity.StringEditor;
        DocNum: Serenity.IntegerEditor;
        DocumentStatus: Modules.DropDownEnums.DocStatusEditor;
        CardCode: _Ext.GridItemPickerEditor;
        CardName: Serenity.StringEditor;
        DocCurrency: Default.SelectCodeNameValueEditor;
        DocDate: Serenity.DateEditor;
        NumAtCard: Serenity.StringEditor;
        DocDueDate: Serenity.DateEditor;
        DocType: Modules.DropDownEnums.DocTypeEditor;
        DocumentLines: QuotationsLine.DocumentLineEditor;
        SalesPersonCode: Default.SelectCodeNameValueEditor;
        DocumentsOwner: Default.SelectCodeNameValueEditor;
        DiscountPercent: Serenity.DecimalEditor;
        TotalDiscount: Serenity.DecimalEditor;
        VatSum: Serenity.DecimalEditor;
        DocTotal: Serenity.DecimalEditor;
        UserSign: Serenity.IntegerEditor;
        Comments: Serenity.TextAreaEditor;
        Project: Default.SelectCodeNameValueEditor;
        PayToCode: Default.SelectCodeNameValueEditor;
        ShipToCode: Default.SelectCodeNameValueEditor;
        U_Address: Serenity.TextAreaEditor;
        AttachmentEntry: Serenity.ImageUploadEditor;
    }

    export class DocumentForm extends Serenity.PrefixedContext {
        static formKey = 'Quotations.Document';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!DocumentForm.init)  {
                DocumentForm.init = true;

                var s = Serenity;
                var w0 = Default.SelectCodeNameValueEditor;
                var w1 = s.StringEditor;
                var w2 = s.IntegerEditor;
                var w3 = Modules.DropDownEnums.DocStatusEditor;
                var w4 = _Ext.GridItemPickerEditor;
                var w5 = s.DateEditor;
                var w6 = Modules.DropDownEnums.DocTypeEditor;
                var w7 = QuotationsLine.DocumentLineEditor;
                var w8 = s.DecimalEditor;
                var w9 = s.TextAreaEditor;
                var w10 = s.ImageUploadEditor;

                Q.initFormType(DocumentForm, [
                    'Series', w0,
                    'DBName', w1,
                    'DocNum', w2,
                    'DocumentStatus', w3,
                    'CardCode', w4,
                    'CardName', w1,
                    'DocCurrency', w0,
                    'DocDate', w5,
                    'NumAtCard', w1,
                    'DocDueDate', w5,
                    'DocType', w6,
                    'DocumentLines', w7,
                    'SalesPersonCode', w0,
                    'DocumentsOwner', w0,
                    'DiscountPercent', w8,
                    'TotalDiscount', w8,
                    'VatSum', w8,
                    'DocTotal', w8,
                    'UserSign', w2,
                    'Comments', w9,
                    'Project', w0,
                    'PayToCode', w0,
                    'ShipToCode', w0,
                    'U_Address', w9,
                    'AttachmentEntry', w10
                ]);
            }
        }
    }
}
