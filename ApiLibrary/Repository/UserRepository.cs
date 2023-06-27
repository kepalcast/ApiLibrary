using ApiLibrary.Data;
using ApiLibrary.Models;
using ApiLibrary.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiLibrary.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _db;
        public UserRepository(LibraryContext db)
        {
            _db = db;
        }
        public async Task<Users> GetUser(string username, string pass)
        {
            return await _db.users.FirstOrDefaultAsync(u => u.Name == username && u.Password == pass);
        }

        public bool IsUser(string username, string pass)
        {
            var users = _db.users.ToList();
            return users.Where(u => u.Name == username && u.Password == pass).Count() > 0;
        }
    }
}
