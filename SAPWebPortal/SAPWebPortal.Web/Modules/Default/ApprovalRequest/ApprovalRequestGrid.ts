
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class ApprovalRequestGrid extends _Ext.GridBase1<ApprovalRequestRow, any> {
        protected getColumnsKey() { return ApprovalRequestColumns.columnsKey; }
        protected getDialogType() { return ApprovalRequestDialog; }
        protected getIdProperty() { return ApprovalRequestRow.idProperty; }
        protected getInsertPermission() { return ApprovalRequestRow.insertPermission; }
        protected getLocalTextPrefix() { return ApprovalRequestRow.localTextPrefix; }
        protected getService() { return ApprovalRequestService.baseUrl; }

        constructor(container: JQuery, options?) {
            options.SomeProp = 15;
            super(container, options);
        }
        protected getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
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
            opt.rowsPerPageOptions = [20, 20];
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