using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.DraftsLine.Pages
{

    [PageAuthorize(typeof(DocumentLineRow))]
    public class DocumentLineController : Controller
    {
        [Route("DraftsLine/DocumentLine")]
        public ActionResult Index()
        {
            return View("~/Modules/DraftsLine/DocumentLine/DocumentLineIndex.cshtml");
        }
    }
}