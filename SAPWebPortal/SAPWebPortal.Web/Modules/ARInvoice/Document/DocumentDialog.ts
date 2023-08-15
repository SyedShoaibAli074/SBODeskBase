
namespace SAPWebPortal.ARInvoice {

    @Serenity.Decorators.registerClass()
    export class DocumentDialog extends _Ext.DialogBase<DocumentRow, any> {
        protected getFormKey() { return DocumentForm.formKey; }
        protected getIdProperty() { return DocumentRow.idProperty; }
        protected getLocalTextPrefix() { return DocumentRow.localTextPrefix; }
        protected getService() { return DocumentService.baseUrl; }
        protected getDeletePermission() { return DocumentRow.deletePermission; }
        protected getInsertPermission() { return DocumentRow.insertPermission; }
        protected getUpdatePermission() { return DocumentRow.updatePermission; }

        protected form = new DocumentForm(this.idPrefix);
        //disable add button
        protected getToolbarButtons() {
            var buttons = super.getToolbarButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            return buttons;
        }
        afterLoadEntity() {
            super.afterLoadEntity;
            this.setReadOnly(true);        }
    }
}