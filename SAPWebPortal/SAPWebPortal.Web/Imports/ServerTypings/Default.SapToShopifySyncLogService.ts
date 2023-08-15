namespace SAPWebPortal.Default {
    export namespace SapToShopifySyncLogService {
        export const baseUrl = 'Default/SapToShopifySyncLog';

        export declare function Create(request: Serenity.SaveRequest<SapToShopifySyncLogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<SapToShopifySyncLogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<SapToShopifySyncLogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SapToShopifySyncLogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Default/SapToShopifySyncLog/Create",
            Update = "Default/SapToShopifySyncLog/Update",
            Delete = "Default/SapToShopifySyncLog/Delete",
            Retrieve = "Default/SapToShopifySyncLog/Retrieve",
            List = "Default/SapToShopifySyncLog/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>SapToShopifySyncLogService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
