using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(ChartOfAccountRow))]
    public class ChartOfAccountController : Controller
    {
        [Route("Default/ChartOfAccount")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/ChartOfAccount/ChartOfAccountIndex.cshtml");
        }
    }
}