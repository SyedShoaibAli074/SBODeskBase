
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ItemGrid extends _Ext.GridBase1<ItemRow, any> {
        protected getColumnsKey() { return ItemColumns.columnsKey; }
        protected getDialogType() { return ItemDialog; }
        protected getIdProperty() { return ItemRow.idProperty; }
        protected getInsertPermission() { return ItemRow.insertPermission; }
        protected getLocalTextPrefix() { return ItemRow.localTextPrefix; }
        protected getService() { return ItemService.baseUrl; }

        constructor(container: JQuery, options?) {
            options.SomeProp = 15;
            super(container, options);
        }
        protected getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
           /* var Orders = SAPWebPortal.Orders.DocumentDialog.Form;
            var Quotations = SAPWebPortal.Quotations.DocumentDialog.Form;
            if (Orders != undefined) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }
            if (Quotations != undefined) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }*/
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            return buttons;
        }
        protected getViewOptions() {
            let opt = super.getViewOptions();
            //Default option
            opt.rowsPerPage = 20;
            return opt;
        }
        protected getPagerOptions() {
            let opt = super.getPagerOptions();
            //Options in the dropdown
            opt.rowsPerPageOptions = [10, 20];
            return opt;
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