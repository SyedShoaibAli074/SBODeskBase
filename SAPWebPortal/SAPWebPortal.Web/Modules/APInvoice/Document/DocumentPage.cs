using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.APInvoice.Pages
{

    [PageAuthorize(typeof(DocumentRow))]
    public class DocumentController : Controller
    {
        [Route("APInvoice/Document")]
        public ActionResult Index()
        {
            return View("~/Modules/APInvoice/Document/DocumentIndex.cshtml");
        }
    }
}