using ELKH.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ELKH.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderManagementRepo _orderManagementRepo;
        public OrderController(OrderManagementRepo orderManagementRepo)
        {
            _orderManagementRepo = orderManagementRepo;
        }
       
        public IActionResult Index()
        {
            return Index();
        }

        public IActionResult Details()
        {
            var orders = _orderManagementRepo.GetAllOrders().ToList();

            return View(orders);
        }

        public IActionResult OrderDetails(string email)
        {
            
        }
    }
}
