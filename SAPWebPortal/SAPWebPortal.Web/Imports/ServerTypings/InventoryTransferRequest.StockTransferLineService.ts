namespace SAPWebPortal.InventoryTransferRequest {
    export namespace StockTransferLineService {
        export const baseUrl = 'InventoryTransferRequest/StockTransferLine';

        export declare function Create(request: Serenity.SaveRequest<StockTransferLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Update(request: Serenity.SaveRequest<StockTransferLineRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<StockTransferLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        export declare function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<StockTransferLineRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;

        export declare const enum Methods {
            Create = "InventoryTransferRequest/StockTransferLine/Create",
            Update = "InventoryTransferRequest/StockTransferLine/Update",
            Delete = "InventoryTransferRequest/StockTransferLine/Delete",
            Retrieve = "InventoryTransferRequest/StockTransferLine/Retrieve",
            List = "InventoryTransferRequest/StockTransferLine/List"
        }

        [
            'Create', 
            'Update', 
            'Delete', 
            'Retrieve', 
            'List'
        ].forEach(x => {
            (<any>StockTransferLineService)[x] = function (r, s, o) {
                return Q.serviceRequest(baseUrl + '/' + x, r, s, o);
            };
        });
    }
}
