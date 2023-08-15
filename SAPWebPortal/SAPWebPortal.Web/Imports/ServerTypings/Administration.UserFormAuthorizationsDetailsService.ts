namespace SAPWebPortal.Administration {
    export namespace UserFormAuthorizationsDetailsService {
        export const baseUrl = 'Administration/UserFormAuthorizationsDetails';

        export declare function Create(request: Serenity.SaveRequest<UserFormAuthorizationsDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<UserFormAuthorizationsDetailsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserFormAuthorizationsDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserFormAuthorizationsDetailsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Administration/UserFormAuthorizationsDetails/Create",
            Update = "Administration/UserFormAuthorizationsDetails/Update",
            Delete = "Administration/UserFormAuthorizationsDetails/Delete",
            Retrieve = "Administration/UserFormAuthorizationsDetails/Retrieve",
            List = "Administration/UserFormAuthorizationsDetails/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>UserFormAuthorizationsDetailsService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
