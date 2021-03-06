using CalidadT2.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Models
{
    public class AppBibliotecaContext: DbContext
    {
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Biblioteca> Bibliotecas { get; set; }
        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Autor> Autores { get; set; }

        public AppBibliotecaContext(DbContextOptions<AppBibliotecaContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LibroMap());
            modelBuilder.ApplyConfiguration(new BibliotecaMap());
            modelBuilder.ApplyConfiguration(new ComentarioMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
        }
    }
}
