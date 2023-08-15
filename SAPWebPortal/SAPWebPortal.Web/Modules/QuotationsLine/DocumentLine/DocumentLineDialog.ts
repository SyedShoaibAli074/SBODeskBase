
namespace SAPWebPortal.QuotationsLine {

    @Serenity.Decorators.registerClass()
    export class DocumentLineDialog extends _Ext.EditorDialogBase<DocumentLineRow> {
        protected getFormKey() { return DocumentLineForm.formKey; }
        //protected getIdProperty() { return DocumentLineRow.idProperty; }
        protected getLocalTextPrefix() { return DocumentLineRow.localTextPrefix; }
        //protected getService() { return DocumentLineService.baseUrl; }
        //protected getDeletePermission() { return DocumentLineRow.deletePermission; }
        //protected getInsertPermission() { return DocumentLineRow.insertPermission; }
        //protected getUpdatePermission() { return DocumentLineRow.updatePermission; }

        protected form = new DocumentLineForm(this.idPrefix);
        static Form: DocumentLineForm;
        constructor(container: JQuery) {
            super(container);
            DocumentLineDialog.Form = this.form;
        }
        helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() {
            super.afterLoadEntity(); 
            var service = this.getService();
            var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
            this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(this.form, dropdownfields, service, this);
        }
    }
}