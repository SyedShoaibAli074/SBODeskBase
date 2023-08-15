
namespace SAPWebPortal.Delivery {

    @Serenity.Decorators.registerClass()
    export class DocumentGrid extends _Ext.GridBase1<DocumentRow, any> {
        protected getColumnsKey() { return DocumentColumns.columnsKey; }
        protected getDialogType() { return DocumentDialog; }
        protected getIdProperty() { return DocumentRow.idProperty; }
        protected getInsertPermission() { return DocumentRow.insertPermission; }
        protected getLocalTextPrefix() { return DocumentRow.localTextPrefix; }
        protected getService() { return DocumentService.baseUrl; }

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
        protected onViewSubmit(): boolean {
            if (!super.onViewSubmit()) { return false; }
            let request = this.view.params as Serenity.ListRequest;
            var DB = localStorage.getItem("DBName");
            request.CompanyDB = DB;
            return true;
        }

        protected getPagerOptions() {
            let opt = super.getPagerOptions();
            //Options in the dropdown
            opt.rowsPerPageOptions = [10, 20];
            return opt;
        }
        protected getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            return buttons;
        }
    }
}