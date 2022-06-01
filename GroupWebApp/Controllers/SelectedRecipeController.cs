using Microsoft.AspNetCore.Mvc;
using GroupWebApp.Logic.Recipes;
using GroupWebApp.Storage.Entities;
using GroupWebApp.Models;

namespace GroupWebApp.Controllers
{
    public class SelectedRecipeController : Controller
    {
        private readonly IRecipeManager _manager;

        public SelectedRecipeController(IRecipeManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Main(int id)
        {
            var recipes = await _manager.GetInfo(id);
            return View(recipes);
        }
        
        [HttpGet]
        [Route("selectedrecipe")]
        public Task<IList<Recipe>> GetInfo(CreateRecipeRequest request) => _manager.GetInfo(request.Id);
    }
}
