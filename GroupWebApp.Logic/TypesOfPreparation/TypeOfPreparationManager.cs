using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Logic.TypesOfPreparation
{
    public class TypeOfPreparationManager : ITypeOfPreparationManager
    {
        private readonly RecipeContext _context;
        public TypeOfPreparationManager(RecipeContext context)
        {
            _context = context;
        }

        public async Task<IList<TypeOfPreparation>> GetAll() => await _context.TypeOfPreparations.ToListAsync();

        public async Task Create(string name)
        {
            var top = new TypeOfPreparation { NameOfType = name };
            _context.TypeOfPreparations.Add(top);
            await _context.SaveChangesAsync();
        }
    }
}
