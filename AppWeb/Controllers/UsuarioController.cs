using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = Sistema.Instancia;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string pass)
        {

            string rol = _sistema.ObtenerRolUsuario(email);
            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("rol", rol);

            if (rol == "huesped")
                return Redirect("/Actividad/Index");
            else if (rol == "operador")
                return Redirect("/Proveedor/Index");

            return RedirectToAction("login");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}

