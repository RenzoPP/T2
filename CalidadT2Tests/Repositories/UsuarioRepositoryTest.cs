using CalidadT2.Models;
using CalidadT2.Repositories;
using CalidadT2Tests.Controllers.Mocks;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Tests.Repositories
{
    class UsuarioRepositoryTest
    {
        private Mock<AppBibliotecaContext> mockContext;

        [SetUp]
        public void SetUp()
        {
            mockContext = ApplicationContextMock.GetApplicationContextMock();
        }

        [Test]
        public void TestFindUserByCredentialsCaso01()
        {
            var repository = new UsuarioRepository(mockContext.Object);
            var user = repository.FindUserByCredentials("admin", "admin");

            Assert.AreEqual(1, user.Id);
        }

        [Test]
        public void TestFindUserByCredentialsCaso02()
        {
            var repository = new UsuarioRepository(mockContext.Object);
            var user = repository.FindUserByCredentials("userR", "userR");

            Assert.IsNull(user);
        }
    }
}
