using System.Collections.Generic;
using System.Security.Claims;
using CalidadT2.Repositories;
using CalidadT2.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuarioRepository repository;
        private readonly IAuthService auth;

        public AuthController(IUsuarioRepository repository, IAuthService auth)
        {
            this.repository = repository;
            this.auth = auth;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = repository.FindUserByCredentials(username, password);
            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                auth.Login(claims);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("LoginValidation", "Usuario y/o contraseña incorrecta");
            return View();
        }


        public ActionResult Logout()
        {
            auth.Logout();
            return RedirectToAction("Login");
        }
    }
}
