using GroupWebApp.Storage.Entities;

namespace GroupWebApp.Logic.Categories
{
    public interface ICategoryManager
    {
        Task<IList<Category>> GetAll();
        Task Create(string name);
        
    }
}
