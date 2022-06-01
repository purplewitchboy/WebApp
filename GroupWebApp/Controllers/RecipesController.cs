using Microsoft.AspNetCore.Mvc;
using GroupWebApp.Logic.Recipes;
using GroupWebApp.Storage.Entities;
using GroupWebApp.Models;



namespace GroupWebApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeManager _manager;
        RecipeContext _context;
        IWebHostEnvironment _appEnvironment;

        public RecipesController(IRecipeManager manager, RecipeContext context, IWebHostEnvironment appEnvironment)
        {
            _manager = manager;
            _context = context;

        }

        public async Task<IActionResult> Main(int id)
        {
            var recipes = await _manager.GetAll(id);

            return View(recipes);
        }

        public async Task<IActionResult> SortNK(int id)
        {
            var recipes = await _manager.SortByNationalKitchen(id);

            return View(recipes);
        }

        public async Task<IActionResult> SortTOP(int id)
        {
            var recipes = await _manager.SortByTypeOfPreparation(id);

            return View(recipes);
        }

        public async Task<IActionResult> SortByIngredient(int id)
        {
            var recipes = await _manager.SortByIngredient(id);

            return View(recipes);
        }



        [HttpGet]
        [Route("recipes")]
        public Task<IList<Recipe>> GetAll(CreateRecipeRequest request) => _manager.GetAll(request.SubCategoryId);

        [HttpGet]
        public Task<IList<Recipe>> SortByNationalKitchen(CreateRecipeRequest request) => _manager.SortByNationalKitchen(request.NationalKitchenId);

        [HttpGet]
        public Task<IList<Recipe>> SortByTypeOfPreparation(CreateRecipeRequest request) => _manager.SortByTypeOfPreparation(request.TypeOfPreparationId);

        [HttpGet]
        public Task<IList<Recipe>> SortByIngredient(CreateRecipeRequest request) => _manager.SortByIngredient(request.IngredientId);


        [HttpPost]
        [Route("recipes")]
        public IActionResult OnPost([FromForm] CreateRecipeRequest pvm)
        {
            Recipe recipe = new Recipe { Name = pvm.Name, SubCategoryId = pvm.SubCategoryId, desc = pvm.Desc };
            if (pvm.Img != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.Img.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Img.Length);
                }
                // установка массива байтов
                recipe.Pic = imageData;
            }
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return RedirectToAction("Main");
        }
    }
}
