
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ApprovalRequestLineGrid extends Serenity.EntityGrid<ApprovalRequestLineRow, any> {
        protected getColumnsKey() { return ApprovalRequestLineColumns.columnsKey; }
        protected getDialogType() { return ApprovalRequestLineDialog; }
        protected getIdProperty() { return ApprovalRequestLineRow.idProperty; }
        protected getInsertPermission() { return ApprovalRequestLineRow.insertPermission; }
        protected getLocalTextPrefix() { return ApprovalRequestLineRow.localTextPrefix; }
        protected getService() { return ApprovalRequestLineService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        
    }
}