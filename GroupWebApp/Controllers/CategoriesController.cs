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
        public Task<IList<Category>> GetAll() => _manager.GetAll();

        [HttpPut]
        [Route("categories")]
        public Task Create([FromBody] CreateCategoryRequest request) => _manager.Create(request.Name);
    }
}
