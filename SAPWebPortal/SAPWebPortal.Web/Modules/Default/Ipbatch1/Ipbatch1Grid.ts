
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class Ipbatch1Grid extends Serenity.EntityGrid<Ipbatch1Row, any> {
        protected getColumnsKey() { return Ipbatch1Columns.columnsKey; }
        protected getDialogType() { return Ipbatch1Dialog; }
        protected getIdProperty() { return Ipbatch1Row.idProperty; }
        protected getInsertPermission() { return Ipbatch1Row.insertPermission; }
        protected getLocalTextPrefix() { return Ipbatch1Row.localTextPrefix; }
        protected getService() { return Ipbatch1Service.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}