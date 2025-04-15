using Microsoft.AspNetCore.Mvc;
using Web.Application.Abstractions.Services;
using Web.Application.DataTransfer.Response;
using Web.Application.Models;
using Web.Application.Services;

namespace Web.Api.Controllers
{
    [Route("meters")]
    [ApiController]
    public class MetersController(IMeterService meterService) : ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var models = await meterService.GetAll();
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var models = await meterService.GetById(id);
            return Ok(models);
        }

        [HttpGet("by-serial")]
        public async Task<ActionResult> GetBySerialNumber([FromQuery] string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
                return BadRequest("Serial number is required.");

            var models = await meterService.GetBySerialNumber(serialNumber);

            if (models == null || !models.Any())
                return NotFound($"No meters found with serial number: {serialNumber}");

            return Ok(models);
        }
    }
}
