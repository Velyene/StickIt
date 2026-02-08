using Microsoft.AspNetCore.Mvc;
using E_Commerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace ELKH.Controllers;

public class CartController
{
    public class CartController : Controller
    {
        
        private static List<Product> _cartItems = new List<Product>();

        
        public IActionResult Index()
        {
            return View(_cartItems);
        }

        
        [HttpPost]
        public IActionResult AddToCart(int itemId, int quantity)
        {
            
            if (quantity <= 0) return BadRequest("Quantity must be positive.");

            
            _cartItems.Add(new Product { Id = itemId, Name = $"Product {itemId}", Price = 10.00m });
            
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        public IActionResult RemoveFromCart(int itemId)
        {
            var item = _cartItems.FirstOrDefault(p => p.Id == itemId);
            if (item != null)
            {
                _cartItems.Remove(item);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}