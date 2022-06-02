namespace GroupWebApp.Storage.Entities
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public string NameSubCategory { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

    }
}
