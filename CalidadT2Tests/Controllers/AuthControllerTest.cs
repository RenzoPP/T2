using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositories;
using CalidadT2.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CalidadT2Tests
{
    [TestFixture]
    public class AuthControllerTest
    {
        private Mock<IUsuarioRepository> mock;
        private AuthController controller;

        [SetUp]
        public void SetUp()
        {
            mock = new Mock<IUsuarioRepository>();
        }

        [Test]
        public void TestLoginPostFail()
        {
            mock.Setup(o => o.FindUserByCredentials("admin", "1234")).Returns((Usuario)null);
            controller = new AuthController(mock.Object, null);

            var result = controller.Login("admin", "adminfake") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsFalse(controller.ModelState.IsValid);
        }

        [Test]
        public void TestLoginPostSuccess()
        {
            mock.Setup(o => o.FindUserByCredentials("user1", "user1")).Returns(new Usuario());

            var authMock = new Mock<IAuthService>();
            controller = new AuthController(mock.Object, authMock.Object);

            var result = controller.Login("user1", "user1");

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void TestLogout()
        {
            mock.Setup(o => o.FindUserByCredentials("user1", "user1")).Returns(new Usuario());

            var authMock = new Mock<IAuthService>();
            var controller = new AuthController(mock.Object, authMock.Object);

            var result = controller.Logout();

            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
    }
}