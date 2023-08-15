namespace SAPWebPortal.Default {
    export namespace ItemService {
        export const baseUrl = 'Default/Item';

        export declare function Create(request: Serenity.SaveRequest<ItemRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<ItemRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ItemRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ItemRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetAllDataDictionary(request: Serenity.ServiceRequest, onSuccess?: (response: System.ValueTuple<string, string, string, number>[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Default/Item/Create",
            Update = "Default/Item/Update",
            Delete = "Default/Item/Delete",
            Retrieve = "Default/Item/Retrieve",
            List = "Default/Item/List",
            GetAllDataDictionary = "Default/Item/GetAllDataDictionary"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetAllDataDictionary'
        ].forEach(x => {
            (<any>ItemService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
