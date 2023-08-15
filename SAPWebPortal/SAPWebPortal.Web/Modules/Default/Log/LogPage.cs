using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(LogRow))]
    public class LogController : Controller
    {
        [Route("Default/Log")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/Log/LogIndex.cshtml");
        }
    }
}