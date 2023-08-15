namespace SAPWebPortal.Web.Helpers
{
    public interface IDataDictionary
    {
        void FillDataDictionary(string username, string password, string companyDB);
        public System.Collections.Generic.List<(string username, string dbname, string modlulename, int totalcount)> GetAllDataDictionary();
         
    }
}
