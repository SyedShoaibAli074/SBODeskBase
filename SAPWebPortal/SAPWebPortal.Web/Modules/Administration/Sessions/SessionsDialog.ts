
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    export class SessionsDialog extends Serenity.EntityDialog<SessionsRow, any> {
        protected getFormKey() { return SessionsForm.formKey; }
        protected getIdProperty() { return SessionsRow.idProperty; }
        protected getLocalTextPrefix() { return SessionsRow.localTextPrefix; }
        protected getNameProperty() { return SessionsRow.nameProperty; }
        protected getService() { return SessionsService.baseUrl; }
        protected getDeletePermission() { return SessionsRow.deletePermission; }
        protected getInsertPermission() { return SessionsRow.insertPermission; }
        protected getUpdatePermission() { return SessionsRow.updatePermission; }

        protected form = new SessionsForm(this.idPrefix);

    }
}