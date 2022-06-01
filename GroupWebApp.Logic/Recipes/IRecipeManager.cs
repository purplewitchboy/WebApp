using GroupWebApp.Storage.Entities;

namespace GroupWebApp.Logic.Recipes
{
    public interface IRecipeManager
    {
        Task<IList<Recipe>> GetAll(int id);
        Task<IList<Recipe>> GetInfo(int id);
        Task <IList<Recipe>> SortByNationalKitchen(int id);
        Task<IList<Recipe>> SortByTypeOfPreparation(int id);
        Task<IList<Recipe>> SortByIngredient(int id);
    }
}
