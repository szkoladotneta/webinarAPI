using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;
using WebinarAPI.Application.Interfaces;
using WebinarAPI.Application.ViewModels.Presents;
using WebinarAPI.Model;

namespace WebinarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PresentController : ControllerBase
    {
        private readonly IPresentService _presentService;
        public PresentController(IPresentService presentService)
        {
            _presentService = presentService;
        }
        [HttpGet]
        [Description("Get a list")]
        public async Task<ActionResult<PresentsVm>> Get()
        {
            var presents = await _presentService.GetAllPresents();
            return Ok(presents);
        }

        [HttpGet("{id}")]
        [Description("Get specific item")]
        public async Task<ActionResult<PresentDto>> Get(int id)
        {
            var present = await _presentService.GetPresentById(id);
            return Ok(present);
        }

        [HttpGet("Search/{query}")]
        [Description("Return list for searched query")]
        public async Task<ActionResult<PresentsVm>> Get(string query)
        {
            var presents = await _presentService.GetPresentsByQuery(query);
            return Ok(presents);
        }

        [HttpPut]
        [Description("Updates specific item")]
        public async Task<IActionResult> Update(UpdatePresentDto updatePresent)
        {
            await _presentService.UpdatePresnet(updatePresent);
            return NoContent();
        }

        [HttpPost]
        [Description("Inserts new item")]
        public async Task<IActionResult> Create(CreatePresentDto newPresent)
        {
            await _presentService.AddNewPresent(newPresent);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Description("Deletes specific item")]
        public async Task<IActionResult> Delete(int id)
        {
            await _presentService.DeletePresent(id);
            return NoContent();
        }
    }
}
