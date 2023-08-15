
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ChartOfAccountGrid extends _Ext.GridBase1<ChartOfAccountRow, any> {
        protected getColumnsKey() { return ChartOfAccountColumns.columnsKey; }
        protected getDialogType() { return ChartOfAccountDialog; }
        protected getIdProperty() { return ChartOfAccountRow.idProperty; }
        protected getInsertPermission() { return ChartOfAccountRow.insertPermission; }
        protected getLocalTextPrefix() { return ChartOfAccountRow.localTextPrefix; }
        protected getService() { return ChartOfAccountService.baseUrl; }

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
            opt.rowsPerPage = 20;
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