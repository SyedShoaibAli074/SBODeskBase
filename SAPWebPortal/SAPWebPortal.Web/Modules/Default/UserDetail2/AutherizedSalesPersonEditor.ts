
//// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace SAPWebPortal.Default {

	@Serenity.Decorators.registerClass()
	export class AutherizedSalesPersonEditor extends _Ext.GridEditorBase<UserDetail2Row> {
		protected getColumnsKey() { return 'Default.UserDetail2'; }

		protected getDialogType() { return UserDetail2Dialog; }
		protected getLocalTextPrefix() { return UserDetail2Row.localTextPrefix; }

		constructor(container: JQuery) {
			super(container);

        }
      

        
        //protected getButtons() {
        //    let buttons = super.getButtons();
        //    buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
        //    buttons.push({
        //        title: "Add Autherized Customers",
        //        cssClass: "Pick-Products-button",
        //        icon: 'fa fa-plus text-green',
        //        onClick: () => {
                   
        //            var pickerDialog = new _Ext.GridItemPickerDialog({
        //                gridType: SAPWebPortal.Default.BusinessPartnerGrid, multiple: true,
        //                    preSelectedKeys: this.value.map(k => k.CardCode)
        //                });
        //            pickerDialog.onSuccess = (selectedBusinessPartner: any[]) => {
        //                let selectedItems2 = selectedBusinessPartner.filter(t => {
        //                        console.log(t);
        //                        console.log(this.view.getItems());

        //                    var test: SAPWebPortal.Default.BusinessPartnerRow = t;

        //                    return !Q.any(this.view.getItems(), n => n.CardCode == test.CardCode)
        //                });
        //                var orderDetails = selectedItems2.map<SAPWebPortal.Default.UserDetail1Row>(r => {
        //                        var v = {
        //                            CardCode: r.CardCode,
        //                            CardName: r.CardName
                                     
        //                        }
                            
                               
        //                        return v;
        //                    });
        //                    for (let orderDetail of orderDetails) {
        //                        orderDetail[this.getIdProperty()] = "`" + this.nextId++;
        //                        this.view.addItem(orderDetail);
        //                    }
        //                }
        //                pickerDialog.dialogOpen();
                    
        //        }
        //    });
        //    return buttons;
        //}
	}
}

