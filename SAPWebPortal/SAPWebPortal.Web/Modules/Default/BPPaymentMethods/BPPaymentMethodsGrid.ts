
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class BPPaymentMethodsGrid extends _Ext.GridBase1<BPPaymentMethodsRow, any> {
        protected getColumnsKey() { return BPPaymentMethodsColumns.columnsKey; }
        protected getDialogType() { return BPPaymentMethodsDialog; }
        protected getIdProperty() { return BPPaymentMethodsRow.idProperty; }
        protected getInsertPermission() { return BPPaymentMethodsRow.insertPermission; }
        protected getLocalTextPrefix() { return BPPaymentMethodsRow.localTextPrefix; }
        protected getService() { return BPPaymentMethodsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
            
        }
        protected onViewSubmit(): boolean {
            if (!super.onViewSubmit()) { return false; }
            let request = this.view.params as Serenity.ListRequest;
            var DB = localStorage.getItem("DBName");
            request.CompanyDB = DB;
            return true;
        }
            
    }
}