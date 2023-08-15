using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.APInvoiceLine.Pages
{

    [PageAuthorize(typeof(DocumentLineRow))]
    public class DocumentLineController : Controller
    {
        [Route("OrdersLine/DocumentLine")]
        public ActionResult Index()
        {
            return View("~/Modules/OrdersLine/DocumentLine/DocumentLineIndex.cshtml");
        }
    }
}