using Microsoft.AspNetCore.Mvc;
using Web.Application.Abstractions.Services;
using Web.Application.DataTransfer.Response;
using Web.Application.Models;
using Web.Application.Services;

namespace Web.Api.Controllers
{
    [Route("readings")]
    [ApiController]
    public class ReadingsController(IReadingService readingService): ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var models = await readingService.GetAll();
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var models = await readingService.GetById(id);
            return Ok(models);
        }

        [HttpGet("by-date")]
        public async Task<ActionResult> GetByDate([FromQuery] DateTime date)
        {
            var models = await readingService.GetByDate(date);
            return Ok(models);
        }
    }
}
