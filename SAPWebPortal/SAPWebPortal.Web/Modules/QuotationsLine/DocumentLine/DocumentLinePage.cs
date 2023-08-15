using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.QuotationsLine.Pages
{

    [PageAuthorize(typeof(DocumentLineRow))]
    public class DocumentLineController : Controller
    {
        [Route("QuotationsLine/DocumentLine")]
        public ActionResult Index()
        {
            return View("~/Modules/QuotationsLine/DocumentLine/DocumentLineIndex.cshtml");
        }
    }
}