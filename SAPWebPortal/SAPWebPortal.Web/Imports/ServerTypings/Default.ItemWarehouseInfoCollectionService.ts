namespace SAPWebPortal.Default {
    export namespace ItemWarehouseInfoCollectionService {
        export const baseUrl = 'Default/ItemWarehouseInfoCollection';

        export declare function Create(request: Serenity.SaveRequest<ItemWarehouseInfoCollectionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<ItemWarehouseInfoCollectionRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ItemWarehouseInfoCollectionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ItemWarehouseInfoCollectionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Default/ItemWarehouseInfoCollection/Create",
            Update = "Default/ItemWarehouseInfoCollection/Update",
            Delete = "Default/ItemWarehouseInfoCollection/Delete",
            Retrieve = "Default/ItemWarehouseInfoCollection/Retrieve",
            List = "Default/ItemWarehouseInfoCollection/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>ItemWarehouseInfoCollectionService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
