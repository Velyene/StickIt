using Microsoft.AspNetCore.Mvc;
using E_Commerce.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ELKH.Controllers;

public class OrderController
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> History()
    {
            
        var orders = await _context.Orders
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        return View(orders);
    }

    public async Task<IActionResult> Details(int id)
    {
        if (id <= 0) return NotFound();

        var order = await _context.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null) return NotFound();

        return View(order);
    }
}