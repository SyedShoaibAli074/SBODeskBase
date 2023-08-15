using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Default.Pages
{

    [PageAuthorize(typeof(RecordCountsRow))]
    public class RecordCountsController : Controller
    {
        [Route("Default/RecordCounts")]
        public ActionResult Index()
        {
            return View("~/Modules/Default/RecordCounts/RecordCountsIndex.cshtml");
        }
    }
}