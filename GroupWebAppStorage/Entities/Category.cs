using System.Collections.Generic;

namespace GroupWebApp.Storage.Entities
{
    public class Category
    {
        [Key]
        public int Id { set; get; }
        public string categoryName { set; get; }
    }

}
