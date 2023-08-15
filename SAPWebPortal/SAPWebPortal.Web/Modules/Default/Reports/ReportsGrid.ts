
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ReportsGrid extends _Ext.GridBase<ReportsRow, any> {
        protected getColumnsKey() { return ReportsColumns.columnsKey; }
        protected getDialogType() { return ReportsDialog; }
        protected getIdProperty() { return ReportsRow.idProperty; }
        protected getInsertPermission() { return ReportsRow.insertPermission; }
        protected getLocalTextPrefix() { return ReportsRow.localTextPrefix; }
        protected getService() { return ReportsService.baseUrl; }

        constructor(container: JQuery, options?) {
            options.SomeProp = 15;
            super(container, options);
        }
        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.editable = false;
            return opt;
        }
        protected usePager() {
            return false;
        }
        validateEntity(row: ReportsRow, id: number) {
            row.RptName = Q.toId(row.RptName);
            var sameReport = Q.tryFirst(this.view.getItems(), x => x.RptName === row.RptName);
            return false;
        }
    }
}