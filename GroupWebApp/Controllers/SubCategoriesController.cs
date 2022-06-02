using Microsoft.AspNetCore.Mvc;
using GroupWebApp.Logic.SubCategories;
using GroupWebApp.Storage.Entities;
using GroupWebApp.Models;

namespace GroupWebApp.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoryManager _manager;

        public SubCategoriesController(ISubCategoryManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main(int id)
        {
            var subcategories = await _manager.GetAll(id);

            return View(subcategories);
        }

        [HttpGet]
        [Route("subcategories")]
        public Task<IList<SubCategory>> GetAll(CreateSubCategoryRequest request) => _manager.GetAll(request.categoryId);

        [HttpPut]
        [Route("subcategories")]
        public async Task Create([FromBody] CreateSubCategoryRequest request) => await _manager.Create(request.Name, request.categoryId);
    }
}
