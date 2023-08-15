
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class UserFormAuthorizationsDialog extends Serenity.EntityDialog<UserFormAuthorizationsRow, any> {
        protected getFormKey() { return UserFormAuthorizationsForm.formKey; }
        protected getIdProperty() { return UserFormAuthorizationsRow.idProperty; }
        protected getLocalTextPrefix() { return UserFormAuthorizationsRow.localTextPrefix; }
        protected getNameProperty() { return UserFormAuthorizationsRow.nameProperty; }
        protected getService() { return UserFormAuthorizationsService.baseUrl; }
        protected getDeletePermission() { return UserFormAuthorizationsRow.deletePermission; }
        protected getInsertPermission() { return UserFormAuthorizationsRow.insertPermission; }
        protected getUpdatePermission() { return UserFormAuthorizationsRow.updatePermission; }

        protected form = new UserFormAuthorizationsForm(this.idPrefix);

    }
}