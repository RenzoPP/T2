using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Tests.Controllers
{
    class HomeControllerTest
    {
        [Test]
        public void TestSuccessHomeList()
        {
            var mock = new Mock<ILibroRepository>();
            mock.Setup(o => o.GetLibros());
            var controller = new HomeController(mock.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void TestFailHomeList()
        {
            var mock = new Mock<ILibroRepository>();
            mock.Setup(o => o.GetLibros()).Returns((List<Libro>) null);
            var controller = new HomeController(mock.Object);

            var result = controller.Index() as Exception;

            Assert.IsNull(result);
        }
    }
}
