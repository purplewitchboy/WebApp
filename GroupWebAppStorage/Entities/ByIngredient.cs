using System;
using System.Collections.Generic;
namespace GroupWebApp.Storage.Entities
{
    public class ByIngredient
    {
        [Key]
        public int Id { get; set; }
        public string Ingredient { get; set; }

    }
}
