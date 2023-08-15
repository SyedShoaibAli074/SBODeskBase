using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(UserDetail2Row))]
    public class UserDetail2Controller : Controller
    {
        [Route("Default/UserDetail2")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/UserDetail2/UserDetail2Index.cshtml");
        }
    }
}