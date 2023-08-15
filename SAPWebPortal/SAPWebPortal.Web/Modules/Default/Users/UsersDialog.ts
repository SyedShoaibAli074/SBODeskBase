
namespace SAPWebPortal.Default {
    export var ExUserID;
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class UsersDialog extends _Ext.DialogBase<UsersRow, any> {
        protected getFormKey() { return UsersForm.formKey; }
        protected getIdProperty() { return UsersRow.idProperty; }
        protected getLocalTextPrefix() { return UsersRow.localTextPrefix; }
        protected getNameProperty() { return UsersRow.nameProperty; }
        protected getService() { return UsersService.baseUrl; }
        protected getDeletePermission() { return UsersRow.deletePermission; }
        protected getInsertPermission() { return UsersRow.insertPermission; }
        protected getUpdatePermission() { return UsersRow.updatePermission; }

        protected form = new UsersForm(this.idPrefix);
        protected onDialogOpen() {
            super.onDialogOpen();
            ExUserID = this.form.UserId.value;



        }
        protected onDialogClose() {
            super.onDialogClose();
            var Path = window.location.href.replace(/(\#.*)/, '');
            window.location.href = Path;
        }
        protected afterLoadEntity() {
            super.afterLoadEntity();
            if (this.isEditMode()) {
                this.toolbar.findButton("save-and-close-button").hide();
                this.saveAndCloseButton.hide();
                $('.save-and-close-button').hide();
                this.toolbar.findButton("delete-button").hide();
                this.element.find('.add-button').hide();

                this.applyChangesButton.hide();
                this.form.DetailList.onItemsChanged = () => {
                    this.saveAndCloseButton.show();
                    this.toolbar.findButton("save-and-close-button").show();
                }
            }

        }
        //add button and call function
        protected getButtons() {
            var buttons = super.getToolbarButtons();
            buttons.push({
                title: 'Add',
                cssClass: 'add-button',
                onClick: () => {

                    //write hellow world in console
                    console.log("hellow world");
                }
            });
            return buttons;
        }
    }
}