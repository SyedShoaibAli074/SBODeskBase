using Serenity.Services;

namespace SAPWebPortal.Default
{
    public class UsersListRequest : ListRequest
    {
        public int? Rodcid { get; set; }
    }
}