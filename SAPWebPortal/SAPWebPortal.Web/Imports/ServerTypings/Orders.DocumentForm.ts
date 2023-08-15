namespace SAPWebPortal.Orders {
    export interface DocumentForm {
        Series: Default.SelectCodeNameValueEditor;
        DocNum: Serenity.IntegerEditor;
        DocumentStatus: Modules.DropDownEnums.DocStatusEditor;
        CardCode: _Ext.GridItemPickerEditor;
        DBName: Serenity.StringEditor;
        CardName: Serenity.StringEditor;
        DocCurrency: Default.SelectCodeNameValueEditor;
        DocDate: Serenity.DateEditor;
        NumAtCard: Serenity.StringEditor;
        DocDueDate: Serenity.DateEditor;
        DocType: Modules.DropDownEnums.DocTypeEditor;
        DocumentLines: OrdersLine.DocumentLineEditor;
        SalesPersonCode: Default.SelectCodeNameValueEditor;
        DocumentsOwner: Default.SelectCodeNameValueEditor;
        DiscountPercent: Serenity.DecimalEditor;
        TotalDiscount: Serenity.DecimalEditor;
        VatSum: Serenity.DecimalEditor;
        DocTotal: Serenity.DecimalEditor;
        UserSign: Serenity.IntegerEditor;
        Comments: Serenity.TextAreaEditor;
        GroupNum: Serenity.StringEditor;
        Project: Default.SelectCodeNameValueEditor;
        PayToCode: Default.SelectCodeNameValueEditor;
        ShipToCode: Default.SelectCodeNameValueEditor;
        U_Address: Orders.Document.AddressListEditor;
        AttachmentEntry: Serenity.ImageUploadEditor;
    }

    export class DocumentForm extends Serenity.PrefixedContext {
        static formKey = 'Orders.Document';
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
                var w6 = Modules.DropDownEnums.DocTypeEditor;
                var w7 = OrdersLine.DocumentLineEditor;
                var w8 = s.DecimalEditor;
                var w9 = s.TextAreaEditor;
                var w10 = Orders.Document.AddressListEditor;
                var w11 = s.ImageUploadEditor;

                Q.initFormType(DocumentForm, [
                    'Series', w0,
                    'DocNum', w1,
                    'DocumentStatus', w2,
                    'CardCode', w3,
                    'DBName', w4,
                    'CardName', w4,
                    'DocCurrency', w0,
                    'DocDate', w5,
                    'NumAtCard', w4,
                    'DocDueDate', w5,
                    'DocType', w6,
                    'DocumentLines', w7,
                    'SalesPersonCode', w0,
                    'DocumentsOwner', w0,
                    'DiscountPercent', w8,
                    'TotalDiscount', w8,
                    'VatSum', w8,
                    'DocTotal', w8,
                    'UserSign', w1,
                    'Comments', w9,
                    'GroupNum', w4,
                    'Project', w0,
                    'PayToCode', w0,
                    'ShipToCode', w0,
                    'U_Address', w10,
                    'AttachmentEntry', w11
                ]);
            }
        }
    }
}
