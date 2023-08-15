using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Administration.Pages
{

    [PageAuthorize(typeof(UserFormAuthorizationsRow))]
    public class UserFormAuthorizationsController : Controller
    {
        [Route("Administration/UserFormAuthorizations")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/UserFormAuthorizations/UserFormAuthorizationsIndex.cshtml");
        }
    }
}