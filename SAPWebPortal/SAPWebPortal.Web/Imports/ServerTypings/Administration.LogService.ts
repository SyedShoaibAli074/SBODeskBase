namespace SAPWebPortal.Administration {
    export namespace LogService {
        export const baseUrl = 'Administration/Log';

        export declare function Create(request: Serenity.SaveRequest<LogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<LogRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<LogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function HeartBeat(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LogRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Administration/Log/Create",
            Update = "Administration/Log/Update",
            Delete = "Administration/Log/Delete",
            Retrieve = "Administration/Log/Retrieve",
            HeartBeat = "Administration/Log/HeartBeat",
            List = "Administration/Log/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'HeartBeat', 
            'List'
        ].forEach(x => {
            (<any>LogService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
