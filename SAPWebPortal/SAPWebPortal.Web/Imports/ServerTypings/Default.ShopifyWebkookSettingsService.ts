namespace SAPWebPortal.Default {
    export namespace ShopifyWebkookSettingsService {
        export const baseUrl = 'Default/ShopifyWebkookSettings';

        export declare function Create(request: Serenity.SaveRequest<ShopifyWebkookSettingsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<ShopifyWebkookSettingsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ShopifyWebkookSettingsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ShopifyWebkookSettingsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Default/ShopifyWebkookSettings/Create",
            Update = "Default/ShopifyWebkookSettings/Update",
            Delete = "Default/ShopifyWebkookSettings/Delete",
            Retrieve = "Default/ShopifyWebkookSettings/Retrieve",
            List = "Default/ShopifyWebkookSettings/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>ShopifyWebkookSettingsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
