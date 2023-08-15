using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.Quotations.Pages
{

    [PageAuthorize(typeof(DocumentRow))]
    public class DocumentController : Controller
    {
        [Route("Quotations/Document")]
        public ActionResult Index()
        {
            return View("~/Modules/Quotations/Document/DocumentIndex.cshtml");
        }
    }
}