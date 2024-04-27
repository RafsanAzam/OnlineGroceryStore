using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryStore.Models;
using OnlineGroceryStore.Models.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGroceryStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchTerm)
        {
            IQueryable<Product> query = _context.Products.Include(p => p.Category).Include(p => p.SubCategory);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            }

            var products = await query.ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Search(string searchTerm)
        {
            // If the search term is empty, return all products
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return RedirectToAction(nameof(Index));
            }

            // Filter products based on search term
            var filteredProducts = await _context.Products
                .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .ToListAsync();

            // Pass the filtered products to the view
            return View("Index", filteredProducts);
        }

    }
}
