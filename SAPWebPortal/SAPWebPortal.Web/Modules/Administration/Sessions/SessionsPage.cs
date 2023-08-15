using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Administration.Pages
{

    [PageAuthorize(typeof(SessionsRow))]
    public class SessionsController : Controller
    {
        [Route("Administration/Sessions")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/Sessions/SessionsIndex.cshtml");
        }
    }
}