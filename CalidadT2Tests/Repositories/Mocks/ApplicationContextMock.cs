using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace CalidadT2Tests.Controllers.Mocks
{
    public class ApplicationContextMock
    {
        public static Mock<AppBibliotecaContext> GetApplicationContextMock()
        {
            IQueryable<Usuario> usuarioData = GetUsuarioData();

            var mockDbSetUsuario = new Mock<DbSet<Usuario>>();
            mockDbSetUsuario.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(usuarioData.Provider);
            mockDbSetUsuario.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(usuarioData.Expression);
            mockDbSetUsuario.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(usuarioData.ElementType);
            mockDbSetUsuario.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(usuarioData.GetEnumerator());
            mockDbSetUsuario.Setup(m => m.AsQueryable()).Returns(usuarioData);

            IQueryable<Libro> libroData = GetLibroData();

            var mockDbSetLibro = new Mock<DbSet<Libro>>();
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.Provider).Returns(libroData.Provider);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.Expression).Returns(libroData.Expression);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.ElementType).Returns(libroData.ElementType);
            mockDbSetLibro.As<IQueryable<Libro>>().Setup(m => m.GetEnumerator()).Returns(libroData.GetEnumerator());
            mockDbSetLibro.Setup(m => m.AsQueryable()).Returns(libroData);

            var mockContext = new Mock<AppBibliotecaContext>(new DbContextOptions<AppBibliotecaContext>());
            mockContext.Setup(c => c.Usuarios).Returns(mockDbSetUsuario.Object);
            mockContext.Setup(c => c.Libros).Returns(mockDbSetLibro.Object);

            return mockContext;
        }

        private static IQueryable<Usuario> GetUsuarioData()
        {
            return new List<Usuario>
            {
                new Usuario { Id = 1, Username = "admin", Password = "admin", Nombres = "Renzo Portocarrero"},
                new Usuario { Id = 2, Username = "user1", Password = "user1", Nombres = "Martha Lopez"}
            }.AsQueryable();
        }

        private static IQueryable<Libro> GetLibroData()
        {
            return new List<Libro>
            {
                new Libro { Id = 2, Nombre = "Harry Potter y la piedra filosofal", Imagen = "/Images/9788478884452.jpg", AutorId = 1, Puntaje = 4 },
                new Libro { Id = 4, Nombre = "Harry Potter y la cámara secreta", Imagen = "/Images/9788498382679.jpg", AutorId = 1, Puntaje = 4 },
                new Libro { Id = 5, Nombre = "Harry Potter y el prisionero de Azkaban", Imagen = "/Images/9788478884452.jpg", AutorId = 1, Puntaje = 4 },
                new Libro { Id = 6, Nombre = "Harry Potter y el cáliz de fuego", Imagen = "/Images/9788478884452.jpg", AutorId = 1, Puntaje = 4 },
                new Libro { Id = 7, Nombre = "Harry Potter y la Orden del Fénix", Imagen = "/Images/9788478884452.jpg", AutorId = 1, Puntaje = 4 },
                new Libro { Id = 8, Nombre = "Harry Potter y el misterio del príncipe", Imagen = "/Images/9788478884452.jpg", AutorId = 1, Puntaje = 4 },
                new Libro { Id = 9, Nombre = "Harry Potter y las reliquias de la Muerte", Imagen = "/Images/9788478884452.jpg", AutorId = 1, Puntaje = 4 },
                new Libro { Id = 10, Nombre = "Harry Potter y el legado maldito", Imagen = "/Images/9788478884452.jpg", AutorId = 1, Puntaje = 3 }
            }.AsQueryable();
        }
    }
}