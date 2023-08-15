namespace SAPWebPortal.Web.Models.SLModels
{
    public class ApiData
    {
        public string Code { get; set; }
        public string DBName { get; set; }
    }
    public class ServiceLayerLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyDB { get; set; }
    }
}
