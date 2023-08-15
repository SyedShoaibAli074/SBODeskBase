namespace SAPWebPortal.Web.Models.SLModels {
    export interface StockTransfer {
        DBName?: string;
        DocEntry?: number;
        StockTransferLines?: StockTransferLines[];
    }
}
