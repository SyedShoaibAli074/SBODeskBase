
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class FileRoutingGrid extends Serenity.EntityGrid<FileRoutingRow, any> {
        protected getColumnsKey() { return FileRoutingColumns.columnsKey; }
        protected getDialogType() { return FileRoutingDialog; }
        protected getIdProperty() { return FileRoutingRow.idProperty; }
        protected getInsertPermission() { return FileRoutingRow.insertPermission; }
        protected getLocalTextPrefix() { return FileRoutingRow.localTextPrefix; }
        protected getService() { return FileRoutingService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}