using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warzywniak.Data;
using Warzywniak.Models;

namespace Warzywniak.Controllers;

[Authorize]
public class CartController : Controller
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(long productId)
    {
        var userIdText = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!long.TryParse(userIdText, out var userId))
        {
            return Challenge();
        }

        var productExists = await _context.Products.AnyAsync(product =>
            product.Id == productId &&
            product.IsVisible &&
            product.DeletedAt == null);

        if (!productExists)
        {
            return NotFound();
        }

        var cart = await _context.Carts
            .Include(currentCart => currentCart.CartItems)
            .FirstOrDefaultAsync(currentCart => currentCart.UserId == userId);

        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId,
                CreatedAt = DateTime.SpecifyKind(
                    DateTime.UtcNow,
                    DateTimeKind.Unspecified)
            };

            _context.Carts.Add(cart);
        }

        var item = cart.CartItems.FirstOrDefault(
            cartItem => cartItem.ProductId == productId);

        if (item == null)
        {
            cart.CartItems.Add(new CartItem
            {
                ProductId = productId,
                Quantity = 1
            });
        }
        else
        {
            item.Quantity++;
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(ShowCart));
    }

    [HttpGet]
    public async Task<IActionResult> ShowCart()
    {
        var userIdText = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!long.TryParse(userIdText, out var userId))
        {
            return Challenge();
        }

        var items = await _context.CartItems
            .Include(cartItem => cartItem.Product)
            .Where(cartItem => cartItem.Cart.UserId == userId)
            .ToListAsync();

        return View(items);
    }
}
