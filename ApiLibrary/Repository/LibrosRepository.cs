using ApiLibrary.Data;
using ApiLibrary.Models;
using ApiLibrary.Repository.IRepository;

namespace ApiLibrary.Repository
{
    public class LibrosRepository : Repository<Libros>, ILibrosRepository
    {
        private readonly LibraryContext _db;
        public LibrosRepository(LibraryContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Libros> Update(Libros entity)
        {
            _db.libros.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
