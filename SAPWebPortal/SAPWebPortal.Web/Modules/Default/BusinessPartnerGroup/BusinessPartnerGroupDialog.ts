
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class BusinessPartnerGroupDialog extends Serenity.EntityDialog<BusinessPartnerGroupRow, any> {
        protected getFormKey() { return BusinessPartnerGroupForm.formKey; }
        protected getIdProperty() { return BusinessPartnerGroupRow.idProperty; }
        protected getLocalTextPrefix() { return BusinessPartnerGroupRow.localTextPrefix; }
        protected getService() { return BusinessPartnerGroupService.baseUrl; }
        protected getDeletePermission() { return BusinessPartnerGroupRow.deletePermission; }
        protected getInsertPermission() { return BusinessPartnerGroupRow.insertPermission; }
        protected getUpdatePermission() { return BusinessPartnerGroupRow.updatePermission; }

        protected form = new BusinessPartnerGroupForm(this.idPrefix);

    }
}