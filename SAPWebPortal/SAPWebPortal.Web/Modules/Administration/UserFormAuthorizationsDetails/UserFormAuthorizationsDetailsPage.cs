using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Administration.Pages
{

    [PageAuthorize(typeof(UserFormAuthorizationsDetailsRow))]
    public class UserFormAuthorizationsDetailsController : Controller
    {
        [Route("Administration/UserFormAuthorizationsDetails")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/UserFormAuthorizationsDetails/UserFormAuthorizationsDetailsIndex.cshtml");
        }
    }
}