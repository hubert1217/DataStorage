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

    }
}
