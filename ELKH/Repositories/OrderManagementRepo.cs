using ELKH.Data;
using ELKH.ViewModels;
using SQLitePCL;

namespace ELKH.Repositories
{
    public class OrderManagementRepo
    {
        private ApplicationDbContext _context;
        public OrderManagementRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<OrderDetailsViewModel> GetAllOrders()
        {
            IEnumerable<OrderDetailsViewModel> orders = _context.Orders.Select(o => new OrderDetailsViewModel
            {
                OrderId = o.PkOrderId,
                UserEmail = o.RegisteredUser.Email,
                DeliveryStatus = o.DeliveryStatus
            });
            return orders;
        }

        public IEnumerable<OrderDetailsViewModel> OrderDetails(string email )
        {
            var orderDetails = _context.RegisteredUsers.Where(ru => ru.Email == email)
                                                       .Select(ru => new OrderDetailsViewModel
                                                       {

                                                       }).ToList();
            return orderDetails;
        }
    }
}
