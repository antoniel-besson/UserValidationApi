using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UserValidationApi.Interface;
using UserValidationApi.Models;

namespace UserValidationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserRequest user)
        {
            try
            {
                return Ok(await _service.CreateUser(user));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidEnumArgumentException ex)
            {
                return UnprocessableEntity(ex.Message);
            }
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            return Ok(await _service.UpdateUser(user));
        }
    }


}
