
namespace SAPWebPortal.Administration {

    @Serenity.Decorators.registerClass()
    export class UserFormAuthorizationsDetailsDialog extends Serenity.EntityDialog<UserFormAuthorizationsDetailsRow, any> {
        protected getFormKey() { return UserFormAuthorizationsDetailsForm.formKey; }
        //protected getIdProperty() { return UserFormAuthorizationsDetailsRow.idProperty; }
        protected getLocalTextPrefix() { return UserFormAuthorizationsDetailsRow.localTextPrefix; }
      //  protected getNameProperty() { return UserFormAuthorizationsDetailsRow.nameProperty; }
       // protected getService() { return UserFormAuthorizationsDetailsService.baseUrl; }
       // protected getDeletePermission() { return UserFormAuthorizationsDetailsRow.deletePermission; }
       // protected getInsertPermission() { return UserFormAuthorizationsDetailsRow.insertPermission; }
       // protected getUpdatePermission() { return UserFormAuthorizationsDetailsRow.updatePermission; }

        protected form = new UserFormAuthorizationsDetailsForm(this.idPrefix);

    }
}