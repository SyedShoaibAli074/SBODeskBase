namespace SAPWebPortal.Drafts {
    export interface DocumentForm {
        DBName: Serenity.StringEditor;
        DocObjectCode: Modules.DropDownEnums.DraftDocsEditor;
        DocNum: Serenity.IntegerEditor;
        DocumentStatus: Modules.DropDownEnums.DocStatusEditor;
        CardCode: _Ext.GridItemPickerEditor;
        CardName: Serenity.StringEditor;
        DocCurrency: Default.SelectCodeNameValueEditor;
        DocDate: Serenity.DateEditor;
        AuthorizationStatus: Serenity.StringEditor;
        NumAtCard: Serenity.StringEditor;
        DocDueDate: Serenity.DateEditor;
        DocType: Modules.DropDownEnums.DocTypeEditor;
        DocumentLines: DraftsLine.DocumentLineEditor;
        SalesPersonCode: Default.SelectCodeNameValueEditor;
        DocumentsOwner: Default.SelectCodeNameValueEditor;
        DiscountPercent: Serenity.DecimalEditor;
        TotalDiscount: Serenity.DecimalEditor;
        VatSum: Serenity.DecimalEditor;
        DocTotal: Serenity.DecimalEditor;
        UserSign: Serenity.IntegerEditor;
        Comments: Serenity.TextAreaEditor;
        GroupNumber: Default.SelectCodeNameValueEditor;
        Project: Default.SelectCodeNameValueEditor;
        PayToCode: Default.SelectCodeNameValueEditor;
        ShipToCode: Default.SelectCodeNameValueEditor;
        U_Address: Serenity.TextAreaEditor;
        AttachmentEntry: Serenity.ImageUploadEditor;
    }

    export class DocumentForm extends Serenity.PrefixedContext {
        static formKey = 'Drafts.Document';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!DocumentForm.init)  {
                DocumentForm.init = true;

                var s = Serenity;
                var w0 = s.StringEditor;
                var w1 = Modules.DropDownEnums.DraftDocsEditor;
                var w2 = s.IntegerEditor;
                var w3 = Modules.DropDownEnums.DocStatusEditor;
                var w4 = _Ext.GridItemPickerEditor;
                var w5 = Default.SelectCodeNameValueEditor;
                var w6 = s.DateEditor;
                var w7 = Modules.DropDownEnums.DocTypeEditor;
                var w8 = DraftsLine.DocumentLineEditor;
                var w9 = s.DecimalEditor;
                var w10 = s.TextAreaEditor;
                var w11 = s.ImageUploadEditor;

                Q.initFormType(DocumentForm, [
                    'DBName', w0,
                    'DocObjectCode', w1,
                    'DocNum', w2,
                    'DocumentStatus', w3,
                    'CardCode', w4,
                    'CardName', w0,
                    'DocCurrency', w5,
                    'DocDate', w6,
                    'AuthorizationStatus', w0,
                    'NumAtCard', w0,
                    'DocDueDate', w6,
                    'DocType', w7,
                    'DocumentLines', w8,
                    'SalesPersonCode', w5,
                    'DocumentsOwner', w5,
                    'DiscountPercent', w9,
                    'TotalDiscount', w9,
                    'VatSum', w9,
                    'DocTotal', w9,
                    'UserSign', w2,
                    'Comments', w10,
                    'GroupNumber', w5,
                    'Project', w5,
                    'PayToCode', w5,
                    'ShipToCode', w5,
                    'U_Address', w10,
                    'AttachmentEntry', w11
                ]);
            }
        }
    }
}
