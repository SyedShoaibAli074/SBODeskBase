using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(UsersDetailsRow))]
    public class UsersDetailsController : Controller
    {
        [Route("Default/UsersDetails")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/UsersDetails/UsersDetailsIndex.cshtml");
        }
    }
}