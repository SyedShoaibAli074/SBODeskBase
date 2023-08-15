namespace SAPWebPortal.Modules.DropDownEnums {
    @Serenity.Decorators.registerEditor()
    export class ApprovalDocsEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);
            this.addOption("13", "A/R Invoice");
            this.addOption("14", "A/R Credit Memo");
            this.addOption("15", "Delivery");
            this.addOption("16", "Return");
            this.addOption("17", "Sales Order");
            this.addOption("18", "A/P Invoice");
            this.addOption("19", "A/P Credit Memo");
            this.addOption("20", "Goods Receipt PO");
            this.addOption("21", "Goods Return");
            this.addOption("22", "Purchase Order");
            this.addOption("23", "Sales Quotation");
            this.addOption("46", "Outgoing Payments");
            this.addOption("59", "Goods Receipt");
            this.addOption("60", "Goods Issue");
            this.addOption("67", "Inventory Transfer");
            this.addOption("203", "A/R Down Payment");
            this.addOption("204", "A/P Down Payment");
            this.addOption("310000001", "Inventory Opening Balance");
            this.addOption("1250000001", "Inventory Transfer Request");
            this.addOption("540000006", "Purchase Quotation");
            this.addOption("234000031", "Return Request");
            this.addOption("234000032 ", "Goods Return Request");
            this.addOption("1470000113", "Purchase Request");
            this.addOption("10000071", "Inventory Posting	");
            this.addOption("1470000065", "Inventory Counting");
            this.addOption("1250000025", "Blanket Agreement");
        }
    }
}