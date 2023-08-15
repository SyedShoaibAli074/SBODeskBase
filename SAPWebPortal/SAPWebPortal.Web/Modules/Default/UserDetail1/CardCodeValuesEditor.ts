namespace SAPWebPortal.Default {


    @Serenity.Decorators.registerEditor()
    export class CardCodeValuesEditor extends Serenity.Select2Editor<any, any> {
        static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);

            CardCodeValuesEditor.editorSelect = this;
            // call get CardCode, CardName from a service using ajax 
            ////Services/Default/BusinessPartner
            //Q.serviceRequest(Q.resolveUrl('~/Services/Default/BusinessPartner/GetCardCodeCardNameForAuth'), null, response => { 
            //    for (var i = 0; i < response.length; i++) {
            //        this.addOption(response[i].Item1, response[i].Item1 /*+ "-"+ response[i].Item2*/);
            //    }
            //});
            
        }
    }
}