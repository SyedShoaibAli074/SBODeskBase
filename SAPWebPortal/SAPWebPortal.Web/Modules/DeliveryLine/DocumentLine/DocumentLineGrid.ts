
namespace SAPWebPortal.DeliveryLine {

    @Serenity.Decorators.registerClass()
    export class DocumentLineGrid extends Serenity.EntityGrid<DocumentLineRow, any> {
        protected getColumnsKey() { return DocumentLineColumns.columnsKey; }
        protected getDialogType() { return DocumentLineDialog; }
        protected getIdProperty() { return DocumentLineRow.idProperty; }
        protected getInsertPermission() { return DocumentLineRow.insertPermission; }
        protected getLocalTextPrefix() { return DocumentLineRow.localTextPrefix; }
        protected getService() { return DocumentLineService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}