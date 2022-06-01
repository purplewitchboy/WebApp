using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWebApp.Logic.TypesOfPreparation
{
    public interface ITypeOfPreparationManager
    {
        Task<IList<TypeOfPreparation>> GetAll();
        Task Create(string name);
    }
}
