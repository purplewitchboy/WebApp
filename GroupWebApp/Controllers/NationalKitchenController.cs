using Microsoft.AspNetCore.Mvc;
using GroupWebApp.Logic.NationalKitchens;
using GroupWebApp.Storage.Entities;
using GroupWebApp.Models;

namespace GroupWebApp.Controllers
{
    public class NationalKitchenController : Controller
    {
        private readonly INationalKitchenManager _manager;

        public NationalKitchenController(INationalKitchenManager manager)
        {
            _manager = manager;
        }

        public async Task<IActionResult> Main()
        {
            var nk = await _manager.GetAll();

            return View(nk);
        }

        [HttpGet]
        [Route("nationalkitchen")]
        public Task<IList<NationalKitchen>> GetAll() => _manager.GetAll();

        [HttpPut]
        [Route("nationalkitchen")]
        public Task Create([FromBody] CreateNationalKitchenRequest request) => _manager.Create(request.Name);
    }
}
