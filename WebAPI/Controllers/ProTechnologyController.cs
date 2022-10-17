using Application.Features.ProLangs.Commands.Delete;
using Application.Features.ProTecnologies.Commands.Create;
using Application.Features.ProTecnologies.Commands.Delete;
using Application.Features.ProTecnologies.Commands.Update;
using Application.Features.ProTecnologies.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProTechnologyController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProTechnologyCommand createProTechnologyCommand)
        {
            var result = await Mediator.Send(createProTechnologyCommand);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProTechnologyCommand deleteProTechnologyCommand)
        {
            var result = await Mediator.Send(deleteProTechnologyCommand);
            return Ok(result);
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProTechnologyCommand updateProTechnologyCommand)
        {
            var result = await Mediator.Send(updateProTechnologyCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery ] PageRequest pageRequest)
        {
            var query = new GetListProTechnologyQuery { PageRequest = pageRequest };

            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
