using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Services.Interfaces
{
    public interface IUserService
    {
        UserDto GetUserById(int userId);
        IEnumerable<UserDto> GetAllUsers();
        UserDto CreateUser (User user);
        UserDto UpdateUser (int id,User user);
        void DeleteUser (int userId);
    }
}
