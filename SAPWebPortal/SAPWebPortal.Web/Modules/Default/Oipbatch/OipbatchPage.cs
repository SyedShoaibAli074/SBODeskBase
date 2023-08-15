using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(OipbatchRow))]
    public class OipbatchController : Controller
    {
        [Route("Default/Oipbatch")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/Oipbatch/OipbatchIndex.cshtml");
        }
    }
}