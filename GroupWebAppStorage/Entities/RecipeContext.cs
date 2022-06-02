using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Storage.Entities
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {

        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<NationalKitchen> NationalKitchens { get; set; }
        public DbSet<TypeOfPreparation> TypeOfPreparations { get; set; }
        public DbSet<ByIngredient> ByIngredients { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
