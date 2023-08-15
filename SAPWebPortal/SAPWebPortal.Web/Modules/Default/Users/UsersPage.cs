using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(UsersRow))]
    public class UsersController : Controller
    {
        [Route("Default/Users")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/Users/UsersIndex.cshtml");
        }
    }
}