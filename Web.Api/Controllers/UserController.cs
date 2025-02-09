using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.Application.Abstractions.Services;
using Web.Application.DataTransfer.Response;
using Web.Application.Models;

namespace Web.Api.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController(IUserService userService) : Controller
    {

        [HttpGet]
        [Route("getUsers")]
        public async Task<ActionResult<List<UserResponseDto>>> GetAll() 
        { 
            List<UserModel> models = await userService.GetAll();
            return Ok(models.Select(x=>x.ToDto()));
        }
    }
}
