
namespace SAPWebPortal.QuotationsExpense {

    @Serenity.Decorators.registerClass()
    export class DocumentAdditionalExpenseDialog extends _Ext.EditorDialogBase<DocumentAdditionalExpenseRow> {
        protected getFormKey() { return DocumentAdditionalExpenseForm.formKey; }
        // protected getIdProperty() { return DocumentAdditionalExpenseRow.idProperty; }
        protected getLocalTextPrefix() { return DocumentAdditionalExpenseRow.localTextPrefix; }
        //protected getService() { return DocumentAdditionalExpenseService.baseUrl; }
        //protected getDeletePermission() { return DocumentAdditionalExpenseRow.deletePermission; }
        //protected getInsertPermission() { return DocumentAdditionalExpenseRow.insertPermission; }
        //protected getUpdatePermission() { return DocumentAdditionalExpenseRow.updatePermission; }

        protected form = new DocumentAdditionalExpenseForm(this.idPrefix);
        static Form: DocumentAdditionalExpenseForm;
        constructor(container: JQuery) {
            super(container);
            DocumentAdditionalExpenseDialog.Form = this.form;
        }
    }
}