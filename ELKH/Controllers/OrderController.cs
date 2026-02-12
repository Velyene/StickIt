using Microsoft.AspNetCore.Mvc;
using ELKH.Data;
using ELKH.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ELKH.Controllers;

public class OrderController:Controller
{
    private readonly ApplicationDbContext _context;
    private readonly OrderManagementRepo _orderManagementRepo;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
        _orderManagementRepo = new OrderManagementRepo(context);
    }

    public async Task<IActionResult> History()
    {
        
            
        var orders = await _context.Orders
            .OrderByDescending(o => o.CreatedAt)
            .ToListAsync();

        return View(orders);
    }

    public async Task<IActionResult> Details(int id)
    {
        if (id <= 0) return NotFound();

        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.PkOrderId == id);

        if (order == null) return NotFound();

        return View(order);
    }

    // Get order details by user email via repository
    public IActionResult OrderDetails(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) return BadRequest();

        var details = _orderManagementRepo.OrderDetails(email).ToList();
        return View(details);
    }
}
