using Microsoft.AspNetCore.Mvc;
using GroupWebApp.Logic.Ingredients;
using GroupWebApp.Storage.Entities;
using GroupWebApp.Models;


namespace GroupWebApp.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientManager _manager;

        public IngredientsController(IIngredientManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
            var ingredient = await _manager.GetAll();

            return View(ingredient);
        }

        [HttpGet]
        [Route("ingredients")]
        public Task<IList<ByIngredient>> GetAll() => _manager.GetAll();

        [HttpPut]
        [Route("ingredients")]
        public Task Create([FromBody] CreateIngredientRequest request) => _manager.Create(request.Name);
    }
}
