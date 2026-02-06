using Microsoft.AspNetCore.Mvc;

namespace ELKH.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
