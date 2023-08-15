namespace SAPWebPortal.Web.Modules.Default.Log
{
    public class LogEnums
    {
        public enum UDirection
        {
            SAPToShopify = 1,
            ShopifyToSAP = 2,
            Internal = 3,
            External = 4
        }
        public enum UError
        {
            True = 0,
            False = 1
        }
    }
}
