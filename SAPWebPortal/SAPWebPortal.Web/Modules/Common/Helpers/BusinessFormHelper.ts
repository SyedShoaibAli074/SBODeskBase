namespace SAPWebPortal.Helpers {
    export class BusinessFormHelper { 
        constructor(form?: Serenity.PrefixedContext, dropdownfields?: string[], service?: string, dialog?: any) {
            this.form = form;
            this.entity = dialog.getSaveEntity();;


            var bpdialogthis = this; 
            this. dropdownfields = dropdownfields;
            var f = this.form;
            this.service = service;
            interface Map<T> {
                [K: string]: T;
            }
            let dic: Map<Array<string>> = {};
            let list: string[] = [];
            let listofsource: string[] = []; 
            for (let prop in dropdownfields) {
                var c = f[dropdownfields[prop]]; 
                if (c !== undefined) {
                    $('<a id = "refresh_' + dropdownfields[prop] + '" class="inplace-create form_' + bpdialogthis.form.idPrefix +'" style="margin-left: 5px;background-color:transprent;width: 22px;height: 16px;background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAsBJREFUeNqkU1lrE1EUPpOZSdJMk26pTVuwmrQPVVB0lEaLG5Yg6oMWXMA+K4L47i/w1Vdf1IeoUMUFIZYigoSCC1NpsRZpljY1tU0zZk/m3tk802hb0bdeOHPnnuU73zn3XMY0TdjK4qzPifuZu7iJ/7FLKLdReJQyJpMNXaeapoGmqvDxZqAOoOt6FExTvBTqEgmpM+JYBp6+XYLzxzt75AJtT2cVmlqulQ0dZtH8408Gm/VBtDCijj2MpCTGNKBSUoEQHaxMKjUYgWc7+nyunjOH2nfbOTOEyfx/AaiEdIGuDp4d2CZmM1VwOlCnqBhM4cmbZOnDzIq7XCO9eVkJhA549zGgXzQNo3mDAaXDO3zO3kKuChxnwqPInMTbUU8IYM1SKl0Yfx1dqCmU+uVMpXe717EHY46sN5ESMtgmcK2UqDCdlON4fv/g+dc6RwSx2WyT2EDfdCwr9nd5ur1ujqDPMbS+qpegKH2sDVwa1h9PruZ1TbuB2e+gSLVyGUq5nMUykkiu2tGnG339GHNwM4NKTTOLqmau/RtVLIXnw3gfYSzBuuJopVgMsxwnVDTTw8Oan7ABoCifVkvEozOso90r0PRi9jRmjvAOB/yeD0uCPl9Ts6wYwIJaxZi5zbfwLvU9OysDn2jZ2V3D7h/FmvcryARtcHL4sIh70LsrEEAfWEzLP/E8sQFAaXT+28K0s1mIpVkh4R8KNrg7WkLYCxGpQrxqg70XhsRYzQaG4ILYzHwMY56tA2CdeaVcHZVGxz67mhriS86mmDEQLHVePufG5kGBtcNUiYWWVhdMhV9ItFKZwBKW1gGshZQT1Xxx/Mu90Rl1cnLByMkrBIfCGibDzkNDox2WDQ76r18RUXcKp3fEimOs1+gZeQz62thSi40ddW1oa2QYRsX9Fp7/eWhok7SXV68xW33OvwQYAE/grplzD+BKAAAAAElFTkSuQmCC);"><b><\/b><\/a>')

                        .insertAfter(c.element)  // <======================
                        .click(function (e) {

                            bpdialogthis.entity = dialog.getSaveEntity();
                            bpdialogthis.service = dialog.getService();
                            var fieldname = e.currentTarget.previousSibling.id.split("_")[e.currentTarget.previousSibling.id.split("_").length - 1];
                            var c1 = f[fieldname]; 
                            try {
                                bpdialogthis.FillDropDown(c1.options.propertyNameSAP);
                            } catch (ex) {
                                console.log(fieldname);
                            }
                        });
                
               
                
                
                if (c.options !== undefined && c.options.CascadeSourceFields !== undefined) {
                    var t = c.options.propertyNameSAP !== undefined;
                    var propertyNameSAP = "";
                    if (t)
                        propertyNameSAP = c.options.propertyNameSAP;
                    var CascadeSourceFields: string[] = c.options.CascadeSourceFields;

                    if (CascadeSourceFields.length > 0) {
                        CascadeSourceFields.forEach(function (value) {
                            $('#refresh_' + dropdownfields[prop]).addClass(value);
                            f[value].change(e => {
                                var arr = e.currentTarget.id.split("_");
                                var id = arr[arr.length - 1];

                                if (bpdialogthis.form[id].value !== "")
                                    $('.' + id).click();
                            });
                        });
                    }
                    else {
                        $('#refresh_' + dropdownfields[prop]).click();
                        //bpdialogthis.FillDropDown(propertyNameSAP);
                    }

                    }
                }
            }

            $('.form_' + bpdialogthis.form.idPrefix  ).click();
        }
        protected entity: any;
        protected service: string;
        protected dropdownfields: string[];
        protected form: Serenity.PrefixedContext;
        protected FillDropDown(propertyNameSAP: string) {
            if (propertyNameSAP !== undefined) { 
                var f = this.form;
                var ent = this.entity;
                var iambasefield = false;
                if (f[propertyNameSAP].options !== undefined)
                    iambasefield = f[propertyNameSAP].options.CascadeSourceFields.length == 0;
                this.entity.DBName = localStorage.getItem("DBName");
                Q.serviceCall({
                    url: Q.resolveUrl("~/Services/" + this.service + "/GetCodeNameValues"),
                    request: { row: this.entity, propertyNameSAP: propertyNameSAP },
                    async: false,
                    onSuccess: response => {
                        var count = Object.keys(response as object).length;
                        console.log(propertyNameSAP);
                        console.log("~/Services/" + this.service + "/GetCodeNameValues");
                        f[propertyNameSAP].clearItems(); 
                        if (!iambasefield)
                            f[propertyNameSAP].value = null;
                        var index = 0;
                        for (var ind = 0; ind < count; ind++) {
                            f[propertyNameSAP].addOption(response[ind]["Value"], response[ind]["Text"], response[ind]["Disabled"]);
                            if (response[ind]["Selected"] == true) {
                                index = ind;
                            }
                        } 

                    }
                });
            }
        }
    }
}