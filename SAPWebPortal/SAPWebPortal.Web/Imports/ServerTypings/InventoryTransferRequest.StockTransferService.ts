namespace SAPWebPortal.InventoryTransferRequest {
    export namespace StockTransferService {
        export const baseUrl = 'InventoryTransferRequest/StockTransfer';

        export declare function Create(request: Serenity.SaveRequest<StockTransferRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<StockTransferRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function UpdateRecievedQty(request: Serenity.SaveRequest<Web.Models.SLModels.StockTransfer>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<StockTransferRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<StockTransferRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function ListAndRetrieve(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<StockTransferRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "InventoryTransferRequest/StockTransfer/Create",
            Update = "InventoryTransferRequest/StockTransfer/Update",
            UpdateRecievedQty = "InventoryTransferRequest/StockTransfer/UpdateRecievedQty",
            Delete = "InventoryTransferRequest/StockTransfer/Delete",
            Retrieve = "InventoryTransferRequest/StockTransfer/Retrieve",
            List = "InventoryTransferRequest/StockTransfer/List",
            ListAndRetrieve = "InventoryTransferRequest/StockTransfer/ListAndRetrieve"
        }

        [
            'Create', 
            'Update', 
            'UpdateRecievedQty', 
            'Delete', 
            'Retrieve', 
            'List', 
            'ListAndRetrieve'
        ].forEach(x => {
            (<any>StockTransferService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
