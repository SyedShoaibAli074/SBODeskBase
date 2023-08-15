
namespace SAPWebPortal.Orders {

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
            opt.rowsPerPage = 20;
           // Authorization.getSapUserid(Authorization.userDefinition.Username)
            return opt;
        }
        protected getPagerOptions() {
            let opt = super.getPagerOptions();
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