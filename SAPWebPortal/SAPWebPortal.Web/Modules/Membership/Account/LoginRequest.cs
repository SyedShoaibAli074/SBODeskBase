using SAPWebPortal.Default.Endpoints;
using Serenity.ComponentModel;
using Serenity.Services;
using System.ComponentModel;

namespace SAPWebPortal.Membership
{
    [FormScript("Membership.Login")]
    [BasedOnRow(typeof(Administration.Entities.UserRow), CheckNames = true)]
    public class LoginRequest : ServiceRequest
    {
        [Placeholder("User Name")]
        public string Username { get; set; }
        [PasswordEditor, Required(true), Placeholder("Password")]
        public string Password { get; set; }
        [DisplayName("Company DB")]
        [LookupEditor(typeof(SapDatabasesEndpointExt))]

        public string CompanyDatabase { get; set; }
        [Visible(false)]
        public string CompanyDatabaseName { get; set; }
    }
}