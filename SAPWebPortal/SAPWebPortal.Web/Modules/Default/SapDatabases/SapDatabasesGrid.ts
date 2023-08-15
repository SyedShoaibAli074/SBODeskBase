
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class SapDatabasesGrid extends Serenity.EntityGrid<SapDatabasesRow, any> {
        protected getColumnsKey() { return SapDatabasesColumns.columnsKey; }
        protected getDialogType() { return SapDatabasesDialog; }
        protected getIdProperty() { return SapDatabasesRow.idProperty; }
        protected getInsertPermission() { return SapDatabasesRow.insertPermission; }
        protected getLocalTextPrefix() { return SapDatabasesRow.localTextPrefix; }
        protected getService() { return SapDatabasesService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}