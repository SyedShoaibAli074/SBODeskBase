using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(Report_UsersRow))]
    public class Report_UsersController : Controller
    {
        [Route("Default/Report_Users")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/Report_Users/Report_UsersIndex.cshtml");
        }
    }
}