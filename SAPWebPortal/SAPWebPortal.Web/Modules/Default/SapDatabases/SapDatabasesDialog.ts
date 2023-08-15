
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class SapDatabasesDialog extends Serenity.EntityDialog<SapDatabasesRow, any> {
        protected getFormKey() { return SapDatabasesForm.formKey; }
        protected getIdProperty() { return SapDatabasesRow.idProperty; }
        protected getLocalTextPrefix() { return SapDatabasesRow.localTextPrefix; }
        protected getNameProperty() { return SapDatabasesRow.nameProperty; }
        protected getService() { return SapDatabasesService.baseUrl; }
        protected getDeletePermission() { return SapDatabasesRow.deletePermission; }
        protected getInsertPermission() { return SapDatabasesRow.insertPermission; }
        protected getUpdatePermission() { return SapDatabasesRow.updatePermission; }

        protected form = new SapDatabasesForm(this.idPrefix);

    }
}