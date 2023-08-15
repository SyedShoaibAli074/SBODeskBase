

namespace SAPWebPortal.Orders.Document  {

   
    @Serenity.Decorators.registerEditor()
    export class SelectCodeNameValueEditor extends Serenity.Select2Editor<any, any> {

        public static dropdownfields: Array<string> = new Array<string>();
        public static editorSelect: Serenity.Select2Editor<any, any>;
         constructor(container: JQuery, opt?: any) {
             super(container, opt);
             SelectCodeNameValueEditor.dropdownfields.push(opt.propertyNameSAP);
            //BusinessPartnerDialog.Form.CardType.changeSelect2((e) => {

            //});
          //call data collection for dropdown
             SelectCodeNameValueEditor.editorSelect = this;

             
            
        }

        
    }
}