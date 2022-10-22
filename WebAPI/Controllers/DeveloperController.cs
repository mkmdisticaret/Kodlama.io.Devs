using Application.Features.Developers.Commands.Create;
using Application.Features.Developers.Commands.Delete;
using Application.Features.Developers.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Register([FromBody] CreateDeveloperCommand createDeveloperCommand)
        {
            var result = await Mediator.Send(createDeveloperCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteDeveloperCommand deleteDeveloperCommand)
        {
            var result = await Mediator.Send(deleteDeveloperCommand);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateDeveloperCommand updateDeveloperCommand)
        {
            var result = await Mediator.Send(updateDeveloperCommand);
            return Ok(result);
        }
    }
}
