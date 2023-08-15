using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Administration.Pages
{

    [PageAuthorize(typeof(ExceptionsRow))]
    public class ExceptionsController : Controller
    {
        [Route("Administration/Exceptions")]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/Exceptions/ExceptionsIndex.cshtml");
        }
    }
}