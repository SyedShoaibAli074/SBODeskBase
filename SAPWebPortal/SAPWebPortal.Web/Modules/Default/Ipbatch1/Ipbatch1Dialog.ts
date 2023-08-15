
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class Ipbatch1Dialog extends _Ext.EditorDialogBase<Ipbatch1Row> {
        protected getFormKey() { return Ipbatch1Form.formKey; }
       // protected getIdProperty() { return Ipbatch1Row.idProperty; }
        protected getLocalTextPrefix() { return Ipbatch1Row.localTextPrefix; }
       // protected getNameProperty() { return Ipbatch1Row.nameProperty; }
        protected getService() { return Ipbatch1Service.baseUrl; }
        //protected getDeletePermission() { return Ipbatch1Row.deletePermission; }
        //protected getInsertPermission() { return Ipbatch1Row.insertPermission; }
        //protected getUpdatePermission() { return Ipbatch1Row.updatePermission; }

        protected form = new Ipbatch1Form(this.idPrefix);

    }
}