
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class BusinessPartnerDialog extends Serenity.EntityDialog<BusinessPartnerRow, any> {
        protected getFormKey() { return BusinessPartnerForm.formKey; }
        protected getIdProperty() { return BusinessPartnerRow.idProperty; }
        protected getLocalTextPrefix() { return BusinessPartnerRow.localTextPrefix; }
        protected getNameProperty() { return BusinessPartnerRow.nameProperty; }
        protected getService() { return BusinessPartnerService.baseUrl; }
        protected getDeletePermission() { return BusinessPartnerRow.deletePermission; }
        protected getInsertPermission() { return BusinessPartnerRow.insertPermission; }
        protected getUpdatePermission() { return BusinessPartnerRow.updatePermission; }

        protected form = new BusinessPartnerForm(this.idPrefix);
        public static Form: BusinessPartnerForm;
        constructor(opt?: any) {
            super(opt);
            BusinessPartnerDialog.Form = this.form;
            var service = this.getService();
            
        }

        helper: SAPWebPortal.Helpers.BusinessFormHelper
        afterLoadEntity() { 
            super.afterLoadEntity();
            //send custom data from dialog to endpoint

            
           
            

                



            var service = this.getService();
            var dropdownfields = SAPWebPortal.Default.SelectCodeNameValueEditor.dropdownfields;
            this.helper = new SAPWebPortal.Helpers.BusinessFormHelper(this.form, dropdownfields, service, this);
            this.loadEntity(this.entity);
            this.form.DBName.value = localStorage.getItem("DBName");
            this.form.Series.changeSelect2(e => {
                var crd = "";
                try {
                    if ((e as any).added.source == false) {
                        Serenity.EditorUtils.setReadOnly(this.form.CardCode, false);
                        this.form.CardCode.value = "";
                    }
                    else {
                        var data = { Code: this.form.Series.value.toString(), DBName: localStorage.getItem("DBName") };
                        Serenity.EditorUtils.setReadOnly(this.form.CardCode, true);
                        Q.serviceCall({
                            url: Q.resolveUrl('~/Services/' + service + '/GetNextNumber'),
                            request: data,
                            async: false,
                            onSuccess: response => {
                                crd = response as string;

                            }
                        });
                        this.form.CardCode.value = crd;
                    }
                }
                catch
                { }

            }); 
        }
        beforeLoadEntity() {
            super.beforeLoadEntity(this.entity);
           
        }
    }
}