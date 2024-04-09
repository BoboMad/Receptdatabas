using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Intefaces
{
    public interface IUserRepository
    {
        int LoginUser (string username, string password);
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
