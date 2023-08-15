
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ContactEmployeesDialog extends Serenity.EntityDialog<ContactEmployeesRow, any> {
        protected getFormKey() { return ContactEmployeesForm.formKey; }
        protected getIdProperty() { return ContactEmployeesRow.idProperty; }
        protected getLocalTextPrefix() { return ContactEmployeesRow.localTextPrefix; }
        protected getNameProperty() { return ContactEmployeesRow.nameProperty; }
        protected getService() { return ContactEmployeesService.baseUrl; }
        protected getDeletePermission() { return ContactEmployeesRow.deletePermission; }
        protected getInsertPermission() { return ContactEmployeesRow.insertPermission; }
        protected getUpdatePermission() { return ContactEmployeesRow.updatePermission; }

        protected form = new ContactEmployeesForm(this.idPrefix);

    }
}