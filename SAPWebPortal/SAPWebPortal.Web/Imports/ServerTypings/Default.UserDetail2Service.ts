namespace SAPWebPortal.Default {
    export namespace UserDetail2Service {
        export const baseUrl = 'Default/UserDetail2';

        export declare function Create(request: Serenity.SaveRequest<UserDetail2Row>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<UserDetail2Row>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserDetail2Row>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserDetail2Row>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetSlpNameT(request: string, onSuccess?: (response: string) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetSalesPersonNameForAuth(request: any, onSuccess?: (response: System.ValueTuple<string, string>[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function ActiveCompany(request: Serenity.ServiceRequest, onSuccess?: (response: GETBoard_Response) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "Default/UserDetail2/Create",
            Update = "Default/UserDetail2/Update",
            Delete = "Default/UserDetail2/Delete",
            Retrieve = "Default/UserDetail2/Retrieve",
            List = "Default/UserDetail2/List",
            GetSlpNameT = "Default/UserDetail2/GetSlpNameT",
            GetSalesPersonNameForAuth = "Default/UserDetail2/GetSalesPersonNameForAuth",
            ActiveCompany = "Default/UserDetail2/ActiveCompany"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetSlpNameT', 
            'GetSalesPersonNameForAuth', 
            'ActiveCompany'
        ].forEach(x => {
            (<any>UserDetail2Service)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
