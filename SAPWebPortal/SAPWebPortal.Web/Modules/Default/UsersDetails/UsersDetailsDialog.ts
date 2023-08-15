
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class UsersDetailsDialog extends Serenity.EntityDialog<UsersDetailsRow, any> {
        protected getFormKey() { return UsersDetailsForm.formKey; }
        protected getIdProperty() { return UsersDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return UsersDetailsRow.localTextPrefix; }
        protected getNameProperty() { return UsersDetailsRow.nameProperty; }
        protected getService() { return UsersDetailsService.baseUrl; }
        protected getDeletePermission() { return UsersDetailsRow.deletePermission; }
        protected getInsertPermission() { return UsersDetailsRow.insertPermission; }
        protected getUpdatePermission() { return UsersDetailsRow.updatePermission; }
        protected form: UsersDetailsForm;
        constructor() {
            super();
            this.form = new UsersDetailsForm(this.idPrefix);

            this.form.ParameterName.change(e => {
                this.form.U1Id.value = Q.toId(this.form.ParameterName.value);
            });
        }
        protected updateInterface() {
            super.updateInterface();
            this.deleteButton.hide();
        }

    }
}