using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using Web.Application.Abstractions.Services;
using Web.Application.DataTransfer.Request;
using Web.Application.DataTransfer.Response;
using Web.Application.Models;

namespace Web.Api.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController(IUserService userService) : Controller
    {

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<UserResponseDto>>> Get() 
        {
            List<UserModel> models = await userService.GetAll();
            return Ok(models.Select(x=>x.ToDto()));
        }

        [HttpPost]
        public async Task<ActionResult<UserResponseDto>> Create([FromBody] UserRequestDto request) 
        { 
            UserModel model = await userService.Create(request.Name, request.Surname, request.Description);
            return Ok(model.ToDto());
        }
    }
}
