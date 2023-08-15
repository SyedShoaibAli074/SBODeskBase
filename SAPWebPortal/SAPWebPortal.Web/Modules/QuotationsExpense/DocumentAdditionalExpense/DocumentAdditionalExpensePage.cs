using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.QuotationsExpense.Pages
{

    [PageAuthorize(typeof(DocumentAdditionalExpenseRow))]
    public class DocumentAdditionalExpenseController : Controller
    {
        [Route("QuotationsExpense/DocumentAdditionalExpense")]
        public ActionResult Index()
        {
            return View("~/Modules/QuotationsExpense/DocumentAdditionalExpense/DocumentAdditionalExpenseIndex.cshtml");
        }
    }
}