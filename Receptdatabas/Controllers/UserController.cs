using Microsoft.AspNetCore.Mvc;
using Receptdatabas.Repositories.Models.Entities;
using Receptdatabas.Services.Interfaces;

namespace Receptdatabas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var userId = _userService.LoginUser(username, password);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }


        [HttpPost]
        [Route("/api/CreateUser")]
        public IActionResult CreateUser(User user)
        {

            try
            {
                _userService.CreateUser(user);
                return Ok("User created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/api/User/{id}")]
        public IActionResult GetUserById(int id)
        {

            try
            {
                var userDto = _userService.GetUserById(id);
                return Ok(userDto);

            }
            catch (Exception ex)
            {
                return NotFound("No user with that id was found");
            }

        }

        [HttpGet]
        [Route("/api/User/All")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var userDtos = _userService.GetAllUsers();
                return Ok(userDtos);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/api/User/{id}")]
        public IActionResult DeleteUser(int id)
        {

            try
            {
                _userService.DeleteUser(id);
                return Ok("User deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured when deleting the user");
            }
        }

        [HttpPut]
        [Route("/api/User/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                var userDto = _userService.UpdateUser(id, updatedUser);
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
