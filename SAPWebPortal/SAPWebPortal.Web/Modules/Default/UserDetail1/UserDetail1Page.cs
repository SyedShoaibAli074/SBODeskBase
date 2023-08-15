using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(UserDetail1Row))]
    public class UserDetail1Controller : Controller
    {
        [Route("Default/UserDetail1")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/UserDetail1/UserDetail1Index.cshtml");
        }
    }
}