namespace SAPWebPortal.Orders {
    export interface AddressExtensionRow {
        DetailID?: number;
        DocEntry?: string;
        ShipToStreet?: string;
        ShipToStreetNo?: string;
        ShipToBlock?: string;
        ShipToBuilding?: string;
        ShipToCity?: string;
        ShipToZipCode?: string;
        ShipToCounty?: string;
        ShipToState?: string;
        ShipToCountry?: string;
        ShipToAddressType?: string;
        BillToStreet?: string;
        BillToStreetNo?: string;
        BillToBlock?: string;
        BillToBuilding?: string;
        BillToCity?: string;
        BillToZipCode?: string;
        BillToCounty?: string;
        BillToState?: string;
        BillToCountry?: string;
        BillToAddressType?: string;
        ShipToGlobalLocationNumber?: string;
        BillToGlobalLocationNumber?: string;
        ShipToAddress2?: string;
        ShipToAddress3?: string;
        BillToAddress2?: string;
        BillToAddress3?: string;
    }

    export namespace AddressExtensionRow {
        export const idProperty = 'DetailID';
        export const nameProperty = 'DetailID';
        export const localTextPrefix = 'Default.AddressExtension';
        export const deletePermission = 'AddressExtension';
        export const insertPermission = 'AddressExtension';
        export const readPermission = 'AddressExtension';
        export const updatePermission = 'AddressExtension';

        export declare const enum Fields {
            DetailID = "DetailID",
            DocEntry = "DocEntry",
            ShipToStreet = "ShipToStreet",
            ShipToStreetNo = "ShipToStreetNo",
            ShipToBlock = "ShipToBlock",
            ShipToBuilding = "ShipToBuilding",
            ShipToCity = "ShipToCity",
            ShipToZipCode = "ShipToZipCode",
            ShipToCounty = "ShipToCounty",
            ShipToState = "ShipToState",
            ShipToCountry = "ShipToCountry",
            ShipToAddressType = "ShipToAddressType",
            BillToStreet = "BillToStreet",
            BillToStreetNo = "BillToStreetNo",
            BillToBlock = "BillToBlock",
            BillToBuilding = "BillToBuilding",
            BillToCity = "BillToCity",
            BillToZipCode = "BillToZipCode",
            BillToCounty = "BillToCounty",
            BillToState = "BillToState",
            BillToCountry = "BillToCountry",
            BillToAddressType = "BillToAddressType",
            ShipToGlobalLocationNumber = "ShipToGlobalLocationNumber",
            BillToGlobalLocationNumber = "BillToGlobalLocationNumber",
            ShipToAddress2 = "ShipToAddress2",
            ShipToAddress3 = "ShipToAddress3",
            BillToAddress2 = "BillToAddress2",
            BillToAddress3 = "BillToAddress3"
        }
    }
}
