
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class BPPaymentMethodsDialog extends _Ext.EditorDialogBase<BPPaymentMethodsRow> {
        protected getFormKey() { return BPPaymentMethodsForm.formKey; }
        //protected getIdProperty() { return BPPaymentMethodsRow.idProperty; }
        protected getLocalTextPrefix() { return BPPaymentMethodsRow.localTextPrefix; }
        //protected getNameProperty() { return BPPaymentMethodsRow.nameProperty; }
        protected getService() { return BPPaymentMethodsService.baseUrl; }
        //protected getDeletePermission() { return BPPaymentMethodsRow.deletePermission; }
        //protected getInsertPermission() { return BPPaymentMethodsRow.insertPermission; }
        //protected getUpdatePermission() { return BPPaymentMethodsRow.updatePermission; }

        protected form = new BPPaymentMethodsForm(this.idPrefix);
      
        public static Form: BPPaymentMethodsForm;
        constructor(opt?: any) {
            super(opt);
            BPPaymentMethodsDialog.Form = this.form;
        }
         helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() {
            super.afterLoadEntity();
            var service = this.getService();
            var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
            this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(this.form, dropdownfields, service, this);
            this.loadEntity(this.entity);
            this.form.DBName.value = localStorage.getItem("DBName");
        }

    }
}