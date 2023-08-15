using Serenity.Services;

namespace SAPWebPortal.Administration
{
    public class UserRoleListRequest : ServiceRequest
    {
        public int? UserID { get; set; }
    }
}