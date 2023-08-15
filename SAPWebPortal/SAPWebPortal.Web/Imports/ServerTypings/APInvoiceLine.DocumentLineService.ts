namespace SAPWebPortal.APInvoiceLine {
    export namespace DocumentLineService {
        export const baseUrl = 'APInvoiceLine/DocumentLine';

        export declare function Create(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<DocumentLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function GetGLAccounts(request: Serenity.ServiceRequest, onSuccess?: (response: System.ValueTuple<string, string>[]) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "APInvoiceLine/DocumentLine/Create",
            Update = "APInvoiceLine/DocumentLine/Update",
            Delete = "APInvoiceLine/DocumentLine/Delete",
            Retrieve = "APInvoiceLine/DocumentLine/Retrieve",
            List = "APInvoiceLine/DocumentLine/List",
            GetGLAccounts = "APInvoiceLine/DocumentLine/GetGLAccounts"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List', 
            'GetGLAccounts'
        ].forEach(x => {
            (<any>DocumentLineService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
