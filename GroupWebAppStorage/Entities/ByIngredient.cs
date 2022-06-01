using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWebApp.Storage.Entities
{
    public class ByIngredient
    {
        [Key]
        public int Id { get; set; }
        public string Ingredient { get; set; }

    }
}
