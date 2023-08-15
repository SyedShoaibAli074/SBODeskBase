
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ApprovalRequestDecisionGrid extends Serenity.EntityGrid<ApprovalRequestDecisionRow, any> {
        protected getColumnsKey() { return ApprovalRequestDecisionColumns.columnsKey; }
        protected getDialogType() { return ApprovalRequestDecisionDialog; }
        protected getIdProperty() { return ApprovalRequestDecisionRow.idProperty; }
        protected getInsertPermission() { return ApprovalRequestDecisionRow.insertPermission; }
        protected getLocalTextPrefix() { return ApprovalRequestDecisionRow.localTextPrefix; }
        protected getService() { return ApprovalRequestDecisionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}