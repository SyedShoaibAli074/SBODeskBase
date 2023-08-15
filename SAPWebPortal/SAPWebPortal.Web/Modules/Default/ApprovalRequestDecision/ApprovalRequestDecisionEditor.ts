
namespace SAPWebPortal.Default {
    @Serenity.Decorators.registerClass()
    export class ApprovalRequestDecisionEditor extends _Ext.GridEditorBase<ApprovalRequestDecisionRow> {
        protected getColumnsKey() { return "Default.ApprovalRequestDecision"; }
        protected getDialogType() { return ApprovalRequestDecisionDialog; }
        protected getLocalTextPrefix() { return ApprovalRequestDecisionRow.localTextPrefix; }
      
        constructor(container: JQuery) {
            super(container);
            this.slickGrid.onCellChange.subscribe((e, args) => {
                let cell = args.cell;
                let row = args.row;
                let grid = args.grid as Slick.Grid;
                let item = args.item as ApprovalRequestDecisionRow;

                var productID = Q.toId(item.Status);
                if (productID != null)
                    if (item.Status == "0") {
                        item.Status = "ardPending"
                    }
                    else if (item.Status == "1") {
                        item.Status = "ardApproved"
                    }
                    else if (item.Status == "2") {
                        item.Status = "ardNotApproved"

                    }

                   
                

                
            }); 
        }
        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.editable = true;
            opt.autoEdit = true;
            return opt;
        }
        
        protected getButtons() {
            let buttons = super.getButtons();
            buttons = [];
            buttons.push({
                title: "Add Decision",
                cssClass: "add-Decision",
                icon: 'fa fa-plus-circle text-green',
                onClick: () => {
                    var HeaderForm = SAPWebPortal.Default.ApprovalRequestDialog.Form;
                  
                    let Decision = this.value;
                    Decision.push({
                        Status: "ardPending",
                        });
                    this.value = Decision;
                    
                }
            });
            return buttons;
        }
    }
}