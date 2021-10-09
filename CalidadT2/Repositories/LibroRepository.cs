using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2.Repositories
{
    public interface ILibroRepository
    {
        List<Libro> GetLibros();
    }
    public class LibroRepository : ILibroRepository
    {
        private readonly AppBibliotecaContext context;

        public LibroRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public List<Libro> GetLibros()
        {
            return context.Libros.Include(o => o.Autor).ToList();
        }
    }
}
