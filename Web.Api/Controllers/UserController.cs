using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
    public class UserController(IUserService userService) : ControllerBase
    {

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<List<UserResponseDto>>> Get() 
        {
            try
            {
                List<UserModel> models = await userService.GetAll();
                return Ok(models.Select(x => x.ToDto()));
            }
            catch (Exception ex) 
            { 
                return Ok(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult<UserResponseDto>> Update(int id, [FromBody] UserUpdateRequestDto request) 
        { 
            UserModel model = await userService.Update(id, request.FirstName, request.LastName, request.Description, request.Email);
            return Ok(model.ToDto());
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserResponseDto>> Create([FromBody] UserCreateRequestDto request)
        {
            UserModel model = await userService.Create(request.FirstName, request.LastName, request.Description, request.Email);
            return Ok(model.ToDto());

        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await userService.Delete(id);
            return NoContent();
        }


    }
}
