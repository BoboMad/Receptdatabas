using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Receptdatabas.Repositories.Contexts;
using Receptdatabas.Repositories.Intefaces;
using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;
using Receptdatabas.Services.Interfaces;

namespace Receptdatabas.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public int LoginUser(string username, string password)
        {
            var userId = _userRepository.LoginUser(username, password);
            if(userId == 0)
            {
                throw new Exception("Invalid credentials");
            }
            else
            {
                return userId;
            }
        }

        public UserDto CreateUser(User user)
        {

            if (user == null)
            {
                throw new ArgumentNullException("Invalid user data, null user");
            }
            else
            {
                _userRepository.CreateUser(user);
                return _mapper.Map<UserDto>(user);
            }
        }

        public void DeleteUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            if (users == null || !users.Any())
            {
                throw new ArgumentException("No users found");
            }
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                throw new ArgumentException("No user with that id found");
            }
            else
            {
                return _mapper.Map<UserDto>(user);
            }
        }

        public UserDto UpdateUser(int id, User user)
        {
            if (user != null)
            {
                user.Id = id;
                _userRepository.UpdateUser(user);
                return _mapper.Map<UserDto>(user);
            }
            else
            {
                throw new ArgumentNullException("User was null");
            }
        }
    }
}
