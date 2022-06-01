using GroupWebApp.Storage.Entities;

namespace GroupWebApp.Logic.SubCategories
{
    public interface ISubCategoryManager
    {
        Task<IList<SubCategory>> GetAll(int id);
        Task Create(string name,int id);
    }
}
