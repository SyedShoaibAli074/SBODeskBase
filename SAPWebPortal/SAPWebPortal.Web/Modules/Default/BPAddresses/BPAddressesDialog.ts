
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
   /* @Serenity.Decorators.panel()*/
    export class BPAddressesDialog extends _Ext.EditorDialogBase<BPAddressesRow> {
        protected getFormKey() { return BPAddressesForm.formKey; }
        //protected getIdProperty() { return BPAddressesRow.idProperty; }
        protected getLocalTextPrefix() { return BPAddressesRow.localTextPrefix; }
       // protected getNameProperty() { return BPAddressesRow.nameProperty; }
        protected getService() { return BPAddressesService.baseUrl; }
        //protected getDeletePermission() { return BPAddressesRow.deletePermission; }
        //protected getInsertPermission() { return BPAddressesRow.insertPermission; }
        //protected getUpdatePermission() { return BPAddressesRow.updatePermission; }

        protected form = new BPAddressesForm(this.idPrefix);
        constructor(container: JQuery) {
            super(container);
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