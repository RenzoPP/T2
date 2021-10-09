using Microsoft.AspNetCore.Mvc;
using CalidadT2.Repositories;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILibroRepository repository;
        public HomeController(ILibroRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var libros = repository.GetLibros();
            return View(libros);
        }
    }
}
