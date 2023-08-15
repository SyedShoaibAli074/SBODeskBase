namespace SAPWebPortal.InventoryCounting {
    export namespace InventoryCountingService {
        export const baseUrl = 'InventoryCounting/InventoryCounting';

        export declare function Create(request: Serenity.SaveRequest<InventoryCountingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CreateInSAP(request: Serenity.SaveRequest<InventoryCountingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<InventoryCountingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<InventoryCountingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<InventoryCountingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "InventoryCounting/InventoryCounting/Create",
            CreateInSAP = "InventoryCounting/InventoryCounting/CreateInSAP",
            Update = "InventoryCounting/InventoryCounting/Update",
            Delete = "InventoryCounting/InventoryCounting/Delete",
            Retrieve = "InventoryCounting/InventoryCounting/Retrieve",
            List = "InventoryCounting/InventoryCounting/List"
        }

        [
            'Create', 
            'CreateInSAP', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>InventoryCountingService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
