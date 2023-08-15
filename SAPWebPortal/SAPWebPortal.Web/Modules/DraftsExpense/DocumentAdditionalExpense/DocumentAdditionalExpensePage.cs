using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.DraftsExpense.Pages
{

    [PageAuthorize(typeof(DocumentAdditionalExpenseRow))]
    public class DocumentAdditionalExpenseController : Controller
    {
        [Route("DraftsExpense/DocumentAdditionalExpense")]
        public ActionResult Index()
        {
            return View("~/Modules/DraftsExpense/DocumentAdditionalExpense/DocumentAdditionalExpenseIndex.cshtml");
        }
    }
}