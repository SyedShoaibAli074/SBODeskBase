namespace SAPWebPortal.InventoryCounting {
    export namespace InventoryCountingLineService {
        export const baseUrl = 'InventoryCounting/InventoryCountingLine';

        export declare function Create(request: Serenity.SaveRequest<InventoryCountingLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<InventoryCountingLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<InventoryCountingLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<InventoryCountingLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "InventoryCounting/InventoryCountingLine/Create",
            Update = "InventoryCounting/InventoryCountingLine/Update",
            Delete = "InventoryCounting/InventoryCountingLine/Delete",
            Retrieve = "InventoryCounting/InventoryCountingLine/Retrieve",
            List = "InventoryCounting/InventoryCountingLine/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>InventoryCountingLineService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
