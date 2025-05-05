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
        public async Task<ActionResult<List<ReadingResponseDto>>> GetAll()
        {
            var models = await readingService.GetAll();
            return Ok(models.Select(x => x.ToResponseDto()));      
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ReadingResponseDto>> Get([FromRoute] int id)
        {
            var models = await readingService.GetById(id);
            return Ok(models.ToResponseDto());
        }

        [HttpGet("by-date")]
        public async Task<ActionResult<List<ReadingResponseDto>>> GetByDate([FromQuery] DateTime date)
        {
            var models = await readingService.GetByDate(date);
            return Ok(models.Select(r=>r.ToResponseDto()));
        }
    }
}
