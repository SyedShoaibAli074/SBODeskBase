namespace SAPWebPortal.Administration {
    export namespace UserFormAuthorizationsService {
        export const baseUrl = 'Administration/UserFormAuthorizations';

        export declare function Create(request: Serenity.SaveRequest<UserFormAuthorizationsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<UserFormAuthorizationsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserFormAuthorizationsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserFormAuthorizationsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Administration/UserFormAuthorizations/Create",
            Update = "Administration/UserFormAuthorizations/Update",
            Delete = "Administration/UserFormAuthorizations/Delete",
            Retrieve = "Administration/UserFormAuthorizations/Retrieve",
            List = "Administration/UserFormAuthorizations/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>UserFormAuthorizationsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
