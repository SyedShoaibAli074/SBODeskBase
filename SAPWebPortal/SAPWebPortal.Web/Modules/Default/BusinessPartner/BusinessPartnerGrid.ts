
namespace SAPWebPortal.Default {

    @Serenity.Decorators.registerClass()
    export class BusinessPartnerGrid extends _Ext.GridBase1<BusinessPartnerRow, any> {
        protected getColumnsKey() { return BusinessPartnerColumns.columnsKey; }
        protected getDialogType() { return BusinessPartnerDialog; }
        protected getIdProperty() { return BusinessPartnerRow.idProperty; }
        protected getInsertPermission() { return BusinessPartnerRow.insertPermission; }
        protected getLocalTextPrefix() { return BusinessPartnerRow.localTextPrefix; }
        protected getService() { return BusinessPartnerService.baseUrl; }

        constructor(container: JQuery, options?) {
            options.SomeProp = 15;
            super(container, options);
        }

        protected getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
            /*var Orders = SAPWebPortal.Orders.DocumentDialog.Form;
            var Quotations = SAPWebPortal.Quotations.DocumentDialog.Form;
            if (Orders != undefined) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }
            if (Quotations != undefined) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }*/
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            ////add refresh button 
            //buttons.push({
            //    title: 'Refresh from SAP',
            //    cssClass: 'refresh-button',
            //    onClick: () => {
            //       //call ajax to call a funciotn in backend
            //        Q.serviceRequest('Default/BusinessPartner/RefreshFromSAPPAS', {}, (response) => {
            //        });
                  
            //        this.refresh();
            //    }
            //}
            //);
            
            return buttons;
        }
        protected getViewOptions() {
            let opt = super.getViewOptions();
            //Default option
            opt.rowsPerPage = 20;
            return opt;
        }
        protected getPagerOptions() {
            let opt = super.getPagerOptions();
            //Options in the dropdown
            opt.rowsPerPageOptions = [10, 20];
            return opt;
        }
        //refresh button click event 
        protected onViewSubmit(): boolean {
            if (!super.onViewSubmit())
            { return false; }
            let request = this.view.params as Serenity.ListRequest;
            var DB = localStorage.getItem("DBName");
            request.CompanyDB = DB;
            return true;
        }
        
    }
}