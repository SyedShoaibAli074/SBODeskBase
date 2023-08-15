using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(Ipbatch1Row))]
    public class Ipbatch1Controller : Controller
    {
        [Route("Default/Ipbatch1")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/Ipbatch1/Ipbatch1Index.cshtml");
        }
    }
}