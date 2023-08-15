using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.ARInvoice.Pages
{

    [PageAuthorize(typeof(DocumentRow))]
    public class DocumentController : Controller
    {
        [Route("ARInvoice/Document")]
        public ActionResult Index()
        {
            return View("~/Modules/ARInvoice/Document/DocumentIndex.cshtml");
        }
    }
}