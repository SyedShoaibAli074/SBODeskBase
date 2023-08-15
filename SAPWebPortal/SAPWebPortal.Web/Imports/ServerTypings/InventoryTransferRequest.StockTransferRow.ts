namespace SAPWebPortal.InventoryTransferRequest {
    export interface StockTransferRow {
        DocEntry?: number;
        Series?: number;
        Printed?: string;
        DocDate?: string;
        DueDate?: string;
        CardCode?: string;
        CardName?: string;
        Address?: string;
        Reference1?: string;
        Reference2?: string;
        Comments?: string;
        JournalMemo?: string;
        PriceList?: number;
        SalesPersonCode?: number;
        FromWarehouse?: string;
        ToWarehouse?: string;
        CreationDate?: string;
        UpdateDate?: string;
        FinancialPeriod?: number;
        TransNum?: number;
        DocNum?: number;
        TaxDate?: string;
        ContactPerson?: number;
        FolioPrefixString?: string;
        FolioNumber?: number;
        DocObjectCode?: string;
        Bplid?: number;
        BplName?: string;
        VatRegNum?: string;
        AuthorizationCode?: string;
        StartDeliveryDate?: string;
        EndDeliveryDate?: string;
        VehiclePlate?: string;
        AtDocumentType?: string;
        EDocExportFormat?: number;
        ElecCommMessage?: string;
        PointOfIssueCode?: string;
        FolioNumberFrom?: number;
        FolioNumberTo?: number;
        AttachmentEntry?: number;
        DocumentStatus?: string;
        ShipToCode?: string;
        SapPassport?: string;
        DBName?: string;
        StockTransferLines?: StockTransferLineRow[];
    }

    export namespace StockTransferRow {
        export const idProperty = 'DocEntry';
        export const nameProperty = 'Printed';
        export const localTextPrefix = 'InventoryTransferRequest.StockTransfer';
        export const deletePermission = 'InventoryTransferRequest';
        export const insertPermission = 'InventoryTransferRequest';
        export const readPermission = 'InventoryTransferRequest';
        export const updatePermission = 'InventoryTransferRequest';

        export declare const enum Fields {
            DocEntry = "DocEntry",
            Series = "Series",
            Printed = "Printed",
            DocDate = "DocDate",
            DueDate = "DueDate",
            CardCode = "CardCode",
            CardName = "CardName",
            Address = "Address",
            Reference1 = "Reference1",
            Reference2 = "Reference2",
            Comments = "Comments",
            JournalMemo = "JournalMemo",
            PriceList = "PriceList",
            SalesPersonCode = "SalesPersonCode",
            FromWarehouse = "FromWarehouse",
            ToWarehouse = "ToWarehouse",
            CreationDate = "CreationDate",
            UpdateDate = "UpdateDate",
            FinancialPeriod = "FinancialPeriod",
            TransNum = "TransNum",
            DocNum = "DocNum",
            TaxDate = "TaxDate",
            ContactPerson = "ContactPerson",
            FolioPrefixString = "FolioPrefixString",
            FolioNumber = "FolioNumber",
            DocObjectCode = "DocObjectCode",
            Bplid = "Bplid",
            BplName = "BplName",
            VatRegNum = "VatRegNum",
            AuthorizationCode = "AuthorizationCode",
            StartDeliveryDate = "StartDeliveryDate",
            EndDeliveryDate = "EndDeliveryDate",
            VehiclePlate = "VehiclePlate",
            AtDocumentType = "AtDocumentType",
            EDocExportFormat = "EDocExportFormat",
            ElecCommMessage = "ElecCommMessage",
            PointOfIssueCode = "PointOfIssueCode",
            FolioNumberFrom = "FolioNumberFrom",
            FolioNumberTo = "FolioNumberTo",
            AttachmentEntry = "AttachmentEntry",
            DocumentStatus = "DocumentStatus",
            ShipToCode = "ShipToCode",
            SapPassport = "SapPassport",
            DBName = "DBName",
            StockTransferLines = "StockTransferLines"
        }
    }
}
