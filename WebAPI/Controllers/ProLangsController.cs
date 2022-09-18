using Application.Features.ProLangs.Commands.Create;
using Application.Features.ProLangs.Commands.Delete;
using Application.Features.ProLangs.Commands.Update;
using Application.Features.ProLangs.Dtos;
using Application.Features.ProLangs.Queries.GetById;
using Application.Features.ProLangs.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProLangsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProLangCommand createProLangCommand)
        {
            CreatedProLangDto result = await Mediator.Send(createProLangCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProLangCommand deleteProLangCommand)
        {
            DeletedProLangDto result = await Mediator.Send(deleteProLangCommand);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProLangCommand updateProLangCommand)
        {
            var result = await Mediator.Send(updateProLangCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProLangQuery getByIdProLangQuery)
        {
            var result = await Mediator.Send(getByIdProLangQuery);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var query = new GetListProLangQuery { PageRequest = pageRequest };

            var result = await Mediator.Send(query);
            return Ok(result);

        }
    }
}
