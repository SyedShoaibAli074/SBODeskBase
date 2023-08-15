using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(SapDatabasesRow))]
    public class SapDatabasesController : Controller
    {
        [Route("Default/SapDatabases")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/SapDatabases/SapDatabasesIndex.cshtml");
        }
    }
}