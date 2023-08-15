using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Administration.Pages
{

    [PageAuthorize(typeof(LogRow))]
    public class LogController : Controller
    {
        [Route("Administration/Log")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/Log/LogIndex.cshtml");
        }
    }
}