using ApiLibrary.Models;

namespace ApiLibrary.Repository.IRepository
{
    public interface ILibrosRepository: IRepository<Libros>
    {
        Task<Libros> Update(Libros entity);
    }
}
