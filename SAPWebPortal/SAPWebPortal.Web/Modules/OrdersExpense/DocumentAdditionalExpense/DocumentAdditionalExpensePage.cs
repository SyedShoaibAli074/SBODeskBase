using Serenity;
using Serenity.Web;
using Microsoft.AspNetCore.Mvc;

namespace SAPWebPortal.OrdersExpense.Pages
{

    [PageAuthorize(typeof(DocumentAdditionalExpenseRow))]
    public class DocumentAdditionalExpenseController : Controller
    {
        [Route("OrdersExpense/DocumentAdditionalExpense")]
        public ActionResult Index()
        {
            return View("~/Modules/OrdersExpense/DocumentAdditionalExpense/DocumentAdditionalExpenseIndex.cshtml");
        }
    }
}