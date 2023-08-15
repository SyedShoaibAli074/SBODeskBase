
namespace SAPWebPortal.DraftsExpense {

    @Serenity.Decorators.registerClass()
    export class DocumentAdditionalExpenseGrid extends Serenity.EntityGrid<DocumentAdditionalExpenseRow, any> {
        protected getColumnsKey() { return DocumentAdditionalExpenseColumns.columnsKey; }
        protected getDialogType() { return DocumentAdditionalExpenseDialog; }
        protected getIdProperty() { return DocumentAdditionalExpenseRow.idProperty; }
        protected getInsertPermission() { return DocumentAdditionalExpenseRow.insertPermission; }
        protected getLocalTextPrefix() { return DocumentAdditionalExpenseRow.localTextPrefix; }
        protected getService() { return DocumentAdditionalExpenseService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}