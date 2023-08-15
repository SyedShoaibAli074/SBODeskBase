using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Administration.Pages
{

    [PageAuthorize(typeof(SettingsRow))]
    public class SettingsController : Controller
    {
        [Route("Administration/Settings")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/Settings/SettingsIndex.cshtml");
        }
    }
}