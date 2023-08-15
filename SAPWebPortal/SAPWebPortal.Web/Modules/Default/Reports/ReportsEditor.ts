//// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ReportsEditor extends _Ext.GridEditorBase<ReportsRow> {
        protected getColumnsKey() { return "Default.Reports"; }
        protected getDialogType() { return ReportsDialog; }
        protected getLocalTextPrefix() { return ReportsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getAddButtonCaption() {
            return "Add";
        }
        validateEntity(row: ReportsRow, id: number) {
            row.Rdocid = Q.toId(row.Rdocid);
            var sameReport = Q.tryFirst(this.view.getItems(), x => x.Rdocid === row.Rdocid);
            if (sameReport && this.id(sameReport) !== id) {
                Q.alert('This Report is already in Reports details!');
                return false;
            }
            row.RptName = ReportsRow.Fields.RptName;
            row.RptByteArray = ReportsRow.Fields.RptByteArray;
            return true;
        }
    }
}