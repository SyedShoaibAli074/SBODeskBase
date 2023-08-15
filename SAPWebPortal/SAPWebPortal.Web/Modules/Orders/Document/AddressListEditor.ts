

namespace SAPWebPortal.Orders.Document  {

   
    @Serenity.Decorators.registerEditor()
    export class AddressListEditor extends Serenity.Select2Editor<any, any> {

        public static dropdownfields: Array<string> = new Array<string>();
        public static editorSelect: Serenity.Select2Editor<any, any>;
         constructor(container: JQuery, opt?: any) {
             super(container, null);
           
             AddressListEditor.editorSelect = this;

             
            
        }

        
    }
}