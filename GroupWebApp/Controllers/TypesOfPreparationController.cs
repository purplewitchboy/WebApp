using Microsoft.AspNetCore.Mvc;
using GroupWebApp.Logic.TypesOfPreparation;
using GroupWebApp.Storage.Entities;
using GroupWebApp.Models;

namespace GroupWebApp.Controllers
{
    public class TypesOfPreparationController : Controller
    {
        private readonly ITypeOfPreparationManager _manager;

        public TypesOfPreparationController(ITypeOfPreparationManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
            var top = await _manager.GetAll();

            return View(top);
        }

        [HttpGet]
        [Route("typesofpreparation")]
        public Task<IList<TypeOfPreparation>> GetAll() => _manager.GetAll();

        [HttpPut]
        [Route("typesofpreparation")]
        public Task Create([FromBody] CreateTypeOfPreparationRequest request) => _manager.Create(request.Name);
    }
}
