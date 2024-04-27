using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryStore.Models;
using OnlineGroceryStore.Models.Data;

namespace OnlineGroceryStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        // GET: Products?categoryId=1
        // GET: Products?categoryId=1&subCategoryId=2
        public async Task<IActionResult> Index(int? categoryId, int? subCategoryId)
        {
            var query = _context.Products.AsQueryable();
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId);
            }
            if (subCategoryId.HasValue)
            {
                query = query.Where(p => p.SubCategoryId == subCategoryId);
            }
            // If no categories are selected, it will default to showing all products
            var products = await query.Include(p => p.Category).Include(p => p.SubCategory).ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);
            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: URL -- eg. Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }

        // POST: URL -- eg. Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind("ProductId, Name, Price")] Product product)
        {
            if(id != product.ProductId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if(!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); //Using nameof(Index) enhances refactoring safety and typo prevention.

            }
            return View(product);
        }
        
    }


}
