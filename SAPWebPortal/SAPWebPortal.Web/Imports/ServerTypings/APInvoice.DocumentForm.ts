namespace SAPWebPortal.APInvoice {
    export interface DocumentForm {
        Series: Default.SelectCodeNameValueEditor;
        DocNum: Serenity.IntegerEditor;
        DocumentStatus: Modules.DropDownEnums.DocStatusEditor;
        CardCode: _Ext.GridItemPickerEditor;
        CardName: Serenity.StringEditor;
        DocCurrency: Default.SelectCodeNameValueEditor;
        DocDate: Serenity.DateEditor;
        NumAtCard: Serenity.StringEditor;
        DocDueDate: Serenity.DateEditor;
        U_Cartons: Serenity.StringEditor;
        U_Total_Weight: Serenity.StringEditor;
        TrnspCode: Default.SelectCodeNameValueEditor;
        TrackNo: Serenity.StringEditor;
        U_BAL: Serenity.StringEditor;
        Comments: Serenity.TextAreaEditor;
        DocType: Modules.DropDownEnums.DocTypeEditor;
        DocumentLines: APInvoiceLine.DocumentLineEditor;
        SalesPersonCode: Default.SelectCodeNameValueEditor;
        DocumentsOwner: Default.SelectCodeNameValueEditor;
        DiscountPercent: Serenity.StringEditor;
        TotalDiscount: Serenity.StringEditor;
        VatSum: Serenity.DecimalEditor;
        DocTotal: Serenity.DecimalEditor;
        UserSign: Serenity.IntegerEditor;
        PaymentGroupCode: Serenity.StringEditor;
        Project: Default.SelectCodeNameValueEditor;
        PayToCode: Default.SelectCodeNameValueEditor;
        ShipToCode: Default.SelectCodeNameValueEditor;
        U_QTY: Serenity.IntegerEditor;
        AttachmentEntry: Serenity.StringEditor;
        FederalTaxId: Serenity.StringEditor;
    }

    export class DocumentForm extends Serenity.PrefixedContext {
        static formKey = 'APInvoice.Document';
        private static init: boolean;

        constructor(prefix: string) {
            super(prefix);

            if (!DocumentForm.init)  {
                DocumentForm.init = true;

                var s = Serenity;
                var w0 = Default.SelectCodeNameValueEditor;
                var w1 = s.IntegerEditor;
                var w2 = Modules.DropDownEnums.DocStatusEditor;
                var w3 = _Ext.GridItemPickerEditor;
                var w4 = s.StringEditor;
                var w5 = s.DateEditor;
                var w6 = s.TextAreaEditor;
                var w7 = Modules.DropDownEnums.DocTypeEditor;
                var w8 = APInvoiceLine.DocumentLineEditor;
                var w9 = s.DecimalEditor;

                Q.initFormType(DocumentForm, [
                    'Series', w0,
                    'DocNum', w1,
                    'DocumentStatus', w2,
                    'CardCode', w3,
                    'CardName', w4,
                    'DocCurrency', w0,
                    'DocDate', w5,
                    'NumAtCard', w4,
                    'DocDueDate', w5,
                    'U_Cartons', w4,
                    'U_Total_Weight', w4,
                    'TrnspCode', w0,
                    'TrackNo', w4,
                    'U_BAL', w4,
                    'Comments', w6,
                    'DocType', w7,
                    'DocumentLines', w8,
                    'SalesPersonCode', w0,
                    'DocumentsOwner', w0,
                    'DiscountPercent', w4,
                    'TotalDiscount', w4,
                    'VatSum', w9,
                    'DocTotal', w9,
                    'UserSign', w1,
                    'PaymentGroupCode', w4,
                    'Project', w0,
                    'PayToCode', w0,
                    'ShipToCode', w0,
                    'U_QTY', w1,
                    'AttachmentEntry', w4,
                    'FederalTaxId', w4
                ]);
            }
        }
    }
}
