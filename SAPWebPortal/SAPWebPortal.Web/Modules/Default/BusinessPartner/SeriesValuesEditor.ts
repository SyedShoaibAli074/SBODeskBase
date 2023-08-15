

namespace SAPWebPortal.Default {

   
    @Serenity.Decorators.registerEditor()
    export class  SeriesValuesEditor extends Serenity.Select2Editor<any, any> {

         public static editorSelect: Serenity.Select2Editor<any, any>;
        constructor(container: JQuery) {
            super(container, null);
            
            //BusinessPartnerDialog.Form.CardType.changeSelect2((e) => {

            //});
          //call data collection for dropdown
            SeriesValuesEditor.editorSelect = this;
            
            //Q.serviceCall({
            //    url: Q.resolveUrl('~/Services/Default/Ocrd/getSeriesList'),

            //    async: false,
            //    onSuccess: response => {
            //        var count = Object.keys(response as object).length;
            //        for (var ind = 0; ind < count; ind++) {
            //            //console.log(response[ind]["Text"]);
            //            this.addOption(response[ind]["Value"], response[ind]["Text"]);
            //        }
            //    }
            //});
            
        }
        
    }
}