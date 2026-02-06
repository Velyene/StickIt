using Microsoft.AspNetCore.Mvc;

namespace ELKH.Controllers
{
    public class StaffControler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
