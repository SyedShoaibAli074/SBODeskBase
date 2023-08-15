using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(FileRoutingRow))]
    public class FileRoutingController : Controller
    {
        [Route("Default/FileRouting")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/FileRouting/FileRoutingIndex.cshtml");
        }
    }
}