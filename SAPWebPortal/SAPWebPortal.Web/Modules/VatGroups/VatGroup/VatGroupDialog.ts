
namespace SAPWebPortal.VatGroups {

    @Serenity.Decorators.registerClass()
    export class VatGroupDialog extends Serenity.EntityDialog<VatGroupRow, any> {
        protected getFormKey() { return VatGroupForm.formKey; }
        protected getIdProperty() { return VatGroupRow.idProperty; }
        protected getLocalTextPrefix() { return VatGroupRow.localTextPrefix; }
        protected getService() { return VatGroupService.baseUrl; }
        protected getDeletePermission() { return VatGroupRow.deletePermission; }
        protected getInsertPermission() { return VatGroupRow.insertPermission; }
        protected getUpdatePermission() { return VatGroupRow.updatePermission; }

        protected form = new VatGroupForm(this.idPrefix);

    }
}