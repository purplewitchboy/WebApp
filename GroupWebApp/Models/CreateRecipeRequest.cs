using Microsoft.AspNetCore.Http;
namespace GroupWebApp.Models
{
    public class CreateRecipeRequest
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public IFormFile Img { set; get; }
        public string Desc { set; get; }
        public int SubCategoryId { get; set; }

        public int NationalKitchenId { get; set; }
        public int TypeOfPreparationId { get; set; }
        public int IngredientId { get; set; }
    }
}