using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWebApp.Logic.NationalKitchens
{
    public interface INationalKitchenManager
    {
        Task<IList<NationalKitchen>> GetAll();
        Task Create(string name);
    }
}
