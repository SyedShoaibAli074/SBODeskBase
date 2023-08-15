namespace SAPWebPortal.Default {


    @Serenity.Decorators.registerEditor()
    export class SalesPersonValuesEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null); 
            SalesPersonValuesEditor.editorSelect = this;
            //Q.serviceRequest(Q.resolveUrl('~/Services/Default/UserDetail2/GetSalesPersonNameForAuth'), null, response => {
            //    for (var i = 0; i < response.length; i++) {
            //        this.addOption(response[i].Item1, response[i].Item1 + "-" + response[i].Item2);
            //    }
            //});



        }
    }
}