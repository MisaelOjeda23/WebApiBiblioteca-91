using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi91.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //Modelos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en tabla usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario()
                {
                    IdUsuario = 1,
                    Nombre = "Misael",
                    Username = "Mishabb",
                    Password = "test123",
                    FkRol = 1,
                }
            );

            //Insertar en tabla rol
            modelBuilder.Entity<Rol>().HasData(
                new Rol()
                {
                    IdRol = 1,
                    Nombre = "sa"
                }
            );


        }



    }
}
