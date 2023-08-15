
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class Report_UsersGrid extends _Ext.GridBase<Report_UsersRow, any> {
        protected getColumnsKey() { return Report_UsersColumns.columnsKey; }
        protected getDialogType() { return Report_UsersDialog; }
        protected getIdProperty() { return Report_UsersRow.idProperty; }
        protected getInsertPermission() { return Report_UsersRow.insertPermission; }
        protected getLocalTextPrefix() { return Report_UsersRow.localTextPrefix; }
        protected getService() { return Report_UsersService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
            $('[id^="slickgrid_"][id$="RowNum"]').hide();
        }
    }
}