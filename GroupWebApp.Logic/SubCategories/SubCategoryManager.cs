using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Logic.SubCategories
{
    public class SubCategoryManager : ISubCategoryManager
    {
        private readonly RecipeContext _context;
        public SubCategoryManager(RecipeContext context)
        {
            _context = context;
        }

        public async Task<IList<SubCategory>> GetAll(int id) => await _context.SubCategories.Where(x=>x.CategoryId==id).ToListAsync();

        public async Task Create(string name, int id)
        {
            var subcategory = new SubCategory { NameSubCategory = name, CategoryId = id };
            _context.SubCategories.Add(subcategory);
            await _context.SaveChangesAsync();
        }
    }
}
