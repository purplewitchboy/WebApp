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
        public async Task<IList<NationalKitchen>> GetAll() => await _manager.GetAll();

        [HttpPut]
        [Route("nationalkitchen")]
        public async Task Create([FromBody] CreateNationalKitchenRequest request) => await _manager.Create(request.Name);
    }
}
