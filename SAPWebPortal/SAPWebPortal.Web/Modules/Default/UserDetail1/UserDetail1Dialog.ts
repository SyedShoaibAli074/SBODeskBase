
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class UserDetail1Dialog extends _Ext.EditorDialogBase<UserDetail1Row> {
        protected getFormKey() { return UserDetail1Form.formKey; }
        //protected getIdProperty() { return UserDetail1Row.idProperty; }
        protected getLocalTextPrefix() { return UserDetail1Row.localTextPrefix; }
       // protected getNameProperty() { return UserDetail1Row.nameProperty; }GetCardName
        protected getService() { return UserDetail1Service.baseUrl; }
        //protected getDeletePermission() { return UserDetail1Row.deletePermission; }
        //protected getInsertPermission() { return UserDetail1Row.insertPermission; }
        //protected getUpdatePermission() { return UserDetail1Row.updatePermission; }
        // make a variable of type UserDetail1Dialog 
        public static Form: UserDetail1Form;
        protected form = new UserDetail1Form(this.idPrefix);
        
        constructor() {
            super();
            UserDetail1Dialog.Form = this.form;
        }
        
        // on form load
        protected afterLoadEntity() { 
            // check if the form is in insert mode
            this.undeleteButton.hide();
            this.cloneButton.hide();
            this.localizationButton.hide();
            this.form.CardCode.changeSelect2(e => {
                var cardname = "";
                var id = this.form.CardCode.value;
                var data = { Code: id, DBName: localStorage.getItem("DBName") };
                if (id != "") {
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Services/Default/UserDetail1/GetCardName'),
                        request: data,
                        async: false,
                        onSuccess: response => {
                            console.log(response);
                            cardname = (response["cardname"]);


                        }

                    });
                    this.form.CardName.value = cardname;
                }
                else {
                    this.form.CardName.value = "";
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
                var editorSelect = SAPWebPortal.Default.CardCodeValuesEditor.editorSelect;
                
                try {
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Services/Default/BusinessPartner/GetCardCodeCardNameForAuth'),
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
                //Q.serviceRequest(Q.resolveUrl('~/Services/Default/BusinessPartner/GetCardCodeCardNameForAuth'), null, response => {
                //    for (var i = 0; i < response.length; i++) {
                //        editorSelect.addOption(response[i].Item1, response[i].Item1/* + "-" + response[i].Item2*/);
                //    }
                //});

            }
            else {
                try {
                    var editorSelect = SAPWebPortal.Default.CardCodeValuesEditor.editorSelect;
                    var condition = editorSelect.items.length;
                    for (var ind = 0; ind < condition; ind++) {
                        editorSelect.items.pop()
                    }
                    Q.serviceCall({
                        url: Q.resolveUrl('~/Services/Default/BusinessPartner/GetCardCodeCardNameForAuth'),
                        request: window.localStorage.getItem("DBName"),

                        async: false,
                        onSuccess: response => {
                            var count = Object.keys(response).length;
                            for (var ind = 0; ind < count; ind++) {
                                //console.log(response[ind]["Text"]);
                                editorSelect.addOption(response[ind].Item1, response[ind].Item1 + "-" + response[ind].Item2);
                            }
                            editorSelect.set_value(this.entity.CardCode);
                            return true
                        }
                    });
                } catch (e) { console.log(e) }

                //


                //Q.serviceRequest(Q.resolveUrl('~/Services/Default/BusinessPartner/GetCardCodeCardNameForAuth'), null, response => {
                //    for (var i = 0; i < response.length; i++) {
                //        editorSelect.addOption(response[i].Item1, response[i].Item1/* + "-" + response[i].Item2*/);
                //    }
                //});

                //editorSelect.set_value(this.entity.CardCode);
			}
        }

    }
}