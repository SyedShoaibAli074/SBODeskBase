
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class LogGrid extends _Ext.GridBase<LogRow, any> {
        protected getColumnsKey() { return LogColumns.columnsKey; }
        protected getDialogType() { return LogDialog; }
        protected getIdProperty() { return LogRow.idProperty; }
        protected getInsertPermission() { return LogRow.insertPermission; }
        protected getLocalTextPrefix() { return LogRow.localTextPrefix; }
        protected getService() { return LogService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}