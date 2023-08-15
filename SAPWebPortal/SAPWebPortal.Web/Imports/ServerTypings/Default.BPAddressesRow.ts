namespace SAPWebPortal.Default {
    export interface BPAddressesRow {
        AddressName?: string;
        DetailID?: number;
        Street?: string;
        Block?: string;
        ZipCode?: string;
        City?: string;
        County?: string;
        Country?: string;
        State?: string;
        BuildingFloorRoom?: string;
        AddressType?: string;
        AddressName2?: string;
        AddressName3?: string;
        TypeOfAddress?: string;
        StreetNo?: string;
        BPCode?: string;
        GlobalLocationNumber?: string;
        Nationality?: string;
        TaxOffice?: string;
        GSTIN?: string;
        GstType?: string;
        DBName?: string;
    }

    export namespace BPAddressesRow {
        export const idProperty = 'DetailID';
        export const nameProperty = 'DetailID';
        export const localTextPrefix = 'Default.BPAddresses';
        export const deletePermission = 'BPAddresses';
        export const insertPermission = 'BPAddresses';
        export const readPermission = 'BPAddresses';
        export const updatePermission = 'BPAddresses';

        export declare const enum Fields {
            AddressName = "AddressName",
            DetailID = "DetailID",
            Street = "Street",
            Block = "Block",
            ZipCode = "ZipCode",
            City = "City",
            County = "County",
            Country = "Country",
            State = "State",
            BuildingFloorRoom = "BuildingFloorRoom",
            AddressType = "AddressType",
            AddressName2 = "AddressName2",
            AddressName3 = "AddressName3",
            TypeOfAddress = "TypeOfAddress",
            StreetNo = "StreetNo",
            BPCode = "BPCode",
            GlobalLocationNumber = "GlobalLocationNumber",
            Nationality = "Nationality",
            TaxOffice = "TaxOffice",
            GSTIN = "GSTIN",
            GstType = "GstType",
            DBName = "DBName"
        }
    }
}
