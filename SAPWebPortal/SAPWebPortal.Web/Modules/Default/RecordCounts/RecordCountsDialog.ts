
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class RecordCountsDialog extends Serenity.EntityDialog<RecordCountsRow, any> {
        protected getFormKey() { return RecordCountsForm.formKey; }
        protected getIdProperty() { return RecordCountsRow.idProperty; }
        protected getLocalTextPrefix() { return RecordCountsRow.localTextPrefix; }
        protected getNameProperty() { return RecordCountsRow.nameProperty; }
        protected getService() { return RecordCountsService.baseUrl; }
        protected getDeletePermission() { return RecordCountsRow.deletePermission; }
        protected getInsertPermission() { return RecordCountsRow.insertPermission; }
        protected getUpdatePermission() { return RecordCountsRow.updatePermission; }

        protected form = new RecordCountsForm(this.idPrefix);

    }
}