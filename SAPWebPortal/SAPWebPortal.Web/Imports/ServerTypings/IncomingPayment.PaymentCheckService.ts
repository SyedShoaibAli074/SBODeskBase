namespace SAPWebPortal.IncomingPayment {
    export namespace PaymentCheckService {
        export const baseUrl = 'IncomingPayment/PaymentCheck';

        export declare function Create(request: Serenity.SaveRequest<PaymentCheckRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<PaymentCheckRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<PaymentCheckRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<PaymentCheckRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "IncomingPayment/PaymentCheck/Create",
            Update = "IncomingPayment/PaymentCheck/Update",
            Delete = "IncomingPayment/PaymentCheck/Delete",
            Retrieve = "IncomingPayment/PaymentCheck/Retrieve",
            List = "IncomingPayment/PaymentCheck/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>PaymentCheckService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
