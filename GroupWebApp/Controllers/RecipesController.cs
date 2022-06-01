﻿using Microsoft.AspNetCore.Mvc;
using GroupWebApp.Logic.Recipes;
using GroupWebApp.Storage.Entities;
using GroupWebApp.Models;

namespace GroupWebApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeManager _manager;
        RecipeContext _context;
        
        public RecipesController(IRecipeManager manager, RecipeContext context)
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
        public IActionResult OnPost([FromForm] CreateRecipeRequest request)
        {
            Recipe recipe = new Recipe { Name = request.Name, SubCategoryId = request.SubCategoryId, desc = request.Desc };
            if (request.Img != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(request.Img.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)request.Img.Length);
                }
                recipe.Pic = imageData;
            }
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return RedirectToAction("Main");
        }
    }
}
