namespace SAPWebPortal.Default {
    export namespace SapDatabasesService {
        export const baseUrl = 'Default/SapDatabases';

        export declare function ServiceLayerUrl(request: Serenity.ServiceRequest, onSuccess?: (response: string) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Create(request: Serenity.SaveRequest<SapDatabasesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function ConnecteionTest(request: SapDatabasesRow, onSuccess?: (response: boolean) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<SapDatabasesRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<SapDatabasesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SapDatabasesRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            ServiceLayerUrl = "Default/SapDatabases/ServiceLayerUrl",
            Create = "Default/SapDatabases/Create",
            ConnecteionTest = "Default/SapDatabases/ConnecteionTest",
            Update = "Default/SapDatabases/Update",
            Delete = "Default/SapDatabases/Delete",
            Retrieve = "Default/SapDatabases/Retrieve",
            List = "Default/SapDatabases/List"
        }

        [
            'ServiceLayerUrl', 
            'Create', 
            'ConnecteionTest', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>SapDatabasesService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
