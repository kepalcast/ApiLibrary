using ApiLibrary.Data;
using ApiLibrary.Models;
using ApiLibrary.Repository.IRepository;

namespace ApiLibrary.Repository
{
    public class AutoresRepository: Repository<Autores>, IAutoresRepository
    {
        private readonly LibraryContext _db;

        public AutoresRepository(LibraryContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Autores> Update(Autores entity)
        {
            _db.autores.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
