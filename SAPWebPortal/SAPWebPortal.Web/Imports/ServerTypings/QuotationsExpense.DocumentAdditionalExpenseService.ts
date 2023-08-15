namespace SAPWebPortal.QuotationsExpense {
    export namespace DocumentAdditionalExpenseService {
        export const baseUrl = 'QuotationsExpense/DocumentAdditionalExpense';

        export declare function Create(request: Serenity.SaveRequest<DocumentAdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<DocumentAdditionalExpenseRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<DocumentAdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<DocumentAdditionalExpenseRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "QuotationsExpense/DocumentAdditionalExpense/Create",
            Update = "QuotationsExpense/DocumentAdditionalExpense/Update",
            Delete = "QuotationsExpense/DocumentAdditionalExpense/Delete",
            Retrieve = "QuotationsExpense/DocumentAdditionalExpense/Retrieve",
            List = "QuotationsExpense/DocumentAdditionalExpense/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>DocumentAdditionalExpenseService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
