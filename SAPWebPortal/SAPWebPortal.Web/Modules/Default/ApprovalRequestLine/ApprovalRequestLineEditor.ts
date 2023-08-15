
namespace SAPWebPortal.Default {
    import fld = Default.ApprovalRequestLineRow.Fields;
    @Serenity.Decorators.registerClass()
    export class ApprovalRequestLineEditor extends _Ext.GridEditorBase<ApprovalRequestLineRow> {
        protected getColumnsKey() { return "Default.ApprovalRequestLine"; }
        protected getDialogType() { return ApprovalRequestLineDialog; }
        protected getLocalTextPrefix() { return ApprovalRequestLineRow.localTextPrefix; }
      
        constructor(container: JQuery) {
            super(container);
           
        }
        protected getButtons(): Serenity.ToolButton[] {
            var buttons = super.getButtons();
            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            return buttons;
        }
        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.editable = false;
            return opt;
        }
        public DisableModifyIcon() {
            var columns = this.slickGrid.getColumns();
            columns.splice(0, 1);   // *** Delete delete icon column ***
            columns.splice(0, 1);   // *** Delete modify icon column ***
            this.slickGrid.setColumns(columns);
        }
    }
}