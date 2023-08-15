
namespace SAPWebPortal.OrdersLine {
    @Serenity.Decorators.registerClass()
    export class DocumentLineDialog extends _Ext.EditorDialogBase<DocumentLineRow> {
        protected getFormKey() { return DocumentLineForm.formKey; }
        protected getLocalTextPrefix() { return DocumentLineRow.localTextPrefix; }
        protected form = new DocumentLineForm(this.idPrefix);
        static Form: DocumentLineForm;
        constructor(container: JQuery) {
            super(container);
            DocumentLineDialog.Form = this.form;
        }
    }
}