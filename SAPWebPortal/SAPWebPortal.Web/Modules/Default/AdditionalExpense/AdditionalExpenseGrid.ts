
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class AdditionalExpenseGrid extends _Ext.GridBase1<AdditionalExpenseRow, any> {
        protected getColumnsKey() { return AdditionalExpenseColumns.columnsKey; }
        protected getDialogType() { return AdditionalExpenseDialog; }
        protected getIdProperty() { return AdditionalExpenseRow.idProperty; }
        protected getInsertPermission() { return AdditionalExpenseRow.insertPermission; }
        protected getLocalTextPrefix() { return AdditionalExpenseRow.localTextPrefix; }
        protected getService() { return AdditionalExpenseService.baseUrl; }
        protected getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
            var Orders = SAPWebPortal.Orders.DocumentDialog.Form;
            var Quotations = SAPWebPortal.Quotations.DocumentDialog.Form;
            var Drafts = SAPWebPortal.Drafts.DocumentDialog.Form;
            if (Orders != undefined) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }
            if (Quotations != undefined) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }
            if (Drafts != undefined) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }
            return buttons;
        }
        constructor(container: JQuery, options?) {
            options.SomeProp = 15;
            super(container, options);
        }
        protected getViewOptions() {
            let opt = super.getViewOptions();
            //Default option
            opt.rowsPerPage = 10;
            return opt;
        }
        protected getPagerOptions() {
            let opt = super.getPagerOptions();
            //Options in the dropdown
            opt.rowsPerPageOptions = [10, 20];
            return opt;
        }
    }
}