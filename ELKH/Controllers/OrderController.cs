using Microsoft.AspNetCore.Mvc;

namespace ELKH.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
