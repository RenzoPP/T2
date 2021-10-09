using CalidadT2.Models;
using CalidadT2.Repositories;
using CalidadT2Tests.Controllers.Mocks;
using Moq;
using NUnit.Framework;

namespace CalidadT2Tests.Repositories
{
    class LibroRepositoryTest
    {
        private Mock<AppBibliotecaContext> mockContext;
        private LibroRepository repository;

        [SetUp]
        public void SetUp()
        {
            mockContext = ApplicationContextMock.GetApplicationContextMock();
            repository = new LibroRepository(mockContext.Object);
        }

        [Test]
        public void TestLibrosListCase01()
        {
            var libros = repository.GetLibros();
            Assert.That(libros.Count == 8);
        }
    }
}
