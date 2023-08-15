
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class RecordCountsGrid extends Serenity.EntityGrid<RecordCountsRow, any> {
        protected getColumnsKey() { return RecordCountsColumns.columnsKey; }
        protected getDialogType() { return RecordCountsDialog; }
        protected getIdProperty() { return RecordCountsRow.idProperty; }
        protected getInsertPermission() { return RecordCountsRow.insertPermission; }
        protected getLocalTextPrefix() { return RecordCountsRow.localTextPrefix; }
        protected getService() { return RecordCountsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}