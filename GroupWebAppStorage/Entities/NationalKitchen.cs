using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupWebApp.Storage.Entities
{
    public class NationalKitchen
    {
        [Key]
        public int Id { get; set; }
        public string KitchenName { get; set; }

    }
}
