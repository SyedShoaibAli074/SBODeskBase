namespace SAPWebPortal.Default {
    export interface BusinessPartnerRow {
        Series?: number;
        CardCode?: string;
        CardName?: string;
        CardForeignName?: string;
        CardType?: string;
        CurrentAccountBalance?: number;
        OpenDeliveryNotesBalance?: number;
        OpenOrdersBalance?: number;
        GroupCode?: string;
        Currency?: string;
        BPAddresses?: BPAddressesRow[];
        BPPaymentMethods?: BPPaymentMethodsRow[];
        Phone1?: string;
        Phone2?: string;
        Cellular?: string;
        SalesPersonCode?: number;
        PriceListNum?: number;
        MailAddress?: string;
        Fax?: string;
        DownPaymentInterimAccount?: string;
        DownPaymentClearAct?: string;
        U_source?: string;
        FederalTaxID?: string;
        Website?: string;
        FatherCard?: string;
        DBName?: string;
        ContactPerson?: string;
        Notes?: string;
        EmailAddress?: string;
        U_TotalSpent?: string;
        U_TotalOrders?: string;
    }

    export namespace BusinessPartnerRow {
        export const idProperty = 'CardCode';
        export const nameProperty = 'CardName';
        export const localTextPrefix = 'Default.BusinessPartner';
        export const lookupKey = 'Default.BusinessPartner';

        export function getLookup(): Q.Lookup<BusinessPartnerRow> {
            return Q.getLookup<BusinessPartnerRow>('Default.BusinessPartner');
        }
        export const deletePermission = 'MasterData:BusinessPartners:Delete';
        export const insertPermission = 'MasterData:BusinessPartners:Insert';
        export const readPermission = 'MasterData:BusinessPartners:View';
        export const updatePermission = 'MasterData:BusinessPartners:Modify';

        export declare const enum Fields {
            Series = "Series",
            CardCode = "CardCode",
            CardName = "CardName",
            CardForeignName = "CardForeignName",
            CardType = "CardType",
            CurrentAccountBalance = "CurrentAccountBalance",
            OpenDeliveryNotesBalance = "OpenDeliveryNotesBalance",
            OpenOrdersBalance = "OpenOrdersBalance",
            GroupCode = "GroupCode",
            Currency = "Currency",
            BPAddresses = "BPAddresses",
            BPPaymentMethods = "BPPaymentMethods",
            Phone1 = "Phone1",
            Phone2 = "Phone2",
            Cellular = "Cellular",
            SalesPersonCode = "SalesPersonCode",
            PriceListNum = "PriceListNum",
            MailAddress = "MailAddress",
            Fax = "Fax",
            DownPaymentInterimAccount = "DownPaymentInterimAccount",
            DownPaymentClearAct = "DownPaymentClearAct",
            U_source = "U_source",
            FederalTaxID = "FederalTaxID",
            Website = "Website",
            FatherCard = "FatherCard",
            DBName = "DBName",
            ContactPerson = "ContactPerson",
            Notes = "Notes",
            EmailAddress = "EmailAddress",
            U_TotalSpent = "U_TotalSpent",
            U_TotalOrders = "U_TotalOrders"
        }
    }
}
