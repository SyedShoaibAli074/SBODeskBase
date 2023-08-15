namespace SAPWebPortal.Web.Modules.SAPApp {
    export namespace ShopifyWebhooksService {
        export const baseUrl = 'ShopifyWebhooksController/Api';

        export declare function CreateBusinessPartner(request: any, onSuccess?: (response: Microsoft.AspNetCore.Mvc.IActionResult) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function LogTest(request: any, onSuccess?: (response: Microsoft.AspNetCore.Mvc.IActionResult) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function UpdateBusinessPartner(request: any, onSuccess?: (response: Microsoft.AspNetCore.Mvc.IActionResult) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CreateSalesOrder(request: any, onSuccess?: (response: Microsoft.AspNetCore.Mvc.IActionResult) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function UpdateSalesOrder(request: any, onSuccess?: (response: Microsoft.AspNetCore.Mvc.IActionResult) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CancelSalesOrder(request: any, onSuccess?: (response: Microsoft.AspNetCore.Mvc.IActionResult) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CreateDeliveryNote(request: any, onSuccess?: (response: Microsoft.AspNetCore.Mvc.IActionResult) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CheckOrderPayment(request: any, onSuccess?: (response: Microsoft.AspNetCore.Mvc.IActionResult) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function CreateReturn(request: any, onSuccess?: (response: Microsoft.AspNetCore.Mvc.IActionResult) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            CreateBusinessPartner = "ShopifyWebhooksController/Api/CreateBusinessPartner",
            LogTest = "ShopifyWebhooksController/Api/LogTest",
            UpdateBusinessPartner = "ShopifyWebhooksController/Api/UpdateBusinessPartner",
            CreateSalesOrder = "ShopifyWebhooksController/Api/CreateSalesOrder",
            UpdateSalesOrder = "ShopifyWebhooksController/Api/UpdateSalesOrder",
            CancelSalesOrder = "ShopifyWebhooksController/Api/CancelSalesOrder",
            CreateDeliveryNote = "ShopifyWebhooksController/Api/CreateDeliveryNote",
            CheckOrderPayment = "ShopifyWebhooksController/Api/CheckOrderPayment",
            CreateReturn = "ShopifyWebhooksController/Api/CreateReturn"
        }

        [
            'CreateBusinessPartner', 
            'LogTest', 
            'UpdateBusinessPartner', 
            'CreateSalesOrder', 
            'UpdateSalesOrder', 
            'CancelSalesOrder', 
            'CreateDeliveryNote', 
            'CheckOrderPayment', 
            'CreateReturn'
        ].forEach(x => {
            (<any>ShopifyWebhooksService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
