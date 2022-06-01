using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Logic.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly RecipeContext _context;
        public CategoryManager(RecipeContext context)
        {
            _context = context;
        }

        public async Task<IList<Category>> GetAll() => await _context.Categories.ToListAsync();
        
        public async Task Create(string name)
        {
            var category = new Category { categoryName = name };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
    }
}
