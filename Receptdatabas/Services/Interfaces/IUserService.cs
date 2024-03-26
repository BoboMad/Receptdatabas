using Receptdatabas.Repositories.Models.DTOs;

namespace Receptdatabas.Services.Interfaces
{
    public interface IUserService
    {
        UserDto GetUserById(int userId);
        IEnumerable<UserDto> GetAllUsers();
        UserDto CreateUser (UserDto user);
        UserDto UpdateUser (UserDto user);
        UserDto DeleteUser (int userId);
    }
}
