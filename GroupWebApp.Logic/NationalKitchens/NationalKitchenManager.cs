using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Logic.NationalKitchens
{
    public class NationalKitchenManager : INationalKitchenManager
    {
        private readonly RecipeContext _context;
        public NationalKitchenManager(RecipeContext context)
        {
            _context = context;
        }

        public async Task<IList<NationalKitchen>> GetAll() => await _context.NationalKitchens.ToListAsync();

        public async Task Create(string name)
        {
            var nk = new NationalKitchen { KitchenName = name };
            _context.NationalKitchens.Add(nk);
            await _context.SaveChangesAsync();
        }
    }
}
