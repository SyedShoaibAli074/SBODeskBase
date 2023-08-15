namespace SAPWebPortal.IncomingPayment {
    export namespace PaymentCreditCardService {
        export const baseUrl = 'IncomingPayment/PaymentCreditCard';

        export declare function Create(request: Serenity.SaveRequest<PaymentCreditCardRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<PaymentCreditCardRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<PaymentCreditCardRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<PaymentCreditCardRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "IncomingPayment/PaymentCreditCard/Create",
            Update = "IncomingPayment/PaymentCreditCard/Update",
            Delete = "IncomingPayment/PaymentCreditCard/Delete",
            Retrieve = "IncomingPayment/PaymentCreditCard/Retrieve",
            List = "IncomingPayment/PaymentCreditCard/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>PaymentCreditCardService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
