using Microsoft.EntityFrameworkCore;
using Receptdatabas.Repositories.Contexts;
using Receptdatabas.Repositories.Intefaces;
using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _context.Users.Find(userId);
            if(userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public int LoginUser(string username, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
            if(user != null)
            {
                return user.Id;
            }
            else
            {
                return 0;
            }
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
