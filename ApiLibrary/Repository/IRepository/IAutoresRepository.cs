using ApiLibrary.Models;

namespace ApiLibrary.Repository.IRepository
{
    public interface IAutoresRepository: IRepository<Autores>
    {
        Task<Autores> Update(Autores entity);
    }
}
