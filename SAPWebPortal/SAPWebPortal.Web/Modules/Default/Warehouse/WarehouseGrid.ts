
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class WarehouseGrid extends _Ext.GridBase1<WarehouseRow, any> {
        protected getColumnsKey() { return WarehouseColumns.columnsKey; }
        protected getDialogType() { return WarehouseDialog; }
        protected getIdProperty() { return WarehouseRow.idProperty; }
        protected getInsertPermission() { return WarehouseRow.insertPermission; }
        protected getLocalTextPrefix() { return WarehouseRow.localTextPrefix; }
        protected getService() { return WarehouseService.baseUrl; }

        protected getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
            var Orders = SAPWebPortal.Orders.DocumentDialog.Form;
            var Quotations = SAPWebPortal.Quotations.DocumentDialog.Form;
            if (Orders != undefined) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }
            if (Quotations != undefined) {
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