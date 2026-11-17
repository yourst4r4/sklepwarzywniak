using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warzywniak.Data;

namespace Warzywniak.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> List()
    {
        var products = await _context.Products
            .Where(product => product.IsVisible && product.DeletedAt == null)
            .OrderBy(product => product.Name)
            .ToListAsync();

        return View(products);
    }
}
