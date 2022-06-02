using Microsoft.AspNetCore.Mvc;
using GroupWebApp.Logic.Categories;
using GroupWebApp.Storage.Entities;
using GroupWebApp.Models;

namespace GroupWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryManager _manager;

        public CategoriesController(ICategoryManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
            var categories = await _manager.GetAll();

            return View(categories);
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IList<Category>> GetAll() => await _manager.GetAll();

        [HttpPut]
        [Route("categories")]
        public async Task Create([FromBody] CreateCategoryRequest request) => await _manager.Create(request.Name);
    }
}
