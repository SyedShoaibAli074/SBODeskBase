using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ReportsRow))]
    public class ReportsController : Controller
    {
        [Route("Default/Reports")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/Reports/ReportsIndex.cshtml");
        }
    }
}