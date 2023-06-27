using ApiLibrary.Models;

namespace ApiLibrary.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUser(string username, string pass);

        Task<Users> GetUser(string username, string pass);
    }
}
