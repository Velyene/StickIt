using Microsoft.AspNetCore.Mvc;

namespace ELKH.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
