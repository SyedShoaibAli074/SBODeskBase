namespace SAPWebPortal.Default {
    export namespace BPPaymentMethodsService {
        export const baseUrl = 'Default/BPPaymentMethods';

        export declare function Create(request: Serenity.SaveRequest<BPPaymentMethodsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<BPPaymentMethodsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BPPaymentMethodsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BPPaymentMethodsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Default/BPPaymentMethods/Create",
            Update = "Default/BPPaymentMethods/Update",
            Delete = "Default/BPPaymentMethods/Delete",
            Retrieve = "Default/BPPaymentMethods/Retrieve",
            List = "Default/BPPaymentMethods/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>BPPaymentMethodsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
