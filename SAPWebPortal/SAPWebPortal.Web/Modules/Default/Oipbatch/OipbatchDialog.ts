
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class OipbatchDialog extends _Ext.DialogBase<OipbatchRow, any> {
        protected getFormKey() { return OipbatchForm.formKey; }
        protected getIdProperty() { return OipbatchRow.idProperty; }
        protected getLocalTextPrefix() { return OipbatchRow.localTextPrefix; }
        protected getNameProperty() { return OipbatchRow.nameProperty; }
        protected getService() { return OipbatchService.baseUrl; }
        protected getDeletePermission() { return OipbatchRow.deletePermission; }
        protected getInsertPermission() { return OipbatchRow.insertPermission; }
        protected getUpdatePermission() { return OipbatchRow.updatePermission; }

        protected form = new OipbatchForm(this.idPrefix);
        constructor() {
            super();
            this.setReadOnly(true);
        }


    }
}