namespace SAPWebPortal.Modules.DropDownEnums {
    @Serenity.Decorators.registerEditor()
    export class DraftDocsEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);
            this.addOption("oInvoices", "A/R Invoice");
            this.addOption("oCreditNotes", "A/R Credit Memo");
            this.addOption("oDeliveryNotes", "Delivery");
            this.addOption("oReturns", "Return");
            this.addOption("oOrders", "Sales Order");
            this.addOption("oPurchaseInvoices", "A/P Invoice");
            this.addOption("oPurchaseCreditNotes", "A/P Credit Memo");
            this.addOption("20", "Goods Receipt PO");
            this.addOption("21", "Goods Return");
            this.addOption("oPurchaseOrders", "Purchase Order");
            this.addOption("oQuotations", "Sales Quotation");
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
            this.addOption("oPurchaseRequest", "Purchase Request");
            this.addOption("10000071", "Inventory Posting	");
            this.addOption("1470000065", "Inventory Counting");
            this.addOption("1250000025", "Blanket Agreement");
        }
    }
}