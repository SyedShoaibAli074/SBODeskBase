
namespace SAPWebPortal.Orders {

    @Serenity.Decorators.registerClass()
   /* @Serenity.Decorators.panel()*/
    export class AddressExtensionDialog extends _Ext.EditorDialogBase<AddressExtensionRow> {
        protected getFormKey() { return AddressExtensionForm.formKey; }
        //protected getIdProperty() { return AddressExtensionRow.idProperty; }
        protected getLocalTextPrefix() { return AddressExtensionRow.localTextPrefix; }
       // protected getNameProperty() { return AddressExtensionRow.nameProperty; }
        protected getService() { return AddressExtensionService.baseUrl; }
        //protected getDeletePermission() { return AddressExtensionRow.deletePermission; }
        //protected getInsertPermission() { return AddressExtensionRow.insertPermission; }
        //protected getUpdatePermission() { return AddressExtensionRow.updatePermission; }

        protected form = new AddressExtensionForm(this.idPrefix);
        constructor(container: JQuery) {
            super(container);
        }
        helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() {
            super.afterLoadEntity();
        }
    }
}