
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class UserDetail2Dialog extends _Ext.EditorDialogBase<UserDetail2Row> {
        protected getFormKey() { return UserDetail2Form.formKey; }
        //protected getIdProperty() { return UserDetail2Row.idProperty; }
        protected getLocalTextPrefix() { return UserDetail2Row.localTextPrefix; }
        //protected getNameProperty() { return UserDetail2Row.nameProperty; }
        protected getService() { return UserDetail2Service.baseUrl; }
        //protected getDeletePermission() { return UserDetail2Row.deletePermission; }
        //protected getInsertPermission() { return UserDetail2Row.insertPermission; }
        //protected getUpdatePermission() { return UserDetail2Row.updatePermission; }

        protected form = new UserDetail2Form(this.idPrefix);
        public static Form: UserDetail2Form;
        constructor() {
            super();
            UserDetail2Dialog.Form = this.form;
        }
        protected afterLoadEntity() {
            this.undeleteButton.hide();
            this.cloneButton.hide();
            this.localizationButton.hide();

           // //changeselect2
            
           ////get SalesPersonCode value From form 



            this.form.SalesPersonCode.changeSelect2(e => {
                //get SalesPersonCode value from form
                var salepersnname = "";
                var id = this.form.SalesPersonCode.value;
                var data = { Code: id, DBName: localStorage.getItem("DBName") };
                if (id != "") {
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Services/Default/UserDetail2/GetSlpName'),
                        request: data,
                        async: false,
                        onSuccess: response => {
                            console.log(response);
                            salepersnname = (response["slpname"]);


                        }

                    });
                    this.form.SalesPersonName.value = salepersnname;
                }
                else {
                    this.form.SalesPersonName.value = "";
                }
               
                
            });
          
            if (this.isNew()) {
                this.form.UserCode.value = SAPWebPortal.Administration.UserDialog.Form.Username.value;
                this.form.UserName.value = SAPWebPortal.Administration.UserDialog.Form.Username.value;
                this.form.DbName.value = SAPWebPortal.Administration.UserDialog.Form.CompanyDatabase.value;
                // get element from main page with the id of departmentsDropdown
                var departmentsDropdown = document.getElementById("departmentsDropdown");
                // get the selected value from the dropdown
                // print type of departmentsDropdown     
                var selectedDepartment = departmentsDropdown.options[departmentsDropdown.selectedIndex].value;
                this.form.DbName.value = selectedDepartment;
                //get header form and get the value of the field
                //this.undeleteButton.hide();
                //this.cloneButton.hide();
                //this.localizationButton.hide();
                var editorSelect = SAPWebPortal.Default.SalesPersonValuesEditor.editorSelect;
                try {
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Services/Default/UserDetail2/GetSalesPersonNameForAuth'),
                        request: window.localStorage.getItem("DBName"),
                        async: false,
                        onSuccess: response => {
                            var count = Object.keys(response).length;
                            for (var ind = 0; ind < count; ind++) {
                                //console.log(response[ind]["Text"]);
                                editorSelect.addOption(response[ind].Item1, response[ind].Item1 + "-" + response[ind].Item2);
                            }
                        }
                    })
                } catch (e) { console.log(e) }

            }else
            {
                try {
                    var editorSelect = SAPWebPortal.Default.SalesPersonValuesEditor.editorSelect;
                    var condition = editorSelect.items.length;
                    for (var ind = 0; ind < condition; ind++) {
                        editorSelect.items.pop()
                    }
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Services/Default/UserDetail2/GetSalesPersonNameForAuth'),
                        request: window.localStorage.getItem("DBName"),

                        async: false,
                        onSuccess: response => {
                            var count = Object.keys(response).length;
                            for (var ind = 0; ind < count; ind++) {
                                //console.log(response[ind]["Text"]);
                                editorSelect.addOption(response[ind].Item1, response[ind].Item1 + "-" + response[ind].Item2);
                            }
                            editorSelect.set_value(this.entity.SalesPersonCode);
                            return true
                        }
                    });
                } catch (e) { console.log(e) }


               


                //Q.serviceRequest(Q.resolveUrl('~/Services/Default/BusinessPartner/GetCardCodeCardNameForAuth'), null, response => {
                //    for (var i = 0; i < response.length; i++) {
                //        editorSelect.addOption(response[i].Item1, response[i].Item1 + "-" + response[i].Item2);
                //    }
                //});

                //editorSelect.set_value(this.entity.SalesPersonCode);
			}
        }
    }
}