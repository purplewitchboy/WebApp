using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Logic.Ingredients
{
    public class IngredientManager : IIngredientManager
    {
        private readonly RecipeContext _context;
        public IngredientManager(RecipeContext context)
        {
            _context = context;
        }

        public async Task<IList<ByIngredient>> GetAll() => await _context.ByIngredients.ToListAsync();

        public async Task Create(string name)
        {
            var ingredient = new ByIngredient { Ingredient = name };
            _context.ByIngredients.Add(ingredient);
            await _context.SaveChangesAsync();
        }
    }
}
