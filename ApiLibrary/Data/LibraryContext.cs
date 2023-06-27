using ApiLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLibrary.Data
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options): base(options) 
        {
        
        }

        public DbSet<Autores> autores { get; set; }
        public DbSet<Libros> libros { get; set; }

        public DbSet<Users> users { get; set; }
        public object Users { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autores>().HasData(
                new Autores()
                {
                    IdAutor = 1,
                    AutorName = "Ruben Darío",
                    FechaNacimiento = new DateTime(1980, 5, 27)
                },
                new Autores()
                {
                    IdAutor = 2,
                    AutorName = "Alvaro cochon",
                    FechaNacimiento = new DateTime(2016, 2, 15)
                });
            modelBuilder.Entity<Libros>().HasData(
                new Libros() 
                {
                    ISBN = "001-1023M",
                    LibName = "La joyita",
                    numPaginas = 342,
                    AutoresId = 2
                },
                new Libros()
                {
                    ISBN = "453-2398N",
                    LibName = "180 dias",
                    numPaginas = 500,
                    AutoresId = 1
                });
            modelBuilder.Entity<Users>().HasData(
                new Users()
                {
                    Id = 1,
                    Name = "administrator",
                    Password = "123",
                    Role = "Administrador"
                },
                new Users()
                {
                Id = 2,
                Name = "Teacher",
                Password = "hola",
                Role = "Docente" 
                });
        }

    }
}
