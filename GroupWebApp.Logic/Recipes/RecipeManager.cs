using Microsoft.EntityFrameworkCore;


namespace GroupWebApp.Logic.Recipes
{
    public class RecipeManager : IRecipeManager
    {
        private readonly RecipeContext _context;
        public RecipeManager(RecipeContext context)
        {
            _context = context;
        }
        public async Task<IList<Recipe>> GetAll(int id) => await _context.Recipes.Where(x => x.SubCategoryId==id).ToListAsync();

        public async Task<IList<Recipe>> GetInfo(int id) => await _context.Recipes.Where(x => x.Id==id).ToListAsync();

        public async Task<IList<Recipe>> SortByNationalKitchen(int id) => await _context.Recipes.Where(x => x.NationalKitchenId==id).ToListAsync();

        public async Task<IList<Recipe>> SortByTypeOfPreparation(int id) => await _context.Recipes.Where(x => x.TypeOfPreparationId==id).ToListAsync();

        public async Task<IList<Recipe>> SortByIngredient(int id) => await _context.Recipes.Where(x => x.ByIngredientId==id).ToListAsync();
    }
}
