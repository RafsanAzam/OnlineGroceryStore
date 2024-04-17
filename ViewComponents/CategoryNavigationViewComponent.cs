using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineGroceryStore.Models.Data;

namespace OnlineGroceryStore.ViewComponents
{
    public class CategoryNavigationViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public CategoryNavigationViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories.Include(c => c.SubCategories).ToListAsync();
            return View(categories);
        }
    }
}
