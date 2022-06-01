using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWebApp.Logic.Ingredients
{
    public interface IIngredientManager
    {
        Task<IList<ByIngredient>> GetAll();
        Task Create(string name);
    }
}
