using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Receptdatabas.Repositories.Intefaces;
using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {


            return Ok();
        }


        [HttpPost]
        [Route("/api/CreateUser")]
        public IActionResult CreateUser(User user)
        {

            if (!ModelState.IsValid)
            {
                // Inspect ModelState errors
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                 .Select(e => e.ErrorMessage);
                return BadRequest("hej" + errors);
            }

            if (user == null)
            {
                return BadRequest("Invalid user data");
            }
            else
            {
                _userRepository.CreateUser(user);
                return Ok();
            }

        }

        [HttpGet]
        [Route("/api/User/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        [HttpGet]
        [Route("/api/User/All")]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            if (users == null || !users.Any())
            {
                return NotFound("No users found");
            }
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }

        [HttpDelete]
        [Route("/api/User/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
            return Ok("User deleted");
        }
    }
}
